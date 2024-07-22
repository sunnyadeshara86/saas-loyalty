using MongoDB.Bson;

namespace TenantManagement.Domain.Events
{
    public class TenantCreatedEvent : DomainEvent
    {
        public ObjectId TenantId { get; private set; }
        public string TenantName { get; private set; }

        public TenantCreatedEvent(ObjectId tenantId, string tenantName)
        {
            TenantId = tenantId;
            TenantName = tenantName;
        }
    }
}
