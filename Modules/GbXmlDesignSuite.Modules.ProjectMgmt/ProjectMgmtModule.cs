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
        private readonly IContainerProvider _containerProvider;

        public ProjectMgmtModule(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate("ContentRegion", "ProjectMgmtView");

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ProjectMgmtView, ProjectMgmtViewModel>();

            // // // PETER!! ADD THIS TO YOUR CODE // // //
            //containerRegistry.RegisterDialogWindow<ProjectDialog>();
        }
    }
}
