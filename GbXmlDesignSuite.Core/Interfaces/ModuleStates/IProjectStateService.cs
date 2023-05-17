namespace GbXmlDesignSuite.Core.Interfaces
{
    public interface IProjectStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }
}
