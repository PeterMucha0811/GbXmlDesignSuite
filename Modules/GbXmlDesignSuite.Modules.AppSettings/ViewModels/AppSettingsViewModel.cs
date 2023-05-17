using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Core.Services;
using Prism.Events;
using Prism;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Regions;
using System;
using Prism.Ioc;
using Prism.Services.Dialogs;
using GbXmlDesignSuite.Core.Interfaces;
using GbXmlDesignSuite.Core.Events;

namespace GbXmlDesignSuite.Modules.AppSettings.ViewModels
{
    public class AppSettingsViewModel : BindableBase, IActiveAware
    {
        private readonly IAppSettingsStateService _appSettingsStateService;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public AppSettingsViewModel(IAppSettingsStateService appSettingsStateService,
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
        }

        // Update the Status Bar Method
        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("App Settings View");
        }


        private ObservableCollection<ProjectsModel> _projects;
        public ObservableCollection<ProjectsModel> Projects
        {
            get { return _projects; }
            set { SetProperty(ref _projects, value); }
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

                // Load state when the module becomes active
                var state = _appSettingsStateService.GetModuleState("AppSettings");
                if (state != null)
                {
                    // Restore the state (e.g. Projects collection)
                    Projects = state as ObservableCollection<ProjectsModel>;
                }
            }
            else
            {
                // Save state when the module becomes inactive
                _appSettingsStateService.SetModuleState("AppSettings", Projects);
            }
        }


        // Update the state in the shared service when changes are made
        public void UpdateProjectState()
        {
            _appSettingsStateService.SetModuleState("AppSettings", Projects);
        }
    }
}
