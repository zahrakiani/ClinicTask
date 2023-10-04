using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.ExceptionRules;

public class BusinessRuleValidationException : Exception
{
    public IBusinessRule BrokenRule { get; }

    public string Code { get; set; }
    public string Message { get; set; }

    public BusinessRuleValidationException(IBusinessRule brokenRule)
    : this(brokenRule.Message, brokenRule.Code)
    {
        BrokenRule = brokenRule;
        this.Message = brokenRule.Message;
        this.Code = brokenRule.Code;
    }
    public BusinessRuleValidationException(ErrorCode errorCode)
            : this(errorCode.Message, errorCode.Code)
        {

        }
    public BusinessRuleValidationException(string message, string code) : base(message)
    {
        Code = code;
    }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: ( {BrokenRule.Code} ) {BrokenRule.Message}";
    }
}
