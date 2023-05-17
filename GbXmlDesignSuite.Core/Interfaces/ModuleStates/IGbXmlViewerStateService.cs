namespace GbXmlDesignSuite.Core.Interfaces
{
    public interface IGbXmlViewerStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }
}
