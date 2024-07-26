using MongoDB.Bson;

namespace SaaSLoyalty.Campaign.Domain.Entities
{
    public class Campaign
    {
        public ObjectId Id { get; set; }
        public string TenantId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CampaignType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CampaignTarget> Targets { get; set; } = new List<CampaignTarget>();
        public List<CampaignAction> Actions { get; set; } = new List<CampaignAction>();
        public CampaignStatus Status { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
