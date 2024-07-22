using MongoDB.Bson;
using TenantManagement.Application.DTOs;
using TenantManagement.Domain.Entities;

namespace TenantManagement.Application.Interfaces
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAsync();
        Task<ObjectId> CreateTenantAsync(TenantDTO tenantDto);
        Task<TenantDTO> GetTenantByIdAsync(ObjectId id);
        Task<TenantDTO> GetTenantByNameAsync(string name);
        Task<Tenant> UpdateTenantAsync(ObjectId id, Tenant tenant);
        Task<bool> DeleteTenantAsync(ObjectId id);
    }
}
