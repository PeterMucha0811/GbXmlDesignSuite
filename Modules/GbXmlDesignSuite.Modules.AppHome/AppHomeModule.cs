using Prism.Modularity;
using Prism.Ioc;
using GbXmlDesignSuite.Modules.AppHome.Views;
using GbXmlDesignSuite.Core;
using Prism.Regions;
using GbXmlDesignSuite.Modules.AppHome.ViewModels;
using GbXmlDesignSuite.Services;

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

            // Register Services
            containerRegistry.Register<IProjectsService, ProjectsService>();
        }
    }
}
