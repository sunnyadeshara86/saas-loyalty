namespace TenantManagement.Domain.Events
{
    public class TenantActivatedEvent : DomainEvent
    {
        public Guid TenantId { get; }
        public string TenantName { get; }
        public DateTime ActivationDate { get; }

        public TenantActivatedEvent(Guid tenantId, string tenantName, DateTime activationDate)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            ActivationDate = activationDate;
        }
    }
}
