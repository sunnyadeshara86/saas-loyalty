using MediatR;
using MongoDB.Bson;
using TenantManagement.Domain.Entities;

namespace TenantManagement.Application.Commands
{
    public class UpdateTenantCommand : IRequest<Tenant>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
