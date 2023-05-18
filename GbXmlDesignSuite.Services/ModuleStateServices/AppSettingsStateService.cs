using System.Collections.Generic;

namespace GbXmlDesignSuite.Services
{
    public interface IAppSettingsStateService
    {
        void SetModuleState(string moduleName, object state);
        object GetModuleState(string moduleName);
    }


    public class AppSettingsStateService : IAppSettingsStateService
    {
        private Dictionary<string, object> _moduleStates;

        public AppSettingsStateService()
        {
            _moduleStates = new Dictionary<string, object>();
        }

        public void SetModuleState(string moduleName, object state)
        {
            if (_moduleStates.ContainsKey(moduleName))
            {
                _moduleStates[moduleName] = state;
            }
            else
            {
                _moduleStates.Add(moduleName, state);
            }
        }

        public object GetModuleState(string moduleName)
        {
            return _moduleStates.ContainsKey(moduleName) ? _moduleStates[moduleName] : null;
        }
    }
}
