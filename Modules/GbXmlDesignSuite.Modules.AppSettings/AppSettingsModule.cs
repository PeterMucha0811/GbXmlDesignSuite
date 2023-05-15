using GbXmlDesignSuite.Modules.AppSettings.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.AppSettings
{
    public class AppSettingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppSettingsModule(IUnityContainer container)
        {
            _regionManager = container.Resolve<IRegionManager>();
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(AppSettingsView));
        }
    }
}