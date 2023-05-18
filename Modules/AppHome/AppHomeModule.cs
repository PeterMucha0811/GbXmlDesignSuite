using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Modules.AppHome.ViewModels;
using GbXmlDesignSuite.Modules.AppHome.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.AppHome
{
    public class AppHomeModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppHomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "AppHomeView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AppHomeView, AppHomeViewModel>();
        }
    }
}