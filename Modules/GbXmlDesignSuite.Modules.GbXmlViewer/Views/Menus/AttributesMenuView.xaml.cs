using GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Menus;
using System.Windows.Controls;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.Views.Menus
{
    /// <summary>
    /// Interaction logic for AttributesMenuView
    /// </summary>
    public partial class AttributesMenuView : UserControl
    {
        public AttributesMenuView()
        {
            InitializeComponent();
            DataContext = new AttributesMenuViewModel();
        }
    }
}
