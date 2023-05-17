using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GbXmlDesignSuite.Shell.Views
{
    public partial class NavigationMenu : UserControl
    {
        public NavigationMenu()
        {
            InitializeComponent();
            InitializeData();
        }



        #region Navigation Menu Appearance (Manages Active Tab Highlight)

        // Program Colors
        private SolidColorBrush _defaultColor;
        private SolidColorBrush _activeColor;

        // Dictionary of Button Names & Associated Parent Boarders
        private Dictionary<string, DependencyObject> _tabData;

        // Current Button Name & Boarder as Object
        private string _actTab_ButtonName;
        DependencyObject _dependencyObject;

        private void InitializeData()
        {
            // Get Resorce Tab Colors
            _defaultColor = (SolidColorBrush)Application.Current.Resources["menuBackColor"];
            _activeColor = (SolidColorBrush)Application.Current.Resources["menuActiveTabColor"];

            _tabData = new Dictionary<string, DependencyObject>();
            _tabData.Add("projectMgmtViewButton", (HomeBorder as Border));
            _tabData.Add("gbXmlViewerViewButton", (GbxmlViewerBorder as Border));
            _tabData.Add("ventCalcViewButton", (VentCalcBorder as Border));
            _tabData.Add("loadCalcViewButton", (LoadCalcBorder as Border));
            _tabData.Add("appSettingsViewButton", (SettingsBorder as Border));
            _tabData.Add("exitApplicationButton", (CloseAppBorder as Border));


            //// Set Active Tab
            _actTab_ButtonName = "projectMgmtViewButton";
            _dependencyObject = (HomeBorder as Border);
            (_dependencyObject as Border).Background = _activeColor;
        }


        // Tab Visibility Brain
        private void ActiveTab_Click(object sender, RoutedEventArgs e)
        {
            // Get the Name of Button Clicked
            string content = (sender as Button).Name.ToString();

            // If Not the Active Tab
            if (content != _actTab_ButtonName)
            {
                // Turn Off Previous Tab Background
                (_dependencyObject as Border).Background = _defaultColor;


                // Update Name of new Active Tab
                _actTab_ButtonName = content;

                // Update Tab as Object
                _dependencyObject = (_tabData[content] as Border);
                (_dependencyObject as Border).Background = _activeColor;

            }
        }
        #endregion
    }
}
