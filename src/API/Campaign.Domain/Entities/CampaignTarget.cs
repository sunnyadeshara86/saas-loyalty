using MongoDB.Bson;

namespace SaaSLoyalty.Campaign.Domain.Entities
{
    public class CampaignTarget
    {
        public ObjectId Id { get; set; }
        public string TenantId { get; set; } = string.Empty;
        public TargetType Type { get; set; }
        public string Value { get; set; } = string.Empty;
        public string Criteria { get; set; } = string.Empty;
    }
}
