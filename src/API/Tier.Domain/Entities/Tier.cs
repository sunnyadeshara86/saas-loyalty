using MongoDB.Bson;

namespace SaaSLoyalty.Tier.Domain.Entities
{
    public class Tier
    {
        public ObjectId Id { get; set; }
        public string TenantId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int PointsThreshold { get; set; }
    }
}
