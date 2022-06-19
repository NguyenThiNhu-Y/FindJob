using System;
using Volo.Abp.Domain.Repositories;

namespace FindJob.CVs
{
    public interface ICVRepository : IRepository<CV, Guid>
    {
    }
}