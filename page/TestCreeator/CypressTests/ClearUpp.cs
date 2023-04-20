using System.IO;
namespace TestCreator.CypressTests
{
    public class ClearUpp
    {
        public static void Clear()
        {

            string filePath = @"C:\Users\talpa\Desktop\poc\cypress\reports\";
            string fileNamePattern = "*.json";
            string[] filesToDelete = Directory.GetFiles(filePath, fileNamePattern);

            foreach (string fileToDelete in filesToDelete)
            {
                File.Delete(fileToDelete);
                while (File.Exists(filePath))Thread.Sleep(1); 
                
            }

        }

        public static void DeleteTest(string location,string TestName)
        {
            string filePath = @"C:\Users\talpa\Desktop\poc\cypress\"+location;
            string[] filesToDelete = Directory.GetFiles(filePath, TestName);

            foreach (string fileToDelete in filesToDelete)
            {
                File.Delete(fileToDelete);
                while (File.Exists(filePath)) Thread.Sleep(1);

            }
        }
    }
}
