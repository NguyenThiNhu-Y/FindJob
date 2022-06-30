using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Employers
{
    public interface IEmployerRepository : IRepository<Employer, Guid>
    {
        Task<List<Employer>> GetListEmployerAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

        Task<Employer> FindEmployerByIdUser(Guid IdUser);
    }
}