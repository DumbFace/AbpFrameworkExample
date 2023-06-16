using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Acme.BookStore.Web.ViewModel;

namespace Acme.BookStore.Web.Pages
{
    public class CreateTestModel : PageModel
    {
        [BindProperty]
        public TestViewModel Test { get; set; }

        public void OnGet()
        {
            Test = new TestViewModel();
        }

        public async Task OnPostAsync()
        {
            //Post
        }
    }
}