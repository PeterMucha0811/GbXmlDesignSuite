using GbXmlDesignSuite.Core.Services;
using GbXmlDesignSuite.Modules.AppSettings;
using GbXmlDesignSuite.Modules.GbXmlViewer;
using GbXmlDesignSuite.Modules.LoadCalc;
using GbXmlDesignSuite.Modules.ProjectMgmt;
using GbXmlDesignSuite.Modules.VentCalc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;
using GbXmlDesignSuite.Shell.Views;

namespace GbXmlDesignSuite.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }


        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }



        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Register your state services as singletons here
            Container.RegisterType<GbXmlViewerStateService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<LoadCalcStateService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<VentCalcStateService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<AppSettingsStateService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ProjectMgmtStateService>(new ContainerControlledLifetimeManager());
        }


        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(GbXmlViewerModule));
            moduleCatalog.AddModule(typeof(LoadCalcModule));
            moduleCatalog.AddModule(typeof(VentCalcModule));
            moduleCatalog.AddModule(typeof(AppSettingsModule));
            moduleCatalog.AddModule(typeof(ProjectMgmtModule));
        }
    }
}


