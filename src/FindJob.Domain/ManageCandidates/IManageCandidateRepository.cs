using System;
using Volo.Abp.Domain.Repositories;

namespace FindJob.ManageCandidates
{
    public interface IManageCandidateRepository : IRepository<ManageCandidate, Guid>
    {
    }
}