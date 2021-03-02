using System.IO;
using System.Linq;

namespace CygSoft.Qik.Console
{
    public interface IFileFunctions
    {
        string ReadTextFile(string filePath);
        bool FindQikScriptInFolder(string directoryPath, out string scriptPath);
        bool IsFolder(string path);
        bool IsQikScript(string path);
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

        public bool FindQikScriptInFolder(string directoryPath, out string scriptPath)
        {
            var path = Directory.EnumerateFiles(directoryPath, "*.qik").SingleOrDefault();
            scriptPath = path;

            return path is not null;
        }

        public bool IsFolder(string path)
        {
            var fileSystemInfo = new DirectoryInfo(path);
            return fileSystemInfo.IsDirectory();
        }

        public bool IsQikScript(string path)
        {
            if (!IsFolder(path))
            {
                if (Path.GetExtension(path) == ".qik" && File.Exists(path))
                    return true;
            }
            return false;
        }
    }
}