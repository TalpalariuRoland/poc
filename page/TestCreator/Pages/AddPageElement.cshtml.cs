using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Data;
using TestCreator.Models.Domain;
using TestCreator.Models.ViewModels;

namespace TestCreator.Pages
{
    public class AddPageElementModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<PagesName> Pages { get; set; }
        public List<ElementType> ElementTypes { get; set; }
        [BindProperty]
        public PageElementViewModel PageElement { get; set; }
        public AddPageElementModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
    
        public void OnGet()
        {
            Pages = testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
        }

        public IActionResult OnPost()
        {
            var pageElement = new PageElements
            {
                PageID = PageElement.PageID,
                ElementID = PageElement.ElementID,
            };
            testCreatorDbContext.PageElements.Add(pageElement);
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/PageElementList");
        }

    }
}
