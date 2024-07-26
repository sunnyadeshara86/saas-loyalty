using MongoDB.Bson;

namespace SaaSLoyalty.Campaign.Domain.Entities
{
    public class CampaignAction
    {
        public ObjectId Id { get; set; }
        public string TenantId { get; set; } = string.Empty;
        public CampaignActionType Type { get; set; }
        public string Details { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
