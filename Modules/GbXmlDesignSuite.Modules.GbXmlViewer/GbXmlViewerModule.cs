using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels;
using GbXmlDesignSuite.Modules.GbXmlViewer.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer
{
    public class GbXmlViewerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public GbXmlViewerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "GbXmlViewerView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GbXmlViewerView, GbXmlViewerViewModel>();
        }
    }
}