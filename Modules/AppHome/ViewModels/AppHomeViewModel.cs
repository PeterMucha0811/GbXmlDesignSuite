using GbXmlDesignSuite.Core.Models;
using GbXmlDesignSuite.Core.Services;
using Prism.Events;
using Prism;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Regions;
using System;
using Prism.Ioc;
using Prism.Services.Dialogs;
using GbXmlDesignSuite.Core.Interfaces;
using GbXmlDesignSuite.Core.Events;

namespace GbXmlDesignSuite.Modules.AppHome.ViewModels
{
    public class AppHomeViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public AppHomeViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
