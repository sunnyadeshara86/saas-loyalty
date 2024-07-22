using MediatR;
using MongoDB.Bson;

namespace TenantManagement.Application.Commands
{
    public class CreateTenantCommand : IRequest<ObjectId>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateTenantCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
