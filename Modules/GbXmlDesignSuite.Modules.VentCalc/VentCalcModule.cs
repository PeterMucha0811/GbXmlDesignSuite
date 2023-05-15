using GbXmlDesignSuite.Modules.VentCalc.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.VentCalc
{
    public class VentCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public VentCalcModule(IUnityContainer container)
        {
            _regionManager = container.Resolve<IRegionManager>();
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(VentCalcView));
        }
    }
}
