namespace GbXmlDesignSuite.Core.Interfaces
{
    public interface ILoadCalcStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }
}
