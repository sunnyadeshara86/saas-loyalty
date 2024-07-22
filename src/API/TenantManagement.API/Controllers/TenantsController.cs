namespace TenantManagement.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using MongoDB.Bson;
    using System.Threading.Tasks;
    using TenantManagement.Application.Commands;
    using TenantManagement.Application.Queries;

    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTenants()
        {
            // Assuming there's a Query and Handler for getting a tenant by ID
            var query = new GetAllTenantsQuery();
            var tenants = await _mediator.Send(query);
            if (tenants == null) return NotFound();
            return Ok(tenants);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTenantById(ObjectId id)
        {
            // Assuming there's a Query and Handler for getting a tenant by ID
            var query = new GetTenantByIdQuery(id);
            var tenant = await _mediator.Send(query);
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTenantByName(string name)
        {
            // Assuming there's a Query and Handler for getting a tenant by ID
            var query = new GetTenantByNameQuery(name);
            var tenant = await _mediator.Send(query);
            if (tenant == null) return NotFound();
            return Ok(tenant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] CreateTenantCommand command)
        {
            var tenantId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTenantById), new { id = tenantId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant(string id, [FromBody] UpdateTenantCommand command)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId) || objectId != command.Id)
            {
                return BadRequest("Invalid ID format or ID mismatch.");
            }

            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound($"Tenant with ID {id} not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ID format.");
            }

            var command = new DeleteTenantCommand { Id = objectId };
            var success = await _mediator.Send(command);
            if (!success)
            {
                return NotFound($"Tenant with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
