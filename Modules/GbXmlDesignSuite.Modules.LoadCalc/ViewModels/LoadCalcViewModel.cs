using GbXmlDesignSuite.Core;
using Prism.Regions;
using Prism.Mvvm;
using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Core.Services;
using Prism.Events;
using Prism;
using System.Collections.ObjectModel;
using System;

namespace GbXmlDesignSuite.Modules.LoadCalc.ViewModels
{
    public class LoadCalcViewModel : BindableBase, IActiveAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly ProjectStateService _projectStateService;

        public LoadCalcViewModel(IRegionManager regionManager,
        IEventAggregator eventAggregator,
        ProjectStateService projectStateService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _projectStateService = projectStateService;
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
                // Load state when the module becomes active
                var state = _projectStateService.GetModuleState("LoadCalc");
                if (state != null)
                {
                    // Restore the state (e.g. Projects collection)
                    Projects = state as ObservableCollection<ProjectsModel>;

                }
            }
            else
            {
                // Save state when the module becomes inactive
                _projectStateService.SetModuleState("LoadCalc", Projects);
            }
        }


        // Update the state in the shared service when changes are made
        public void UpdateProjectState()
        {
            _projectStateService.SetModuleState("LoadCalc", Projects);
        }
    }
}
