using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class PageElementListModel : PageModel
    {
        public readonly TestCreatorDbContext testCreatorDbContext;
        public List<PagesName> Pages { get; set; }
        public List<ElementType> ElementTypes { get; set; }
        public List<PageElements> PageElements { get; set; }
        public PageElementListModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
    
        public void OnGet()
        {
            PageElements=testCreatorDbContext.PageElements.ToList();
            Pages=testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
        }
    }
}
