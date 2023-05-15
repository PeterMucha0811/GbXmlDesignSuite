using System.Linq;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;

using HelixToolkit.Wpf.SharpDX;
using Media3D = System.Windows.Media.Media3D;
using GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Models;

using Plane = SharpDX.Plane;
using Vector3 = SharpDX.Vector3;
using Point3D = System.Windows.Media.Media3D.Point3D;
using Vector3D = System.Windows.Media.Media3D.Vector3D;
using Transform3D = System.Windows.Media.Media3D.Transform3D;
using Transform3DGroup = System.Windows.Media.Media3D.Transform3DGroup;
using RotateTransform3D = System.Windows.Media.Media3D.RotateTransform3D;
using AxisAngleRotation3D = System.Windows.Media.Media3D.AxisAngleRotation3D;

using Color = System.Windows.Media.Color;
using Colors = System.Windows.Media.Colors;
using Color4 = SharpDX.Color4;

using Camera = HelixToolkit.Wpf.SharpDX.Camera;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;
using ProjectionCamera = HelixToolkit.Wpf.SharpDX.ProjectionCamera;
using Prism.Mvvm;
using GbXmlDesignSuite.Core.Base;
using GbXmlDesignSuite.Core;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class HelixViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    
        public ObservableCollection<Element3D> SceneItems { get; } = new ObservableCollection<Element3D>();

        public string Title { get; set; }
        public string SubTitle { get; set; }


        public GbXMLModel GbXmlModel { get; set; }


        public EffectsManager EffectsManager { get; }
        public Camera Camera { get; }
        public ProjectionCamera Camera1 { private set; get; }
        public Size ShadowMapResolution { get; private set; }
        public Transform3D Light1Transform { get; private set; }

        public Vector3D Light1Direction { get; set; }
        public bool RenderLight1 { get; set; }
        public Color Light1Color { get; set; }
        public Transform3D Light1DirectionTransform { get; private set; }


        public LineGeometry3D Coordinate { private set; get; }
        public BillboardText3D CoordinateText { private set; get; }
        public Geometry3D Geometry { private set; get; }
        public Material Material { private set; get; }

        public MeshGeometry3D Floor { get; private set; }
        public Material FloorMaterial { get; } = PhongMaterials.Gray;
        public BillboardText3D MeshTitles { private set; get; }
        public Transform3D TitleTransform { get; } = new Media3D.TranslateTransform3D(0, 10, 0);

        private TextureModel _environmentMap;
        public TextureModel EnvironmentMap
        {
            get { return _environmentMap; }
            set { SetProperty(ref _environmentMap, value); }
        }


        public HelixViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            // --------------------------- Titles ---------------------------
            this.Title = "Lighting Demo";
            this.SubTitle = "WPF & SharpDX";


            // -------------- Load gbXML Model & Create Scene --------------
            GbXmlModel = new GbXMLModel();
            AddHouseToSceneItems(GbXmlModel.House);


            // --------------------- Viewport Settings ---------------------
            ShadowMapResolution = new Size(2048, 2048);
            EffectsManager = new DefaultEffectsManager();


            // ----------------------- Camera Setup -----------------------


            // // User Camera Settings // //
            this.Camera = new PerspectiveCamera
            {
                Position = new Point3D(68, 115, 246),
                LookDirection = new Vector3D(-68, -115, -246),
                UpDirection = new Vector3D(0, 1, 0)
            };

            // // Light Camera Settings // //
            this.Camera1 = new PerspectiveCamera
            {
                Position = new Point3D(0, 5, 0),
                LookDirection = new Vector3D(0, -1, 0),
                UpDirection = new Vector3D(1, 0, 0),
                FarPlaneDistance = 5000,
                NearPlaneDistance = 1,
                FieldOfView = 45
            };



            //this.Light1Direction = new Vector3D(0, -10, 0);
            //this.Light1Transform = CreateAnimatedTransform1(-Light1Direction, new Vector3D(1, 0, 0), 24);
            //this.Light1DirectionTransform = CreateAnimatedTransform2(-Light1Direction, new Vector3D(0, 1, -1), 24);



            //var builder = new MeshBuilder();
            //builder.AddBox(new Vector3(0, -6, 0), 200, 2, 100);
            //Floor = builder.ToMesh();

            (FloorMaterial as PhongMaterial).RenderShadowMap = true;

            // Add the text labels for each model (the specific text and positions may vary)
            MeshTitles = new BillboardText3D();




            // // Viewport3D - Axis Icon // //
            InitializeCoordinates();

            // // Background of Grandcanyon // //
            EnvironmentMap = LoadTexture("Resources/Cubemap_Grandcanyon.dds");

        }

        // // Background of Grandcanyon // //
        private TextureModel LoadTexture(string path)
        {
            var texture = new TextureModel(new FileStream(path, FileMode.Open, FileAccess.Read));
            return texture;
        }


        // // Viewport3D - Axis Icon // //
        private void InitializeCoordinates()
        {

            Material = PhongMaterials.Red;
            var builder = new LineBuilder();
            builder.AddLine(Vector3.Zero, Vector3.UnitX * 5);
            builder.AddLine(Vector3.Zero, Vector3.UnitY * 5);
            builder.AddLine(Vector3.Zero, Vector3.UnitZ * 5);
            Coordinate = builder.ToLineGeometry3D();
            Coordinate.Colors = new Color4Collection(Enumerable.Repeat<Color4>(SharpDX.Color.White, 6));
            Coordinate.Colors[0] = Coordinate.Colors[1] = SharpDX.Color.Red;
            Coordinate.Colors[2] = Coordinate.Colors[3] = SharpDX.Color.Green;
            Coordinate.Colors[4] = Coordinate.Colors[5] = SharpDX.Color.Blue;

            CoordinateText = new BillboardText3D();
            CoordinateText.TextInfo.Add(new TextInfo("X", Vector3.UnitX * 6));
            CoordinateText.TextInfo.Add(new TextInfo("Y", Vector3.UnitY * 6));
            CoordinateText.TextInfo.Add(new TextInfo("Z", Vector3.UnitZ * 6));
        }


        private void AddHouseToSceneItems(HouseModel house)
        {
            // Add floor
            var floorMaterial = PhongMaterials.Gray;
            SceneItems.Add(new MeshGeometryModel3D { Geometry = house.Floor, Material = floorMaterial });

            // Add walls
            var wallMaterial = PhongMaterials.LightGray;
            foreach (var wall in house.Walls)
            {
                SceneItems.Add(new MeshGeometryModel3D { Geometry = wall, Material = wallMaterial });
            }

            // Add roof
            var roofMaterial = PhongMaterials.MediumGray;
            var roofModel = new MeshGeometryModel3D { Geometry = house.Roof, Material = roofMaterial };
            var transformGroup = new Transform3DGroup();

            // Rotate the roof 90 degrees around the Z axis
            var rotationAxis = new Vector3D(0, 0, 1);
            var rotationCenter = new Point3D(house.RoofCenter.X, house.RoofCenter.Y, house.RoofCenter.Z);
            var rotation = new RotateTransform3D(new AxisAngleRotation3D(rotationAxis, 90), rotationCenter);
            transformGroup.Children.Add(rotation);

            roofModel.Transform = transformGroup;
            SceneItems.Add(roofModel);
        }

        private Media3D.Transform3D CreateAnimatedTransform1(Vector3D translate, Vector3D axis, double speed = 4)
        {
            var lightTrafo = new Media3D.Transform3DGroup();
            lightTrafo.Children.Add(new Media3D.TranslateTransform3D(translate));

            var rotateAnimation = new System.Windows.Media.Animation.Rotation3DAnimation
            {
                RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever,
                By = new Media3D.AxisAngleRotation3D(axis, 90),
                Duration = System.TimeSpan.FromSeconds(speed / 4),
                IsCumulative = true,
            };

            var rotateTransform = new Media3D.RotateTransform3D();
            rotateTransform.BeginAnimation(Media3D.RotateTransform3D.RotationProperty, rotateAnimation);
            lightTrafo.Children.Add(rotateTransform);

            return lightTrafo;
        }

        private Media3D.Transform3D CreateAnimatedTransform2(Vector3D translate, Vector3D axis, double speed = 4)
        {
            var lightTrafo = new Media3D.Transform3DGroup();
            lightTrafo.Children.Add(new Media3D.TranslateTransform3D(translate));

            var rotateAnimation = new System.Windows.Media.Animation.Rotation3DAnimation
            {
                RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever,
                //By = new Media3D.AxisAngleRotation3D(axis, 180),
                From = new Media3D.AxisAngleRotation3D(axis, 135),
                To = new Media3D.AxisAngleRotation3D(axis, 225),
                AutoReverse = true,
                Duration = System.TimeSpan.FromSeconds(speed / 4),
                //IsCumulative = true,                  
            };

            var rotateTransform = new Media3D.RotateTransform3D();
            rotateTransform.BeginAnimation(Media3D.RotateTransform3D.RotationProperty, rotateAnimation);
            lightTrafo.Children.Add(rotateTransform);
            return lightTrafo;

        }
    }
}
