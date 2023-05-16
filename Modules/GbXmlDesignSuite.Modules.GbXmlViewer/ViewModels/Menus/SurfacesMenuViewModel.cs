using GbXmlDesignSuite.Core;
using Prism.Mvvm;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class SurfacesMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public SurfacesMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}