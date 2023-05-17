using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Media;

namespace GbXmlDesignSuite.Modules.AppSettings.Models
{
    public class PryBgColor : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { this.SetProperty<string>(ref this._name, value); }
        }

        private Brush _colorBrush;
        public Brush ColorBrush
        {
            get { return _colorBrush; }
            set { this.SetProperty<Brush>(ref this._colorBrush, value); }
        }

        public PryBgColor(IRegionManager regionManager)
        {
        }
    }
}

