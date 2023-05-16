using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Modules.LoadCalc.ViewModels;
using GbXmlDesignSuite.Modules.LoadCalc.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.LoadCalc
{
    public class LoadCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LoadCalcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "LoadCalcView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoadCalcView, LoadCalcViewModel>();
        }
    }
}