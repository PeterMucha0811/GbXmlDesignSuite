using Prism.Mvvm;
using System.Windows.Media;

namespace GbXmlDesignSuite.Modules.AppSettings.Models
{
    public class AccentColor : BindableBase
    {
        private string _accentColorName;
        public string AccentColorName
        {
            get { return _accentColorName; }
            set { this.SetProperty<string>(ref this._accentColorName, value); }
        }

        private Brush _accentColorBrush;
        public Brush AccentColorBrush
        {
            get { return _accentColorBrush; }
            set { this.SetProperty<Brush>(ref this._accentColorBrush, value); }
        }
    }
}
