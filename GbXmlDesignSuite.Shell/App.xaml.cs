using GbXmlDesignSuite.Core.Base;
using GbXmlDesignSuite.Core.Services;
using GbXmlDesignSuite.Modules.AppSettings;
using GbXmlDesignSuite.Modules.GbXmlViewer;
using GbXmlDesignSuite.Modules.LoadCalc;
using GbXmlDesignSuite.Modules.ProjectMgmt;
using GbXmlDesignSuite.Modules.VentCalc;
using GbXmlDesignSuite.Shell.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.ComponentModel;
using System.Windows;


namespace GbXmlDesignSuite.Shell
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register your services as singletons here

            //containerRegistry.RegisterSingleton<IGbXmlViewerService, GbXmlViewerService>();
            //containerRegistry.RegisterSingleton<ILoadCalcService, LoadCalcService>();
            //containerRegistry.RegisterSingleton<IVentCalcService, VentCalcService>();
            //containerRegistry.RegisterSingleton<IProjectManagementService, ProjectManagementService>();

            // Register your state services as singletons here

            //containerRegistry.RegisterSingleton<GbXmlViewerStateService>();
            //containerRegistry.RegisterSingleton<LoadCalcStateService>();
            //containerRegistry.RegisterSingleton<VentCalcStateService>();
            //containerRegistry.RegisterSingleton<AppSettingsStateService>();
            //containerRegistry.RegisterSingleton<ProjectMgmtStateService>();



        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<AppHomeModule>();
            moduleCatalog.AddModule<GbXmlViewerModule>();
            moduleCatalog.AddModule<LoadCalcModule>();
            moduleCatalog.AddModule<VentCalcModule>();
            moduleCatalog.AddModule<AppSettingsModule>();
            moduleCatalog.AddModule<ProjectMgmtModule>();

        }
    }
}