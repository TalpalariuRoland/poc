using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class EditPageNameModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        [BindProperty]
        public PagesName Page { get; set; }

        public EditPageNameModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
        public void OnGet(Guid id)
        {
            Page = testCreatorDbContext.PagesName.Find(id);
            
        }

        public IActionResult OnPostEdit()
        {
            var oldPage = testCreatorDbContext.PagesName.Find(Page.ID);
            oldPage.PageName = Page.PageName;
            testCreatorDbContext.SaveChanges();

            return RedirectToPage("/PageNameList");
        }
        public IActionResult OnPostDelete()
        {
            var oldPage = testCreatorDbContext.PagesName.Find(Page.ID);
            testCreatorDbContext.Remove(oldPage);
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/PageNameList");
        }
    }
}
