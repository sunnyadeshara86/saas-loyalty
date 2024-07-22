using MongoDB.Bson;
using MongoDB.Driver;
using TenantManagement.Application.DTOs;
using TenantManagement.Application.Interfaces;
using TenantManagement.Domain.Entities;
using TenantManagement.Domain.Events;
using TenantManagement.Domain.Interfaces;
using TenantManagement.Infrastructure.Events;

namespace TenantManagement.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public TenantService(ITenantRepository tenantRepository, IEventDispatcher eventDispatcher)
        {
            _tenantRepository = tenantRepository;
            _eventDispatcher = eventDispatcher;
        }

        public async Task<IEnumerable<Tenant>> GetAsync()
        {
            return await _tenantRepository.GetAllAsync();
        }

        public async Task<ObjectId> CreateTenantAsync(TenantDTO tenantDto)
        {
            var tenant = new Tenant(tenantDto.Name, tenantDto.Email); // Assuming Tenant is a domain entity
            await _tenantRepository.CreateAsync(tenant);
            await _eventDispatcher.Dispatch(new TenantCreatedEvent(tenant.Id, tenant.Name));
            return tenant.Id;
        }

        public async Task<TenantDTO> GetTenantByIdAsync(ObjectId id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant == null) return null;
            return new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email
            };
        }

        public async Task<TenantDTO> GetTenantByNameAsync(string name)
        {
            var tenant = await _tenantRepository.GetByNameAsync(name);
            if (tenant == null) return null;
            return new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email
            };
        }

        public async Task<Tenant> UpdateTenantAsync(ObjectId id, Tenant tenant)
        {
            tenant = new Tenant(id, tenant.Name, tenant.Email);

            var filter = Builders<Tenant>.Filter.Eq(t => t.Id, id);
            await _tenantRepository.UpdateAsync(tenant);

            return tenant;
        }

        public async Task<bool> DeleteTenantAsync(ObjectId id)
        {
            var filter = Builders<Tenant>.Filter.Eq(t => t.Id, id);
             await _tenantRepository.DeleteAsync(id);

            return true;
        }
    }
}
