using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FindJob.Notifies.Dtos
{
    public class GetInputNotify : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
