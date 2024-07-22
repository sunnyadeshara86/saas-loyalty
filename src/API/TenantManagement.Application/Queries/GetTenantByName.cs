using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
