using TenantManagement.Domain.Events;

namespace TenantManagement.Application.Events
{
    public class TenantActivatedEventHandler : IEventHandler<TenantActivatedEvent>
    {
        public async Task Handle(TenantActivatedEvent @event)
        {
            // Handle the event (e.g., send notification, log activity)
        }
    }
}
