namespace GbXmlDesignSuite.Core.Interfaces
{
    public interface IAppSettingsStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }
}
