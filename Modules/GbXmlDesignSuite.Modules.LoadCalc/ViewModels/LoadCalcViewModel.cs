using GbXmlDesignSuite.Core.Base;
using GbXmlDesignSuite.Core.Constants;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.LoadCalc.ViewModels
{
    public class LoadCalcViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public LoadCalcViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
