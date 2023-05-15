using GbXmlDesignSuite.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class BottomMenuDockBarViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ICommand ExitApplicationCommand { get; private set; }
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }


        public DelegateCommand<string> NavigateCommand { get; private set; }

        // This is the parameterless constructor for design-time data
        public BottomMenuDockBarViewModel()
        {
            // You might want to add some dummy data here for the designer to display.
        }

        public BottomMenuDockBarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);

            ExitApplicationCommand = new DelegateCommand(ExitApplication);
        }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
