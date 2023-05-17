using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Core.Events;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);

            ExitApplicationCommand = new DelegateCommand(ExitApplication);

            // Register to events
            //EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);
        }

        //private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        //{
        //    this.StatusBarMessage = statusBarMessage;
        //}

        //private string _statusBarMessage;
        //public string StatusBarMessage
        //{
        //    get { return _statusBarMessage; }
        //    set { this.SetProperty<string>(ref this._statusBarMessage, value); }
        //}


        public ICommand ExitApplicationCommand { get; private set; }
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }


        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
