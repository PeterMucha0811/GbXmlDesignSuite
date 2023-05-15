using GbXmlDesignSuite.Modules.GbXmlViewer.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer
{
    public class GbXmlViewerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public GbXmlViewerModule(IUnityContainer container)
        {
            _regionManager = container.Resolve<IRegionManager>();
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(GbXmlViewerView));
        }
    }
}