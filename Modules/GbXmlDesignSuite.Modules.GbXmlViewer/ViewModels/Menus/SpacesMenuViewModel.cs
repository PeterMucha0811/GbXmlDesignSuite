using GbXmlDesignSuite.Core.Base;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class SpacesMenuViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public SpacesMenuViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}