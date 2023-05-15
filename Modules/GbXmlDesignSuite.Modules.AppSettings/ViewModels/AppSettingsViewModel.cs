using GbXmlDesignSuite.Core;
using GbXmlDesignSuite.Core.Base;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbXmlDesignSuite.Modules.AppSettings.ViewModels
{
    public class AppSettingsViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        public AppSettingsViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }


        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }



        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }

    }
}
