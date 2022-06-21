using System;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Notifies
{
    public interface INotifyRepository : IRepository<Notify, Guid>
    {
    }
}