﻿using GbXmlDesignSuite.Core.Events;
using GbXmlDesignSuite.Modules.AppSettings.Models;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System;

namespace GbXmlDesignSuite.Shell.ViewModels
{
    public class ShellSettingsFlyoutViewModel : BindableBase
    {

        //public ShellSettingsFlyoutViewModel()
        //{
        //    //    // create metro theme color menu items for the demo
        //    this.ApplicationThemes = ThemeManager.AppThemes
        //                                   .Select(a => new ApplicationTheme() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
        //                                   .ToList();

        //    // create accent colors list
        //    this.AccentColors = ThemeManager.Accents
        //                                    .Select(a => new AccentColor() { AccentColorName = a.Name, AccentColorBrush = a.Resources["AccentColorBrush"] as Brush })
        //                                    .ToList();

        //    this.SelectedTheme = this.ApplicationThemes.FirstOrDefault();
        //    this.SelectedAccentColor = this.AccentColors.Where(c => c.AccentColorName.Equals("Cyan")).FirstOrDefault();

        //}




        //#region Properties

        //private IList<ApplicationTheme> applicationsThemes;

        ///// <summary>
        ///// List with application themes
        ///// </summary>
        //public IList<ApplicationTheme> ApplicationThemes
        //{
        //    get { return applicationsThemes; }
        //    set { this.SetProperty<IList<ApplicationTheme>>(ref this.applicationsThemes, value); }
        //}

        //private IList<AccentColor> accentColors;

        ///// <summary>
        ///// List with accent colors
        ///// </summary>
        //public IList<AccentColor> AccentColors
        //{
        //    get { return accentColors; }
        //    set { this.SetProperty<IList<AccentColor>>(ref this.accentColors, value); }
        //}

        //private ApplicationTheme selectedTheme;

        ///// <summary>
        ///// The selected theme
        ///// </summary>
        //public ApplicationTheme SelectedTheme
        //{
        //    get { return selectedTheme; }
        //    set
        //    {
        //        if (this.SetProperty<ApplicationTheme>(ref this.selectedTheme, value))
        //        {
        //            var theme = ThemeManager.DetectAppStyle(Application.Current);
        //            var appTheme = ThemeManager.GetAppTheme(value.Name);
        //            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);

        //            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(String.Format("Theme changed to {0}", value.Name));
        //        }
        //    }
        //}

        //private AccentColor selectedAccentColor;

        ///// <summary>
        ///// Selected accent color
        ///// </summary>
        //public AccentColor SelectedAccentColor
        //{
        //    get { return selectedAccentColor; }
        //    set
        //    {
        //        if (this.SetProperty<AccentColor>(ref this.selectedAccentColor, value))
        //        {
        //            var theme = ThemeManager.DetectAppStyle(Application.Current);
        //            var accent = ThemeManager.GetAccent(value.Name);
        //            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);

        //            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Publish(String.Format("Accent color changed to {0}", value.Name));
        //        }
        //    }
        //}
        public ShellSettingsFlyoutViewModel()
        {
        }
    }
}