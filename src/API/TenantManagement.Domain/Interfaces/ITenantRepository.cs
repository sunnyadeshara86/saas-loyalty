using MongoDB.Bson;
using System.Threading.Tasks;
using TenantManagement.Domain.Entities;

namespace TenantManagement.Domain.Interfaces
{
    public interface ITenantRepository
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant> GetByIdAsync(ObjectId id);
        Task<Tenant> GetByNameAsync(string name);
        Task<ObjectId> CreateAsync(Tenant tenant);
        Task<bool> UpdateAsync(Tenant tenant);
        Task DeleteAsync(ObjectId id);
    }
}

