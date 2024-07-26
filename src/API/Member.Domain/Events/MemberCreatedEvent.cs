using MongoDB.Bson;

namespace TenantManagement.Domain.Events
{
    public class MemberCreatedEvent : DomainEvent
    {
        public ObjectId TenantId { get; private set; }
        public ObjectId MemberId { get; private set; }
        public string MemberName { get; private set; }

        public MemberCreatedEvent(ObjectId tenantId, ObjectId memberId, string memberName)
        {
            TenantId = tenantId;
            MemberId = memberId;
            MemberName = memberName;
        }
    }
}
