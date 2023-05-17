namespace GbXmlDesignSuite.Core.Interfaces
{
    public interface IVentCalcStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }
}
