using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class PageNameListModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<PagesName> PagesName { get; set; }

        public PageNameListModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }
        public void OnGet()
        {
            PagesName = testCreatorDbContext.PagesName.ToList();
        }
    }
}
