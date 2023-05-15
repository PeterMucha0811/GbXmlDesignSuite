using GbXmlDesignSuite.Core.Base;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Menus
{
    public class SurfacesByTypeMenuViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;
        public SurfacesByTypeMenuViewModel(IRegionManager regionManager) : base(regionManager)
        {
            IsItemVisible = true;
            _regionManager = regionManager;
        }
  

        private bool _isItemVisible;
        public bool IsItemVisible
        {
            get { return _isItemVisible; }
            set
            {
                SetProperty(ref _isItemVisible, value);
                UpdateItemVisibility();
            }
        }

        private void UpdateItemVisibility()
        {
            // Code to update visibility of items in Helix Viewport3D.
            // You can use IsItemVisible property to determine whether to show or hide items.
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}


