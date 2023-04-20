using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class ElementTypeListModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<ElementType> ElementTypes { get; set; }
        public List<PagesName> PagesName { get; set; }
        public ElementTypeListModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
        public void OnGet()
        {
            PagesName= testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();

        }
    }
}
