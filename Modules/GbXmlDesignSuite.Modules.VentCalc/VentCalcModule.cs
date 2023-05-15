using GbXmlDesignSuite.Modules.ProjectMgmt.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.VentCalc
{
    public class VentCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public VentCalcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("ContentRegion", "VentCalcView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VentCalcModule, ProjectMgmtViewModel>();
        }
    }
}
