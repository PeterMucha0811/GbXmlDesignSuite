﻿using GbXmlDesignSuite.Core.Models;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Regions;
using System;
using Prism.Ioc;
using Prism.Services.Dialogs;
using GbXmlDesignSuite.Core.Events;
using GbXmlDesignSuite.Services;

namespace GbXmlDesignSuite.Modules.AppSettings.ViewModels
{
    public class AppSettingsViewModel : BindableBase
    {
        private readonly IAppSettingsStateService _appSettingsStateService;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public AppSettingsViewModel(IAppSettingsStateService appSettingsStateService,
            IProjectsService projectsService,
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
            _appSettingsStateService = appSettingsStateService;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _containerProvider = containerProvider;

            Projects = projectsService.Projects;
        }

        private ObservableCollection<ProjectsModel> _projects;
        public ObservableCollection<ProjectsModel> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
        }


        // Method: Update Status Bar
        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("App Settings View");
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                OnIsActiveChanged();
            }
        }

        public event EventHandler IsActiveChanged;

        private void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                // Update the Status Bar
                UpdateStatusBarMethod();
            }
        }
    }
}
