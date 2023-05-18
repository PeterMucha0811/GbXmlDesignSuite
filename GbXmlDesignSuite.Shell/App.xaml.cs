using GbXmlDesignSuite.Modules.AppSettings;
using GbXmlDesignSuite.Modules.GbXmlViewer;
using GbXmlDesignSuite.Modules.LoadCalc;
using GbXmlDesignSuite.Modules.ProjectMgmt;
using GbXmlDesignSuite.Modules.VentCalc;
using GbXmlDesignSuite.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Services;
using GbXmlDesignSuite.Modules.AppHome;

namespace GbXmlDesignSuite.Shell
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // //  Register State Services as Singletons  // //
            containerRegistry.RegisterSingleton<IGbXmlViewerStateService, GbXmlViewerStateService>();

            containerRegistry.RegisterSingleton<ILoadCalcStateService, LoadCalcStateService>();

            containerRegistry.RegisterSingleton<IVentCalcStateService, VentCalcStateService>();

            containerRegistry.RegisterSingleton<IAppSettingsStateService, AppSettingsStateService>();

            containerRegistry.RegisterSingleton<IProjectMgmtStateService, ProjectMgmtStateService>();

            containerRegistry.RegisterSingleton<IAppHomeStateService, AppHomeStateService>();


            containerRegistry.RegisterSingleton<IProjectsService, ProjectsService>();
            containerRegistry.RegisterSingleton<IDialogsService, DialogService>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AppHomeModule>();
            moduleCatalog.AddModule<GbXmlViewerModule>();
            moduleCatalog.AddModule<LoadCalcModule>();
            moduleCatalog.AddModule<VentCalcModule>();
            moduleCatalog.AddModule<AppSettingsModule>();
            moduleCatalog.AddModule<ProjectMgmtModule>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = this.Container.Resolve<IRegionManager>();
            if (regionManager != null)
            {
                //regionManager.RegisterViewWithRegion(RegionNames.LeftDockRegion, typeof(NavigationMenu));

                regionManager.RegisterViewWithRegion(RegionNames.LeftDockRegion, typeof(AppHomeMenu));

            }
        }
    }
}