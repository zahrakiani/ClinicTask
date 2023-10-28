using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public interface IBusinessRule
{
    string Code { get; }
    string Message { get; }
    bool IsBroken();
}
