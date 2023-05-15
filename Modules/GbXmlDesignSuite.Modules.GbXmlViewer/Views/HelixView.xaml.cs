using System.Windows;
using System;
using GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels;
using System.Windows.Controls;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.Views
{

    public partial class HelixView : UserControl
    {
        public HelixView()
        {
            InitializeComponent();

  

       
            this.DataContext = new HelixViewModel();


        }
    }
}
