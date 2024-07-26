using MongoDB.Bson;

namespace TenantManagement.Domain.Events
{
    public class MemberActivatedEvent : DomainEvent
    {
        public ObjectId TenantId { get; private set; }
        public ObjectId MemberId { get; private set; }
        public string MemberName { get; private set; }
        public DateTime ActivationDate { get; }

        public MemberActivatedEvent(ObjectId tenantId, ObjectId memberId, string memberName, DateTime activationDate)
        {
            TenantId = tenantId;
            MemberId = memberId;
            MemberName = memberName;
            ActivationDate = activationDate;
        }
    }
}
