using Prism.Mvvm;
using Prism.Navigation;

namespace GbXmlDesignSuite.Core.Base
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ViewModelBase()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
