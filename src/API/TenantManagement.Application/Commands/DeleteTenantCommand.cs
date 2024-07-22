using MediatR;
using MongoDB.Bson;

namespace TenantManagement.Application.Commands
{
    public class DeleteTenantCommand : IRequest<bool>
    {
        public ObjectId Id { get; set; }
    }

}
