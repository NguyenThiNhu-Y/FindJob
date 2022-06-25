using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.Employers.Employer.ViewModels
{
    public class CreateEditEmployerViewModel
    {
        [Display(Name = "EmployerIdUser")]
        public Guid IdUser { get; set; }
    }
}