﻿using Prism.Regions;
using Prism.Mvvm;
using Prism.Events;
using Prism;
using System;
using Prism.Ioc;
using Prism.Services.Dialogs;
using GbXmlDesignSuite.Core.Events;
using GbXmlDesignSuite.Services;


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
            IProjectsService projectsService,
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
