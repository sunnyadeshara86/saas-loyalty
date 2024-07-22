namespace TenantManagement.Domain.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
