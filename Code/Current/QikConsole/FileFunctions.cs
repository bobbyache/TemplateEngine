using System.IO;

namespace CygSoft.Qik.Console
{
    public interface IFileFunctions
    {
        string ReadTextFile(string filePath);
    }

    public class FileFunctions : IFileFunctions
    {
        public string ReadTextFile(string filePath)
        {
            string contents = null;
            // Specify file, instructions, and priveledges
            using (var file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                // Create a new stream to read from a file
                using (StreamReader sr = new StreamReader(file))
                {
                    contents = sr.ReadToEnd();
                }
            }
            return contents;
        }
    }
}