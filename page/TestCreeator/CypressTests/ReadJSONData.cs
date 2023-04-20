using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace TestCreator.CypressTests

{
    public class ReadJSONData
    {
        public static StatsData DataFromJson(string FileName)
        {
            string path = @"C:\Users\talpa\Desktop\poc\cypress\results\"+ FileName + "";
            string json = File.ReadAllText(path);
            StatsData result = JsonConvert.DeserializeObject<StatsData>(json);
            return result;

        }
        public static void createReport(string ReportName)
        {
            
            
            string command = "CMD.exe";
            string arguments = "/C cd ../../../../../../../ && cd ../../Users/talpa/Desktop/poc && npx mochawesome-merge cypress/reports/*.json > cypress/results/"+ReportName+".json";

            Process process = new Process();

            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;

            process.Start();
            process.WaitForExit();
        }
    }
}
