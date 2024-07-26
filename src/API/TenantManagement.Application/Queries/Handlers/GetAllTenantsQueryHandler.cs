using MediatR;
using TenantManagement.Application.DTOs;
using TenantManagement.Application.Interfaces;

namespace TenantManagement.Application.Queries.Handlers
{
    public class GetAllTenantsQueryHandler : IRequestHandler<GetAllTenantsQuery, IEnumerable<TenantDTO>>
    {
        private readonly ITenantService _tenantService;

        public GetAllTenantsQueryHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<IEnumerable<TenantDTO>> Handle(GetAllTenantsQuery request, CancellationToken cancellationToken)
        {
            var tenants = await _tenantService.GetAsync();
            if (tenants == null) return null;

            return tenants.Select(tenant => new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email
            });
        }
    }
}