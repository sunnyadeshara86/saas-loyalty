using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Application.DTOs;
using TenantManagement.Application.Interfaces;

namespace TenantManagement.Application.Commands.Handlers
{
    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, ObjectId>
    {
        private readonly ITenantService _tenantService;

        public CreateTenantCommandHandler(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public async Task<ObjectId> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenantDto = new TenantDTO
            {
                Name = request.Name,
                Email = request.Email
                // Map other properties as needed
            };

            return await _tenantService.CreateTenantAsync(tenantDto);
        }
    }
}
