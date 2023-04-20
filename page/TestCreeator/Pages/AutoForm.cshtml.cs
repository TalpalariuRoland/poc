using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.CypressTests;
using TestCreeator.Data;
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
            Elements = testCreatorDbContext.PageElements.ToList();

        }

        public IActionResult OnPostCreate()
        {
            var TestList = new List<TestStep> { };
            var Pages = testCreatorDbContext.PagesName.ToList();
            var elements = testCreatorDbContext.ElementTypes.ToList();
            var elements1 = testCreatorDbContext.PageElements.ToList();
            string pagNam = "";



            int counter = 0;
            //-------------
            foreach (var element in elements1)
            {
                var Test = new TestStep
                {
                    ElementTypeID = element.ElementTypeID,
                    TestVariable = Request.Form[counter.ToString()],
                };
                counter++;
                TestList.Add(Test);
            }
            var call = new HTML();
            var TestName = Request.Form["Name"].ToString();
            foreach (var pag in Pages)
            {
                foreach(var ele in elements1)
                {
                    if (ele.PageNameID == pag.ID) pagNam =pag.PageName;
                }
            }
            call.createTestHTML(TestList, elements, TestName,pagNam);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            var elements = testCreatorDbContext.PageElements.ToList();

            foreach (var element in elements)
            {
                var old = testCreatorDbContext.PageElements.Find(element.ID);
                testCreatorDbContext.Remove(old);
                testCreatorDbContext.SaveChanges();
            }
            return RedirectToPage("/AutoForm");
        }


        public IActionResult OnPostAddElement()
        {
            return RedirectToPage("/AddPageElement");
        }

    }
}
