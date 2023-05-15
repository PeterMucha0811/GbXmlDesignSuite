using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GbXmlDesignSuite.Modules.GbXmlViewer.ViewModels.Base
{ 
    //public abstract class BaseViewModel : BindableBase, INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    //    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

    //        storage = value;
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }
    //}
}
