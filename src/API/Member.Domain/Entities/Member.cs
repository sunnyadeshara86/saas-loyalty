using MongoDB.Bson;

namespace Member.Domain.Entities
{
    public class Member
    {
        public Member(ObjectId tenantId, string loyaltyNumber, string name, string email,
            string phone, string address, DateTime dateJoined, ObjectId tierId)
        {
            Id = ObjectId.GenerateNewId();
            TenantId = tenantId;
            LoyaltyNumber = loyaltyNumber;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            DateJoined = dateJoined;
            TierId = tierId;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public Member(ObjectId id, ObjectId tenantId, string loyaltyNumber, string name, string email,
            string phone, string address, DateTime dateJoined, ObjectId tierId)
        {
            Id = id;
            TenantId = tenantId;
            LoyaltyNumber = loyaltyNumber;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            DateJoined = dateJoined;
            TierId = tierId;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public ObjectId Id { get; set; }
        public ObjectId TenantId { get; set; }
        public string LoyaltyNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }
        public ObjectId TierId { get; set; }
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