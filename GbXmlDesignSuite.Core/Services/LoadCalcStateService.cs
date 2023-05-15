using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GbXmlDesignSuite.Core.Services
{
    public class LoadCalcStateService
    {
        private Dictionary<string, object> _moduleStates;

        public LoadCalcStateService()
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
