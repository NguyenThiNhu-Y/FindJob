using System;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.Notifies
{
    public class NotifyRepository : EfCoreRepository<FindJobDbContext, Notify, Guid>, INotifyRepository
    {
        public NotifyRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}