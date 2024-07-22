using MediatR;
using MongoDB.Bson;
using TenantManagement.Application.DTOs;

namespace TenantManagement.Application.Queries
{
    public class GetTenantByIdQuery : IRequest<TenantDTO>
    {
        public ObjectId Id { get; }

        public GetTenantByIdQuery(ObjectId id)
        {
            Id = id;
        }
    }
}