﻿using System.Collections.Generic;

namespace GbXmlDesignSuite.Core.Services
{
    public class AppSettingsStateService
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
