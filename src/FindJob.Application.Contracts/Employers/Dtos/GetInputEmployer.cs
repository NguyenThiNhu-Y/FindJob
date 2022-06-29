using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FindJob.Employers.Dtos
{
    public class GetInputEmployer : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
