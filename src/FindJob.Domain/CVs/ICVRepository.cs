using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FindJob.CVs
{
    public interface ICVRepository : IRepository<CV, Guid>
    {
        Task<List<CV>> GetListCVAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null,
            Guid? idField = null
        );
    }
}