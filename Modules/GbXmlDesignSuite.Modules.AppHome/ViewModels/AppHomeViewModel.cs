using GbXmlDesignSuite.Core.Events;
using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Services;
using Prism;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace GbXmlDesignSuite.Modules.AppHome.ViewModels
{
    public class AppHomeViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public AppHomeViewModel(IProjectsService projectsService,
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
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

        // Update the Status Bar Method
        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Application Home View");
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
