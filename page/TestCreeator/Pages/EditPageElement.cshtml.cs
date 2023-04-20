using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class EditPageElementModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<PagesName> Pages { get; set; }
        public List<ElementType> ElementTypes { get; set; }
        [BindProperty]
        public PageElements pageElements { get; set; }
        public EditPageElementModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet(Guid ID)
        {
            pageElements = testCreatorDbContext.PageElements.Find(ID);
            Pages = testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
        }

        public IActionResult OnPostEdit()
        {
            var oldPageElement = testCreatorDbContext.PageElements.Find(pageElements.ID);
            oldPageElement.ElementTypeID = pageElements.ElementTypeID;
            oldPageElement.PageNameID=pageElements.PageNameID;
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/PageElementList");
        }

        public IActionResult OnPostDelete()
        {
            var oldPageElement = testCreatorDbContext.PageElements.Find(pageElements.ID);
            testCreatorDbContext.Remove(oldPageElement);
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/PageElementList");
        }
    }
}
