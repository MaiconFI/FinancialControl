using FinancialControl.Domain.Events;
using System;
using System.Collections.Generic;

namespace FinancialControl.Domain.Base
{
    public abstract class Entity : EntityError
    {
        private List<DomainEvent> _domainEvents;

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public Guid Id { get; }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents ??= new List<DomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void RemoveDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }
    }
}