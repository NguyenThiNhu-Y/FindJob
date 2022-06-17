using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Fields
{
    public interface IFieldRepository : IRepository<Field, Guid>
    {
        Task<List<Field>> GetListFieldAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}