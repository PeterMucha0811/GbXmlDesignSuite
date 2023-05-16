using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class ZonesMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ZonesMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;           
        }
    }
}
