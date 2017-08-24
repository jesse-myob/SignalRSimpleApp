using SignalRDev.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.BusinessLogic.Common
{
    public abstract class SignalRBusinessLogicBase
    {
        protected ICustomObjectMapper _objMapper { get; set; }

        public SignalRBusinessLogicBase(ICustomObjectMapper objMapper)
        {
            _objMapper = objMapper;
        }
    }
}
