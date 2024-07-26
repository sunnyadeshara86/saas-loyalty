using MediatR;
using TenantManagement.Application.DTOs;

namespace TenantManagement.Application.Queries
{
    public class GetTenantByNameQuery : IRequest<TenantDTO>
    {
        public string Name { get; }

        public GetTenantByNameQuery(string name)
        {
            Name = name;
        }
    }
}
