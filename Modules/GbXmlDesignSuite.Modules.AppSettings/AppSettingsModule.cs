using GbXmlDesignSuite.Modules.AppSettings.ViewModels;
using GbXmlDesignSuite.Modules.AppSettings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

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
            _regionManager.RequestNavigate("ContentRegion", "AppSettingsView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AppSettingsView, AppSettingsViewModel>();
        }
    }
}