using GbXmlDesignSuite.Core.Interfaces;
using Prism.Common;
using Prism.Mvvm;
using System;

namespace GbXmlDesignSuite.Core.Services
{
    public class NavigationService : BindableBase, INavigationService
    {
        //private readonly Func<Type, ViewModel> _viewModelFactory;
        //private ViewModel _currentView;

        ///// <summary>
        ///// Gets the currently active ViewModel.
        ///// </summary>
        //public ViewModel CurrentView
        //{
        //    get => _currentView;
        //    private set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged();
        //    }
        //}

        ///// <summary>
        ///// Initializes a new instance of the NavigationService class with the specified ViewModel factory.
        ///// </summary>
        ///// <param name="viewModelFactory">A factory function that creates ViewModels based on their Type.</param>
        //public NavigationService(Func<Type, ViewModel> viewModelFactory)
        //{
        //    _viewModelFactory = viewModelFactory;
        //}

        ///// <summary>
        ///// Navigates to the specified ViewModel type by creating and setting the CurrentView property.
        ///// </summary>
        ///// <typeparam name="TViewModel">The type of ViewModel to navigate to.</typeparam>
        //public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        //{
        //    ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        //    CurrentView = viewModel;
        //}
    }
}
