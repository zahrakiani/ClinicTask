using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.ExceptionRules;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }

}
