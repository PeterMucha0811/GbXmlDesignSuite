using Prism.Mvvm;
using Prism.Regions;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels
{
    public class OpeningsWindowTypesMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public OpeningsWindowTypesMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}