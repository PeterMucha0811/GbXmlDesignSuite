using Prism.Mvvm;

namespace GbXmlDesignSuite.Modules.ProjectMgmt.ViewModels
{
    public class ProjectDialogViewModel : BindableBase
    {
        private string _firstName;
        private string _lastName;
        private string _mi;
        private string _depart;
        private string _email;

        public ProjectDialogViewModel(string firstName, string lastName, string mi, string depart, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _mi = mi;
            _depart = depart;
            _email = email;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public string MI
        {
            get { return _mi; }
            set { SetProperty(ref _mi, value); }
        }
        public string Depart
        {
            get { return _depart; }
            set { SetProperty(ref _depart, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
    }
}
