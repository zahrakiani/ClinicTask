using KarizmaClinicManagementSystem.Framework.Abstracts;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{

}
