using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GbXmlDesignSuite.Core.Models;
using Prism;
using System.Windows.Media.Effects;
using System.Windows;

namespace GbXmlDesignSuite.Modules.ProjectMgmt.ViewModels
{
    public class ProjectMgmtViewModel : BindableBase, IActiveAware
    {




        #region Fields
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        #endregion


        #region Properties
        public ProjectMgmtViewModel(IRegionManager regionManager,
        IEventAggregator eventAggregator)

        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;


            AddEmployeeCommand = new DelegateCommand(async () => await AddEmployeeAsync());

            // // TESTING ONLY // //
            if (Projects == null)
            {
                Projects = new ObservableCollection<ProjectsModel>();

                TestingData();
            }
        }

        #endregion


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

        }

        // Update the state in the shared service when changes are made
        public void UpdateProjectState()
        {
           
        }


        // // TESTING ONLY // //
        private void TestingData()
        {
            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 1",
                ProjectNumber = "00001",
                ProjectDescription = "This is a 1st test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 2",
                ProjectNumber = "00002",
                ProjectDescription = "This is a 2nd test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 3",
                ProjectNumber = "00003",
                ProjectDescription = "This is a 3rd test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 4",
                ProjectNumber = "00004",
                ProjectDescription = "This is a 4th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 5",
                ProjectNumber = "00005",
                ProjectDescription = "This is a 5th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 6",
                ProjectNumber = "00006",
                ProjectDescription = "This is a 6th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 7",
                ProjectNumber = "00007",
                ProjectDescription = "This is a 7th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 8",
                ProjectNumber = "00008",
                ProjectDescription = "This is a 8th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 9",
                ProjectNumber = "00009",
                ProjectDescription = "This is a 9th test project"
            });

            Projects.Add(new ProjectsModel
            {
                ProjectName = "Project 10",
                ProjectNumber = "00010",
                ProjectDescription = "This is a 10th test project"
            });


        }

























        //private readonly IEventAggregator _eventAggregator;

        //public DelegateCommand<ProjectsModel> SetActiveProjectCommand { get; private set; }



        //private string _message;
        //public string Message
        //{
        //    get { return _message; }
        //    set { SetProperty(ref _message, value); }
        //}

        //private ObservableCollection<ProjectsModel> _projects;
        //public ObservableCollection<ProjectsModel> Projects
        //{
        //    get { return _projects; }
        //    set { SetProperty(ref _projects, value); }
        //}

        //public ProjectMgmtViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) 
        //{


        //    _eventAggregator = eventAggregator;
        //    SetActiveProjectCommand = new DelegateCommand<ProjectsModel>(SetActiveProject);


        //    //do something
        //    Projects = new ObservableCollection<ProjectsModel>();
        //    Projects.Add(new ProjectsModel() { ProjectName = "Project1", ProjectNumber = "1" });
        //    Projects.Add(new ProjectsModel() { ProjectName = "Project2", ProjectNumber = "2" });
        //}



        //private void SetActiveProject(ProjectsModel project)
        //{

        //    //_eventAggregator.GetEvent<Events>().Publish(project);
        //}



    }
}
