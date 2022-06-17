using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.Fields.Field.ViewModels
{
    public class CreateEditFieldViewModel
    {
        [Display(Name = "FieldName")]
        public string Name { get; set; }

        [Display(Name = "FieldIdParentField")]
        public Guid? IdParentField { get; set; }
    }
}