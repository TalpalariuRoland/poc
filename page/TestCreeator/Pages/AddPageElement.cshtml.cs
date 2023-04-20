using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreeator.Data;
using TestCreator.Models.Domain;
using TestCreator.Models.ViewModels;

namespace TestCreator.Pages
{
    public class AddPageElementModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public string PageNm;
        public List<PagesName> Pages { get; set; }
        public List<ElementType> ElementTypes { get; set; }
        public List<PageElements> Elements { get; set; }
        [BindProperty]
        public PageElementViewModel PageElement { get; set; }
        public AddPageElementModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet()
        {
            this.start();
        }

        private void start()
        {
            PageNm = null;
            Pages = testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
            Elements = testCreatorDbContext.PageElements.ToList();
            if (Elements.Count != 0)
            {
                foreach (var ele in Pages)
                {
                    if (ele.ID == Elements.First().PageNameID) PageNm = ele.PageName;
                }
            }
            

        }
        public void OnPostSelectPage()
        {
            this.start();
            PageNm = Request.Form["PageNm"].ToString();
            
        }
        public IActionResult OnPostSave()
        {

            var pageElement = new PageElements
            {
                PageNameID = PageElement.PageID,
                ElementTypeID = PageElement.ElementID,
            };

            testCreatorDbContext.PageElements.Add(pageElement);
            testCreatorDbContext.SaveChanges();
            return RedirectToPage("/PageElementList");
        }

    }
}
