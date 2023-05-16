using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Core.Services;
using Prism;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
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
using GbXmlDesignSuite.Core;


namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class GbXmlViewerViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly ProjectStateService _projectStateService;

        public GbXmlViewerViewModel(IRegionManager regionManager,
        IEventAggregator eventAggregator,
        ProjectStateService projectStateService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _projectStateService = projectStateService;
        }


        private ObservableCollection<ProjectsModel> _projects;
        public ObservableCollection<ProjectsModel> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                OnIsActiveChanged();
            }
        }

        public event EventHandler IsActiveChanged;

        private void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                // Load state when the module becomes active
                var state = _projectStateService.GetModuleState("GbXmlViewer");
                if (state != null)
                {
                    // Restore the state (e.g. Projects collection)
                    Projects = state as ObservableCollection<ProjectsModel>;

                }
            }
            else
            {
                // Save state when the module becomes inactive
                _projectStateService.SetModuleState("GbXmlViewer", Projects);
            }
        }


        // Update the state in the shared service when changes are made
        public void UpdateProjectState()
        {
            _projectStateService.SetModuleState("GbXmlViewer", Projects);
        }
    }
}
