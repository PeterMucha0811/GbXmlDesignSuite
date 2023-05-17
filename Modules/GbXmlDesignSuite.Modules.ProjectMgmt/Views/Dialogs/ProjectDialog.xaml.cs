using System.Windows;

namespace GbXmlDesignSuite.Modules.ProjectMgmt.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for ProjectDialog.xaml
    /// </summary>
    public partial class ProjectDialog : Window
    {
        public ProjectDialog()
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
