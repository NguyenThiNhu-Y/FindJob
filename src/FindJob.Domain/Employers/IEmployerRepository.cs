using System;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Employers
{
    public interface IEmployerRepository : IRepository<Employer, Guid>
    {
    }
}