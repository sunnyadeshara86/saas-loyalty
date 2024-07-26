using MongoDB.Bson;

namespace Member.Domain.Entities
{
    public class Referral
    {
        public ObjectId Id { get; set; }
        public ObjectId TenantId { get; set; }
        public int ReferrerMemberId { get; set; }
        public int ReferredMemberId { get; set; }
        public DateTime ReferralDate { get; set; }
        public ReferralStatus Status { get; set; }
        public int RewardPoints { get; set; }
    }

}
