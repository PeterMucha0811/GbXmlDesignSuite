using Prism.Mvvm;
using System.Windows;
using System.Windows.Media;

namespace GbXmlDesignSuite.Module.PopupDialog.ViewModels
{
    public class PopupDialogViewModel 
    {
        //private string _message;
        //public string Message
        //{
        //    get { return _message; }
        //    set { SetProperty(ref _message, value); }
        //}

        public override string Title
        {
            get
            {
                return "Module A - Custom Popup";
            }
        }



    }
}

