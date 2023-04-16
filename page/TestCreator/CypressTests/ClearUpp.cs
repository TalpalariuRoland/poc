using System.IO;
namespace TestCreator.CypressTests
{
    public class ClearUpp
    {
        public static void Clear()
        {

            string filePath = @"C:\Users\talpa\Desktop\poc\cypress\reports\";
            string fileNamePattern = "*_0*.json";
            string[] filesToDelete = Directory.GetFiles(filePath, fileNamePattern);

            foreach (string fileToDelete in filesToDelete)
            {
                File.Delete(fileToDelete);
                while (File.Exists(filePath))Thread.Sleep(1); 
                
            }

        }
    }
}
