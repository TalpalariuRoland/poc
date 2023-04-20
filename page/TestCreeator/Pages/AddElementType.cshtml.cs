using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Models.Domain;
using TestCreator.Models.ViewModels;
using TestCreeator.Data;


namespace TestCreator.Pages
{
    public class AddElementTypeModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        [BindProperty]
        public ElementTypeViewModel AddElementTypeRequest { get; set; }
        public List<PagesName> PagesNames { get; set; }
        public AddElementTypeModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet()
        {
            PagesNames= testCreatorDbContext.PagesName.ToList();
        }

        public IActionResult OnPost()
        {
            var elementType = new ElementType
            {
                ElementName = AddElementTypeRequest.ElementName,
                PageNameID= AddElementTypeRequest.LenghtCount,
            };

        testCreatorDbContext.ElementTypes.Add(elementType);
            testCreatorDbContext.SaveChanges();

            return RedirectToPage("/ElementTypeList");
        }
    }
}
