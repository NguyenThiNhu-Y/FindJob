using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace FindJob.Fields.Dtos
{
    public class GetInputField : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
