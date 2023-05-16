using Prism.Mvvm;
using System.Windows.Media;

namespace GbXmlDesignSuite.Shell.Models
{
    public class PrimaryBackgroundColor : BindableBase
    {
        private string _name;

        /// <summary>
        /// Color AccentColorName
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { this.SetProperty<string>(ref this._name, value); }
        }


        private Brush _colorBrush;

        /// <summary>
        /// Color Brush
        /// </summary>
        public Brush ColorBrush
        {
            get { return _colorBrush; }
            set { this.SetProperty<Brush>(ref this._colorBrush, value); }
        }
    }
}