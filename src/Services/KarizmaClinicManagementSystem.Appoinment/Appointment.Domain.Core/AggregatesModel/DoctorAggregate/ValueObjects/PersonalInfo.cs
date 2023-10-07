using KarizmaClinicManagementSystem.Framework.BaseModels;

namespace Appointment.Domain.Core.AggregatesModel.DoctorAggregate.ValueObjects;

public class PersonalInfo : ValueObject<PersonalInfo>
{
    private PersonalInfo(string prefix, string firstName, string lastName)
    {
        Prefix = prefix;
        FirstName = firstName;
        LastName = lastName;
    }

    public string? Prefix { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;

    public override string ToString()
    {
        return Prefix + "" + FirstName + "" + LastName;
    }
    public static PersonalInfo CreateNew(string prefix, string firstName, string LastName)
    {
        return new PersonalInfo(prefix,firstName,LastName);
    }
}