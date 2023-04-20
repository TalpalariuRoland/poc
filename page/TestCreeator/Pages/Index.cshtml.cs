using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using Newtonsoft.Json;
using TestCreator.CypressTests;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace TestCreator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<string> jsFilesList = new List<string>();
        public List<string> ResultList = new List<string>();
        public StatsData Result=new StatsData();
        public bool ShowModal { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.Startupp();
        }
        private void Startupp()
        {
            string folderPath = @"C:\Users\talpa\Desktop\poc\cypress\e2e";
            string ResultPath = @"C:\Users\talpa\Desktop\poc\cypress\results";
            string[] jsFiles = Directory.GetFiles(folderPath, "*.js");
            ShowModal = false;
            Result = null;
            jsFilesList.Clear();

            foreach (string file in jsFiles)
            {
                string fileName = Path.GetFileName(file);
                jsFilesList.Add(fileName);
            }

            string[] resultFiles = Directory.GetFiles(ResultPath, "*.json");
            foreach (string file in resultFiles)
            {
                string fileName = Path.GetFileName(file);
                ResultList.Add(fileName);
            }

        }

        public void OnPostResults()
        {
            this.Startupp();
            string FileName = Request.Form["Result"].ToString();
            Result=ReadJSONData.DataFromJson(FileName); 
        }

        public void OnPostRunTest()
        {

            string folderPath = @"C:\Users\talpa\Desktop\poc\cypress\e2e";
            string[] jsFiles = Directory.GetFiles(folderPath, "*.js");

            foreach (string file in jsFiles)
            {
                string fileName = Path.GetFileName(file);
                jsFilesList.Add(fileName);
            }
            string toRun = "";
            int number = 0;

            foreach (var files in jsFilesList)
            {   
                var option = Request.Form[files].ToString();
                if (option != "")
                    if (toRun != "")
                    {
                        toRun = toRun + "," + option;
                        number++;
                    }

                    else 
                    { 
                        number++;
                        toRun = option; 
                    }
            }
            
            ClearUpp.Clear();
            if (number > 1)
            {

                string command = "CMD.exe";
                string arguments = "/C cd ../../../../../../../ && cd ../../Users/talpa/Desktop/poc && npx cypress run --headless --reporter mochawesome --spec \"cypress/e2e/{" + toRun + "}\"";

                Process process = new Process();

                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;

                process.Start();
                process.WaitForExit();
            }
            if (number == 1)
            {
                string command = "CMD.exe";
                string arguments = "/C cd ../../../../../../../ && cd ../../Users/talpa/Desktop/poc && npx cypress run --headless --reporter mochawesome --spec \"cypress/e2e/" + toRun + "\"";

                Process process = new Process();

                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;

                process.Start();
                process.WaitForExit();
            }
            ReadJSONData.createReport(Request.Form["ExecutionName"].ToString());

            this.Startupp();
            ShowModal = false;

        }

    }
}
