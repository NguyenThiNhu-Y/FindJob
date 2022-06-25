using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Notifies
{
    public interface INotifyRepository : IRepository<Notify, Guid>
    {
        Task<List<Notify>> GetListNotifyAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}