using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;
using TestCreator.Models.ViewModels;

namespace TestCreator.Pages
{
    public class AddPageNameModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;

        [BindProperty]
        public PagesNameViewModel AddPageRequest { get; set; }

        public AddPageNameModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var pagesName = new PagesName
            {
                PageName =AddPageRequest.PageName,
            };
            testCreatorDbContext.PagesName.Add(pagesName);
            testCreatorDbContext.SaveChanges();

            return RedirectToPage("/PageNameList");
        }
    }
}
