using Prism.Regions;
using System.Windows;
using System.Windows.Input;

namespace GbXmlDesignSuite.Shell.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _defaultWindowSize = this.Width;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = _defaultWindowSize;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }


        private double _defaultWindowSize;
        private bool _isCollapsed = false;
        private void CollapseWindow(object sender, RoutedEventArgs e)
        {
            if (_isCollapsed == false)
            {
                (this as Window).Width = 250;
                _isCollapsed = true;
            }
            else
            {
                (this as Window).Width = _defaultWindowSize;
                _isCollapsed = false;
            }
        }
    }
}




