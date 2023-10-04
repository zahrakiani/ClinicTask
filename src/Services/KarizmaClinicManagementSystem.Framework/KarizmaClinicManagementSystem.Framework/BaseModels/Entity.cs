using KarizmaClinicManagementSystem.Framework.Abstracts;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public abstract class Entity<TKey>
{
    public TKey Id { get; protected set; }
    private List<IDomainEvent> domainEvents;

    //p1.Equals(p2)
    public override bool Equals(object obj)
    {
        var entity = obj as Entity<TKey>;
        return entity != null &&
            GetType() == entity.GetType() &&
            EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
    }

    public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Id);
    }
    

    /// <summary>
    /// Domain events occurred.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents?.AsReadOnly();

    public void ClearDomainEvents()
    {
        domainEvents?.Clear();
    }

    /// <summary>
    /// Add domain event.
    /// </summary>
    /// <param name="domainEvent">Domain event.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents ??= new List<IDomainEvent>();

        domainEvents.Add(domainEvent);
    }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
