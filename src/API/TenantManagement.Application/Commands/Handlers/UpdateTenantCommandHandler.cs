using MediatR;
using MongoDB.Bson;
using TenantManagement.Application.Interfaces;
using TenantManagement.Domain.Entities;

namespace TenantManagement.Application.Commands.Handlers
{
    public class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand, Tenant>
    {
        private readonly ITenantService _tenantService;

        public UpdateTenantHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<Tenant> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            // Assuming ITenantService.UpdateTenantAsync is implemented
            return await _tenantService.UpdateTenantAsync(request.Id, new Tenant
            (
                request.Id,
                request.Name,
                request.Email
            ));
        }
    }
}