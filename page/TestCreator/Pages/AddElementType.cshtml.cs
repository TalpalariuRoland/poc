using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Data;
using TestCreator.Models.Domain;
using TestCreator.Models.ViewModels;

namespace TestCreator.Pages
{
    public class AddElementTypeModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        [BindProperty]
        public ElementTypeViewModel AddElementTypeRequest { get; set; }
        public AddElementTypeModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            var elementType = new ElementType
            {
                ElementName = AddElementTypeRequest.ElementName,
                LenghtCount= AddElementTypeRequest.LenghtCount,
            };
            testCreatorDbContext.ElementTypes.Add(elementType);
            testCreatorDbContext.SaveChanges();

            return RedirectToPage("/ElementTypeList");
        }
    }
}
