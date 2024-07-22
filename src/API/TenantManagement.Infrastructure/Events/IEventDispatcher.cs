using TenantManagement.Domain.Events;

namespace TenantManagement.Infrastructure.Events
{
    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
