using Prism.Mvvm;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class StoreysMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public StoreysMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

    }
}