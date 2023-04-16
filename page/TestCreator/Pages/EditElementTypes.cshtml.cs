using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class EditElementTypesModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        [BindProperty]
        public ElementType ElementType { get; set; }
        public EditElementTypesModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet(Guid ID)
        {
            ElementType = testCreatorDbContext.ElementTypes.Find(ID);
        }

        public IActionResult OnPostEdit()
        {
            var oldElementType = testCreatorDbContext.ElementTypes.Find(ElementType.ID);
            oldElementType.ElementName = ElementType.ElementName;
            oldElementType.LenghtCount = ElementType.LenghtCount;
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/ElementTypeList");
        }

        public IActionResult OnPostDelete()
        {
            var oldElementType = testCreatorDbContext.ElementTypes.Find(ElementType.ID);
            testCreatorDbContext.Remove(oldElementType);
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/ElementTypeList");
        }


    }
}
