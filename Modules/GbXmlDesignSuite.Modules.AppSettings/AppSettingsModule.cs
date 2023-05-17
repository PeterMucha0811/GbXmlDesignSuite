using Prism.Modularity;
using Prism.Ioc;
using GbXmlDesignSuite.Modules.AppSettings.Views;
using GbXmlDesignSuite.Core;
using Prism.Regions;
using GbXmlDesignSuite.Modules.AppSettings.ViewModels;

namespace GbXmlDesignSuite.Modules.AppSettings
{
    public class AppSettingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppSettingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "AppSettingsView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AppSettingsView, AppSettingsViewModel>();
        }
    }
}