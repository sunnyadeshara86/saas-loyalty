using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Application.DTOs;
using TenantManagement.Application.Interfaces;

namespace TenantManagement.Application.Queries.Handlers
{
    public class GetTenantByNameQueryHandler : IRequestHandler<GetTenantByNameQuery, TenantDTO>
    {
        private readonly ITenantService _tenantService;

        public GetTenantByNameQueryHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<TenantDTO> Handle(GetTenantByNameQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantService.GetTenantByNameAsync(request.Name);
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
