using GbXmlDesignSuite.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class AppHomeMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ICommand ExitApplicationCommand { get; private set; }
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }


        public AppHomeMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
