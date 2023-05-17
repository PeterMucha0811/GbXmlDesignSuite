using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Windows.Input;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public MainWindowViewModel(IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _containerProvider = containerProvider;


            NavigateCommand = new DelegateCommand<string>(Navigate);
            ExitApplicationCommand = new DelegateCommand(ExitApplication);


            // //  Register for StatusBar Events  // //
            //_eventAggregator.GetEvent<StatusBarUpdateEvent>().Subscribe(UpdateStatusBar);
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Subscribe(UpdateStatusBar, ThreadOption.UIThread, false, null);

            if(StatusBarMessage == null)
            {
                StatusBarMessage = "Ready to do stuff!!";
            }
        }



        private void UpdateStatusBar(string statusBarMessage)
        {
            this.StatusBarMessage = statusBarMessage;
        }


        private string _statusBarMessage;
        public string StatusBarMessage
        {
            get { return _statusBarMessage; }
            set { this.SetProperty<string>(ref this._statusBarMessage, value); }
        }





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


