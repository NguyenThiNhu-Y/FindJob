using System;
using FindJob.Permissions;
using FindJob.Notifies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Notifies
{
    public class NotifyAppService : CrudAppService<Notify, NotifyDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateNotifyDto, CreateUpdateNotifyDto>,
        INotifyAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.Notify.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.Notify.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.Notify.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.Notify.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.Notify.Delete;

        private readonly INotifyRepository _repository;
        
        public NotifyAppService(INotifyRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
