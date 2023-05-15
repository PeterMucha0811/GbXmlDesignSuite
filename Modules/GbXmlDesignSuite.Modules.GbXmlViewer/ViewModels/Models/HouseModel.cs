using HelixToolkit.Wpf.SharpDX;
using Vector3 = SharpDX.Vector3;
using MeshGeometry3D = HelixToolkit.Wpf.SharpDX.MeshGeometry3D;
using System.Collections.Generic;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Models
{
    public class HouseModel
    {
        public MeshGeometry3D Floor { get; set; }
        public IList<MeshGeometry3D> Walls { get; set; }
        public MeshGeometry3D Roof { get; set; }
        public Vector3 RoofCenter { get; set; }

        public static HouseModel CreateHouseModel(double width, double height, double length)
        {
            var model = new HouseModel();

            // Create floor
            model.Floor = CreateFloor(width, length);

            // Create walls
            model.Walls = CreateWalls(width, height, length);

            // Create roof
            model.Roof = CreateRoof(width, height, length);

            // Set roof's center point
            model.RoofCenter = new Vector3((float)width / 2, (float)height, (float)length / 2);

            return model;
        }

        private static MeshGeometry3D CreateFloor(double width, double length)
        {
            var builder = new MeshBuilder();
            builder.AddBox(new Vector3((float)width / 2, 0, (float)length / 2), (float)width, 0.1f, (float)length);
            return builder.ToMesh();
        }

        private static IList<MeshGeometry3D> CreateWalls(double width, double height, double length)
        {
            var walls = new List<MeshGeometry3D>();

            var builder = new MeshBuilder();
            builder.AddBox(new Vector3((float)width / 2, (float)height / 2, 0), (float)width, (float)height, 0.1f);
            walls.Add(builder.ToMesh());

            builder = new MeshBuilder();
            builder.AddBox(new Vector3((float)width / 2, (float)height / 2, (float)length), (float)width, (float)height, 0.1f);
            walls.Add(builder.ToMesh());

            builder = new MeshBuilder();
            builder.AddBox(new Vector3(0, (float)height / 2, (float)length / 2), 0.1f, (float)height, (float)length);
            walls.Add(builder.ToMesh());

            builder = new MeshBuilder();
            builder.AddBox(new Vector3((float)width, (float)height / 2, (float)length / 2), 0.1f, (float)height, (float)length);
            walls.Add(builder.ToMesh());

            return walls;
        }

        private static MeshGeometry3D CreateRoof(double width, double height, double length)
        {
            var builder = new MeshBuilder();
            builder.AddPyramid(new Vector3((float)width / 2, (float)height, (float)length / 2), (float)width, (float)length);
            return builder.ToMesh();
        }
    }
}
