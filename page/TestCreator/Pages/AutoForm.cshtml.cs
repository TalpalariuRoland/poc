using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.CypressTests;
using TestCreator.Data;
using TestCreator.Models.Domain;

namespace TestCreator.Pages
{
    public class AutoFormModel : PageModel
    {
        private readonly TestCreatorDbContext testCreatorDbContext;
        public List<PagesName> Pages { get; set; }
        public List<PageElements> Elements { get; set; }
        
        public List<ElementType> ElementTypes { get; set; }
        public TestStep Step { get; set; }
        
        public AutoFormModel(TestCreatorDbContext testCreatorDbContext)
        {
            this.testCreatorDbContext = testCreatorDbContext;
        }

        public void OnGet()
        {
            Pages = testCreatorDbContext.PagesName.ToList();
            ElementTypes = testCreatorDbContext.ElementTypes.ToList();
            Elements= testCreatorDbContext.PageElements.ToList();

        }

        public IActionResult OnPostEdit()
        {
            var TestList = new List<TestStep> { };

            var elements = testCreatorDbContext.ElementTypes.ToList();
            var elements1 = testCreatorDbContext.PageElements.ToList();



            int counter = 0;
            //-------------
            foreach(var element in elements1)
            {
                var Test = new TestStep
                {
                    ElementTypeID = element.ElementID,
                    count = Request.Form[counter.ToString()],
                };
                counter++;
                TestList.Add(Test);
            }
            var call = new HTML();
            var TestName = Request.Form["Name"].ToString();
            call.createTestHTML(TestList,elements,TestName);

            return RedirectToPage("/Index");
        }
    }
}
