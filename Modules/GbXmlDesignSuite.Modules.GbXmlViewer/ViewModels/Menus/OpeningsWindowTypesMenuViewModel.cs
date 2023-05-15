using GbXmlDesignSuite.Core.Base;
using Prism.Regions;


namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class OpeningsWindowTypesMenuViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public OpeningsWindowTypesMenuViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}