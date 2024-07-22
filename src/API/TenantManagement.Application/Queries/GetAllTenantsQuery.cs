using MediatR;
using TenantManagement.Application.DTOs;

namespace TenantManagement.Application.Queries
{
    public class GetAllTenantsQuery : IRequest<IEnumerable<TenantDTO>>
    {
    }
}
