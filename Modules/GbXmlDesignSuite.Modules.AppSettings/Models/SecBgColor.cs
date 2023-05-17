using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Media;

namespace GbXmlDesignSuite.Modules.AppSettings.Models
{
    public class SecBgColor : BindableBase
    {
        private string _secBgColorName;
        public string SecBgColorName
        {
            get { return _secBgColorName; }
            set { this.SetProperty<string>(ref this._secBgColorName, value); }
        }

        private Brush _secBgColorBrush;
        public Brush SecBgColorBrush
        {
            get { return _secBgColorBrush; }
            set { this.SetProperty<Brush>(ref this._secBgColorBrush, value); }
        }

        public SecBgColor(IRegionManager regionManager)
        {
        }
    }
}

