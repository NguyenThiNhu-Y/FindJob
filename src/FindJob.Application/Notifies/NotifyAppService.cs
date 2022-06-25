using System;
using FindJob.Permissions;
using FindJob.Notifies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using FindJob.Fields;
using FindJob.Posts;
using Volo.Abp.Domain.Repositories;
using FindJob.CVs;

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
        private readonly IFieldRepository _fieldRepository;
        private readonly ICVRepository _cvRepository;


        public NotifyAppService(
            INotifyRepository repository, 
            IFieldRepository fieldRepository,
            ICVRepository cvRepository) : base(repository)
        {
            _repository = repository;
            _fieldRepository = fieldRepository;
            _cvRepository = cvRepository;
        }

        public async Task<PagedResultDto<NotifyDto>> GetListNotifyAsync(GetInputNotify input)
        {
            var notifies = await _repository.GetListNotifyAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            List<NotifyDto> notifiesDto = new List<NotifyDto>();

            foreach (var item in notifies)
            {
                NotifyDto notify = new NotifyDto();
                notify.Id = item.Id;
                notify.Content = item.Content;
                notify.IdCV = item.IdCV;
                notify.Status = item.Status;
                var IdField = (await _cvRepository.FindAsync(item.IdCV)).IdField;
                if (IdField != Guid.Empty)
                {
                    notify.FieldName = (await _fieldRepository.FindAsync((Guid)IdField)).Name;
                }
                else
                {
                    notify.FieldName = "";
                }

                notifiesDto.Add(notify);


            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    notify => notify.Content.Contains(input.Filter));

            return new PagedResultDto<NotifyDto>(
                totalCount,
                notifiesDto
            );
        }
    }
}
