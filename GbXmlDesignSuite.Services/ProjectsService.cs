using GbXmlDesignSuite.Core.Models;
using System.Collections.ObjectModel;


namespace GbXmlDesignSuite.Services
{
    public interface IProjectsService
    {
        ObservableCollection<ProjectsModel> Projects { get; set; }
    }

    public class ProjectsService : IProjectsService
    {
        public ObservableCollection<ProjectsModel> Projects { get; set; }

        public ProjectsService()
        {
            // Initialize your ObservableCollection here
            Projects = new ObservableCollection<ProjectsModel>();

            TestingData();
        }


        // // // USED FOR TESTING ONLY // // //
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

    }
}
