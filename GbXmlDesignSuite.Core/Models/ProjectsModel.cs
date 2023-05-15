using Prism.Mvvm;

namespace GbXmlDesignSuite.Core.Models
{
    public class ProjectsModel : BindableBase
    {
        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectDescription { get; set; }

        private bool _isEditable;
        public bool IsEditable
        {
            get { return _isEditable; }
            set { SetProperty(ref _isEditable, value); }
        }
    }
}
