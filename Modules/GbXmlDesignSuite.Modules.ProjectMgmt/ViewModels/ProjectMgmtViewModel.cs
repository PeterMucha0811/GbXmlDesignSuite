using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GbXmlDesignSuite.Core.Models;
using System.Windows.Media.Effects;
using System.Windows;
using Prism.Ioc;
using Prism.Services.Dialogs;
using Prism;
using GbXmlDesignSuite.Modules.ProjectMgmt.Views.Dialogs;
using GbXmlDesignSuite.Core.Events;
using GbXmlDesignSuite.Services;

namespace GbXmlDesignSuite.Modules.ProjectMgmt.ViewModels
{
    public class ProjectMgmtViewModel : BindableBase, IActiveAware
    {
        private readonly IProjectMgmtStateService _projectMgmtStateService;
        private readonly IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public ProjectMgmtViewModel(IProjectMgmtStateService projectStateService,
            IProjectsService projectsService,
            IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
            _projectMgmtStateService = projectStateService;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _containerProvider = containerProvider;

            Projects = projectsService.Projects;


            AddEmployeeCommand = new DelegateCommand(async () => await AddEmployeeAsync());



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
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Project Managment View");
        }


        #region Commands

        public DelegateCommand<ProjectsModel> SetActiveProjectCommand =>
            new DelegateCommand<ProjectsModel>(SetActiveProject);

        public DelegateCommand DeleteProjectCommand =>
            new DelegateCommand(DeleteProject, () =>
            CanDeleteModify).ObservesProperty(() => CanDeleteModify);

        public DelegateCommand ModifyProjectCommand =>
            new DelegateCommand(ModifyProject, () =>
            CanDeleteModify).ObservesProperty(() => CanDeleteModify);

        public DelegateCommand UpdateGbXmlFileCommand =>
            new DelegateCommand(UpdateGbXmlFile);


        public DelegateCommand AddNewProjectCommand =>
            new DelegateCommand(AddNewProject);


        public DelegateCommand AddEmployeeCommand { get; private set; }
        #endregion


        private async Task AddEmployeeAsync()
        {
            var dialogService = _containerProvider.Resolve<IDialogService>();
            var dialog = _containerProvider.Resolve<ProjectDialog>();

            await ShowPopup(dialog);

            // Your logic after closing the dialog, if any
        }

        private Task ShowPopup<TPopup>(TPopup popup)
        where TPopup : Window
        {
            var task = new TaskCompletionSource<object>();
            popup.Owner = Application.Current.MainWindow;
            popup.Closed += (s, a) =>
            {
                Application.Current.MainWindow.Effect = null;
                task.SetResult(null);
            };

            Application.Current.MainWindow.Effect = new BlurEffect();
            popup.ShowDialog();

            return task.Task;
        }




        private ProjectsModel _selectedProject;
        public ProjectsModel SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                SetProperty(ref _selectedProject, value);
                CanDeleteModify = _selectedProject != null;
            }
        }


        private bool _canDeleteModify;
        public bool CanDeleteModify
        {
            get { return _canDeleteModify; }
            set { SetProperty(ref _canDeleteModify, value); }
        }


        private void SetActiveProject(ProjectsModel project)
        {
            
            
            // Implement your logic for setting the active project
        }

        private void DeleteProject()
        {
            // Implement your logic for deleting the selected project
            if (SelectedProject != null)
            {
                Projects.Remove(SelectedProject);
            }
        }

        private void ModifyProject()
        {
            // Implement your logic for modifying the selected project
            if (SelectedProject != null)
            {
                SelectedProject.IsEditable = !SelectedProject.IsEditable;
                RaisePropertyChanged(nameof(SelectedProject.IsEditable));
            }
        }

        private void UpdateGbXmlFile()
        {
            // Implement your logic for updating the gbXML file
        }

        private void AddNewProject()
        {
            // Implement your logic for adding a new project

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

                //// Load state when the module becomes active
                //var state = _projectMgmtStateService.GetModuleState("ProjectMgmt");
                //if (state != null)
                //{
                //    // Restore the state (e.g. Projects collection)
                //    Projects = state as ObservableCollection<ProjectsModel>;
                //}
            }
            else
            {
                // Save state when the module becomes inactive
                //_projectMgmtStateService.SetModuleState("ProjectMgmt", Projects);
            }
        }

        //// Update the state in the shared service when changes are made
        //public void UpdateProjectState()
        //{
        //    _projectMgmtStateService.SetModuleState("ProjectMgmt", Projects);
        //}


        
    }
}