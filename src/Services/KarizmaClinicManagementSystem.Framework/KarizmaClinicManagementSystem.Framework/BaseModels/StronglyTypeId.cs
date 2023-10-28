using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public abstract class StronglyTypedId<T> : ValueObject<StronglyTypedId<T>>
{
    private Guid _id;

    public Guid Value
    {
        get { return _id; }
        private set
        {
            if (value == Guid.Empty)
                throw new BusinessRuleException("A valid id must be provided.");

            _id = value;
        }
    }

    public StronglyTypedId(Guid value)
    {
        Value = value;
    }

}
