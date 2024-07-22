using MongoDB.Bson;

namespace TenantManagement.Application.DTOs
{
    public class TenantDTO
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
