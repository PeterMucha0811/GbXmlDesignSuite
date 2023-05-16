using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Modules.ProjectMgmt.ViewModels;
using GbXmlDesignSuite.Modules.ProjectMgmt.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.ProjectMgmt
{
    public class ProjectMgmtModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ProjectMgmtModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, "ProjectMgmtView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProjectMgmtView, ProjectMgmtViewModel>();
        }
    }
}

