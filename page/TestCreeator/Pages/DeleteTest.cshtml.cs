using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestCreator.CypressTests;

namespace TestCreeator.Pages
{
    public class DeleteTestModel : PageModel
    {
        public string name;
        public IActionResult OnGet(string name)
        {
            string[] parts = name.Split('+');
            string first = parts[0];
            string second = parts[1];
            ClearUpp.DeleteTest(first,second);
            return Redirect("/index");
        }
    }
}
