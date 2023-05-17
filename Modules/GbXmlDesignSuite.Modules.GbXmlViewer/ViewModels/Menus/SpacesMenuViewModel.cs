using Prism.Mvvm;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class SpacesMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public SpacesMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

        }
    }
}