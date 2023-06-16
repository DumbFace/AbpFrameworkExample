using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using static Acme.BookStore.Web.Helpers.Enum.Enum;

namespace Acme.BookStore.Web.ViewModel
{
    public class TestViewModel
    {
        [Required(ErrorMessage = "Bạn vui lòng nhập tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn vui lòng nhập mô tả")]
        public string Description { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Genre Sex { get; set; }
    }
}