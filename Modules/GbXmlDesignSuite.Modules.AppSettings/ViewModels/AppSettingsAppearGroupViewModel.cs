using System;
using Prism.Modularity;
using Prism.Ioc;

namespace GbXmlDesignSuite.Modules.AppSettings.ViewModels
{
    public class AppSettingsAppearGroupViewModel : IModule
    {
        //private readonly IRegionManager _regionManager;

        //private string _selectedItem;
        //public string SelectedItem
        //{
        //    get => _selectedItem;
        //    set => _selectedItem = value;
        //}

        //public ObservableCollection<string> Items { get; }

        //public AppSettingsAppearGroupViewModel(IRegionManager regionManager)
        //{
        //    _regionManager = regionManager;

        //    // create sample data for the demo
        //    Items = new ObservableCollection<string> { "Item1", "Item2", "Item3" };


        //    //// create metro theme color menu items for the demo
        //    //this.ApplicationThemes = ThemeManager.AppThemes
        //    //                               .Select(a => new ApplicationTheme() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
        //    //                               .ToList();

        //    //// create accent colors list
        //    //this.AccentColors = ThemeManager.Accents
        //    //                                .Select(a => new AccentColor() { AccentColorName = a.Name, AccentColorBrush = a.Resources["AccentColorBrush"] as Brush })
        //    //                                .ToList();

        //    this.SelectedTheme = this.ApplicationThemes.FirstOrDefault();
        //    this.SelectedAccentColor = this.AccentColors.Where(c => c.AccentColorName.Equals("Cyan")).FirstOrDefault();


        //}

        //// List of Application Themes
        //private IList<ApplicationTheme> _applicationsThemes;
        //public IList<ApplicationTheme> ApplicationThemes
        //{
        //    get { return _applicationsThemes; }
        //    set { this.SetProperty<IList<ApplicationTheme>>(ref this._applicationsThemes, value); }
        //}


        //// List of Accent Colors
        //private IList<AccentColor> _accentColors;
        //public IList<AccentColor> AccentColors
        //{
        //    get { return _accentColors; }
        //    set { this.SetProperty<IList<AccentColor>>(ref this._accentColors, value); }
        //}


        //// Selected Theme
        //private ApplicationTheme _selectedTheme;
        //public ApplicationTheme SelectedTheme
        //{
        //    get { return _selectedTheme; }
        //    set
        //    {
        //        if (this.SetProperty<ApplicationTheme>(ref this._selectedTheme, value))
        //        {
        //            var theme = ThemeManager.DetectAppStyle(Application.Current);
        //            var appTheme = ThemeManager.GetAppTheme(value.Name);
        //            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);

        //            EventAggregator.GetEvent<StatusBarUpdateEvent>().Publish(String.Format("Theme changed to {0}", value.Name));
        //        }
        //    }
        //}

        //// Selected Accent Color
        //private AccentColor _selectedAccentColor;
        //public AccentColor SelectedAccentColor
        //{
        //    get { return _selectedAccentColor; }
        //    set
        //    {
        //        if (this.SetProperty<AccentColor>(ref this._selectedAccentColor, value))
        //        {
        //            var theme = ThemeManager.DetectAppStyle(Application.Current);
        //            var accent = ThemeManager.GetAccent(value.AccentColorName);
        //            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

        //            EventAggregator.GetEvent<StatusBarUpdateEvent>().Publish(String.Format("Accent color changed to {0}", value.AccentColorName));
        //        }
        //    }
        //}

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }
    }
}
