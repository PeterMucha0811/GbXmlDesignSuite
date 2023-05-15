using GbXmlDesignSuite.Core.Base;
using GbXmlDesignSuite.Core.Constants;
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

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
