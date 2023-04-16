using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class ElementTypeListModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<ElementType> ElementTypes { get; set; }
        public ElementTypeListModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
        public void OnGet()
        {
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
        }
    }
}
