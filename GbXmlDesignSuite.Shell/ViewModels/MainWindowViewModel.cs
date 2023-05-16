using GbXmlDesignSuite.Core.Events;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            // Register to events
            //EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);
        }

        private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        {
            this.StatusBarMessage = statusBarMessage;
        }


        private string _statusBarMessage;
        public string StatusBarMessage
        {
            get { return _statusBarMessage; }
            set { this.SetProperty<string>(ref this._statusBarMessage, value); }
        }

    }
}
