using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.Employers.Employer.ViewModels
{
    public class CreateEditEmployerViewModel
    {
        [Display(Name = "EmployerIdUser")]
        public Guid IdUser { get; set; }

        [Display(Name = "EmployerCompanyName")]
        public string CompanyName { get; set; }

        [Display(Name = "EmployerAddress")]
        public string Address { get; set; }
    }
}