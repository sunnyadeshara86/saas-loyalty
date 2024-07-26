using MongoDB.Bson;

namespace TenantManagement.Domain.Events
{
    public class TenantActivatedEvent : DomainEvent
    {
        public ObjectId TenantId { get; }
        public string TenantName { get; }
        public DateTime ActivationDate { get; }

        public TenantActivatedEvent(ObjectId tenantId, string tenantName, DateTime activationDate)
        {
            TenantId = tenantId;
            TenantName = tenantName;
            ActivationDate = activationDate;
        }
    }
}
