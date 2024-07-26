using MongoDB.Bson;

namespace TenantManagement.Domain.Entities
{
    public class Tenant
    {
        public Tenant(string name, string email)
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public Tenant(ObjectId id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
