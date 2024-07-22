using MediatR;
using TenantManagement.Application.Interfaces;

namespace TenantManagement.Application.Commands.Handlers
{
    public class DeleteTenantHandler : IRequestHandler<DeleteTenantCommand, bool>
    {
        private readonly ITenantService _tenantService;

        public DeleteTenantHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<bool> Handle(DeleteTenantCommand request, CancellationToken cancellationToken)
        {
            // Assuming ITenantService.DeleteTenantAsync is implemented
            return await _tenantService.DeleteTenantAsync(request.Id);
        }
    }
}