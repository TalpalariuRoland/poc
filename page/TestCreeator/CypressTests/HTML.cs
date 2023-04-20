using TestCreator.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace TestCreator.CypressTests
{
    public class HTML
    {

        public string[] endString =
        {
            "cy.wait(2000);",
            "  })",
            "})",
        };

        public async void createTestHTML(List<TestStep> TestList, List<ElementType> elements, string TestName, string PageName)
        {
            string[] StartingString =
        {
            "import HtmlPage from '../PageObj/HtmlPObj'",
            "describe('template spec', () => {",
            "  it('passes', () => {",
            "    cy.visit('../../page/"+PageName+".html')",
        };




            List<string> TestString = new List<string>();

            foreach (TestStep testStep in TestList)
            {
                foreach (ElementType element in elements)
                {
                    if (testStep.ElementTypeID == element.ID)
                    {
                        switch (element.ElementName)
                        {
                            case "CheckBox":
                                TestString.Add(PageName + ".selectCheckBox(" + testStep.TestVariable.ToString() + ");");
                                break;

                            case "RadioBox":
                                TestString.Add(PageName + ".selectRadioBox(" + testStep.TestVariable.ToString() + ");");
                                break;

                            case "Textbox":
                                TestString.Add(PageName + ".typeInTextbox('" + testStep.TestVariable.ToString() + "');");
                                break;


                        }

                    }
                }
            }

            await File.WriteAllTextAsync("..\\..\\cypress\\e2e\\" + TestName + ".cy.js", "");
            using StreamWriter file = new("..\\..\\cypress\\e2e\\" + TestName + ".cy.js", append: true);
            foreach (string line in StartingString) await file.WriteLineAsync(line);
            foreach (string line in TestString) await file.WriteLineAsync(line);
            foreach (string line in endString) await file.WriteLineAsync(line);

            //System.Diagnostics.Process.Start("CMD.exe", "/C cd ../../../../../../../ && cd ../../Users/talpa/Desktop/poc && npx cypress run --headed --spec \"cypress/e2e/"+TestName+".cy.js\"");

        }
    }
}
