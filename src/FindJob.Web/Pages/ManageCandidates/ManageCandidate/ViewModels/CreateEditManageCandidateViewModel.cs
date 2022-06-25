using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.ManageCandidates.ManageCandidate.ViewModels
{
    public class CreateEditManageCandidateViewModel
    {
        [Display(Name = "ManageCandidateIdCV")]
        public Guid IdCV { get; set; }

        [Display(Name = "ManageCandidateIdEmployer")]
        public Guid IdEmployer { get; set; }

        [Display(Name = "ManageCandidateStatus")]
        public bool Status { get; set; }
    }
}