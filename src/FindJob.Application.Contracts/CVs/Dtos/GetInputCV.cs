using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FindJob.CVs.Dtos
{
    public class GetInputCV : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid? IdField { get; set; }
    }
}
