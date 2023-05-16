using GbXmlDesignSuite.Core.Interfaces;
using GbXmlDesignSuite.Core.Services;
using GbXmlDesignSuite.Modules.AppSettings;
using GbXmlDesignSuite.Modules.GbXmlViewer;
using GbXmlDesignSuite.Modules.LoadCalc;
using GbXmlDesignSuite.Modules.ProjectMgmt;
using GbXmlDesignSuite.Modules.VentCalc;
using GbXmlDesignSuite.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;


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
            // //  Register services as singletons here  // //
            containerRegistry.RegisterSingleton<IGbXmlViewerService, GbXmlViewerService>();
            containerRegistry.RegisterSingleton<ILoadCalcService, LoadCalcService>();
            containerRegistry.RegisterSingleton<IVentCalcService, VentCalcService>();
            containerRegistry.RegisterSingleton<IAppSettingsService, AppSettingsService>();
            containerRegistry.RegisterSingleton<IProjectMgmtService, ProjectMgmtService>();


            //// //  Register state services as singletons here  // //
            containerRegistry.RegisterSingleton<GbXmlViewerStateService>();
            containerRegistry.RegisterSingleton<LoadCalcStateService>();
            containerRegistry.RegisterSingleton<VentCalcStateService>();
            containerRegistry.RegisterSingleton<AppSettingsStateService>();
            containerRegistry.RegisterSingleton<ProjectStateService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<GbXmlViewerModule>();
            moduleCatalog.AddModule<LoadCalcModule>();
            moduleCatalog.AddModule<VentCalcModule>();
            moduleCatalog.AddModule<AppSettingsModule>();
            moduleCatalog.AddModule<ProjectMgmtModule>();
        }

    }
}