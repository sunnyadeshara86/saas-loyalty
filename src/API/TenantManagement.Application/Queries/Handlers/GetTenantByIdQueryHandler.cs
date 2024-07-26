using MediatR;
using TenantManagement.Application.DTOs;
using TenantManagement.Application.Interfaces;

namespace TenantManagement.Application.Queries.Handlers
{
    public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, TenantDTO>
    {
        private readonly ITenantService _tenantService;

        public GetTenantByIdQueryHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<TenantDTO> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantService.GetTenantByIdAsync(request.Id);
            if (tenant == null) return null;

            return new TenantDTO
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Email = tenant.Email
            };
        }
    }
}
