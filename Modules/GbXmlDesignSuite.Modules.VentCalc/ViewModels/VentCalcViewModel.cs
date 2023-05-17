using Prism.Regions;
using Prism.Mvvm;
using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Core.Services;
using Prism.Events;
using Prism;
using System.Collections.ObjectModel;
using System;
using Prism.Ioc;
using Prism.Services.Dialogs;
using GbXmlDesignSuite.Core.Interfaces;
using GbXmlDesignSuite.Core.Events;

namespace GbXmlDesignSuite.Modules.VentCalc.ViewModels
{
    public class VentCalcViewModel : BindableBase, IActiveAware
    {
        private readonly IVentCalcStateService _ventCalcStateService;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public VentCalcViewModel(IVentCalcStateService ventCalcStateService,
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
            _ventCalcStateService = ventCalcStateService;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _containerProvider = containerProvider;
        }

        // Update the Status Bar Method
        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Ventilation Calculations View");
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
                var state = _ventCalcStateService.GetModuleState("VentCalc");
                if (state != null)
                {
                    // Restore the state (e.g. Projects collection)
                    Projects = state as ObservableCollection<ProjectsModel>;
                }
            }
            else
            {
                // Save state when the module becomes inactive
                _ventCalcStateService.SetModuleState("VentCalc", Projects);
            }
        }


        // Update the state in the shared service when changes are made
        public void UpdateProjectState()
        {
            _ventCalcStateService.SetModuleState("VentCalc", Projects);
        }
    }
}
