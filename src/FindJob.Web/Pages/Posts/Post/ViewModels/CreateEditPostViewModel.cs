using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.Posts.Post.ViewModels
{
    public class CreateEditPostViewModel
    {
        [Display(Name = "PostContent")]
        public string Content { get; set; }

        [Display(Name = "PostStatus")]
        public bool Status { get; set; }

        [Display(Name = "PostIdUser")]
        public Guid IdUser { get; set; }

        [Display(Name = "PostIdField")]
        public Guid IdField { get; set; }

        [Display(Name = "PostFileName")]
        public string FileName { get; set; }
    }
}