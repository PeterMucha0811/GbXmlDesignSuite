
using System.Windows;

namespace GbXmlDesignSuite.Modules.ProjectMgmt.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PrismWindow1.xaml
    /// </summary>
    public partial class PrismWindow1 : Window
    {
        public PrismWindow1()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
