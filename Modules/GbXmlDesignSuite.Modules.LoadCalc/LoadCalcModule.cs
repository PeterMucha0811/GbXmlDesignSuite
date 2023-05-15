using GbXmlDesignSuite.Modules.LoadCalc.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.LoadCalc
{
    public class LoadCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LoadCalcModule(IUnityContainer container)
        {
            _regionManager = container.Resolve<IRegionManager>();
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(LoadCalcView));
        }
    }
}