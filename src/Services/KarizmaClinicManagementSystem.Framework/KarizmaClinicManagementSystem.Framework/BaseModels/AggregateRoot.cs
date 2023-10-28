using KarizmaClinicManagementSystem.Framework.Abstracts;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public abstract class AggregateRoot<TKey> : Entity, IAggregateRoot
{
    public TKey Id { get; protected set; }
}
