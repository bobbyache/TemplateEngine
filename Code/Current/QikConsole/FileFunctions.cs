using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CygSoft.Qik.Console
{
    public interface IFileFunctions
    {
        bool FileExists(string filePath);
        string GetFileDirectory(string filePath);
        string ReadTextFile(string filePath);
        void WriteTextFile(string path, string contents);
        bool FindQikScriptInFolder(string directoryPath, out string scriptPath);
        bool FindBlueprintFilesInFolder(string directoryPath, out IEnumerable<string> blueprintPaths);
        bool FindInputsFileInFolder(string directoryPath, out string jsonInputFile);
        bool IsInputsFile(string path);
        bool IsFolder(string path);
        bool IsQikScript(string path);
        bool IsBlueprint(string path);
        string GeneratOutputPath(string blueprintFilePath);
    }

    public class FileFunctions : IFileFunctions
    {
        public bool FileExists(string filePath) => File.Exists(filePath);
        public string GetFileDirectory(string filePath) => Path.GetDirectoryName(filePath);

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

        public void WriteTextFile(string path, string contents)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.Write(contents);
                streamWriter.Flush();
            }
        }

        public bool FindInputsFileInFolder(string directoryPath, out string jsonInputFile)
        {
            var path = Directory.EnumerateFiles(directoryPath, "*.json").SingleOrDefault();
            jsonInputFile = path;

            return path is not null;
        }

        public bool FindQikScriptInFolder(string directoryPath, out string scriptPath)
        {
            var path = Directory.EnumerateFiles(directoryPath, "*.qik").SingleOrDefault();
            scriptPath = path;

            return path is not null;
        }

        public bool FindBlueprintFilesInFolder(string directoryPath, out IEnumerable<string> blueprintPaths)
        {
            var paths = Directory.EnumerateFiles(directoryPath, "*.blu");
            blueprintPaths = paths;

            return paths is not null && paths.Count() > 0;
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

        public bool IsInputsFile(string path)
        {
            if (!IsFolder(path))
            {
                if (Path.GetExtension(path) == ".json" && File.Exists(path))
                    return true;
            }
            return false;
        }

        public bool IsBlueprint(string path)
        {
            if (!IsFolder(path))
            {
                if (Path.GetExtension(path) == ".blu" && File.Exists(path))
                    return true;
            }
            return false;
        }

        public string GeneratOutputPath(string blueprintFilePath)
        {
            var directory = Path.GetDirectoryName(blueprintFilePath);
            var fileName = Path.GetFileNameWithoutExtension(blueprintFilePath);
            return Path.Combine(directory, $"{fileName}_output.txt");
        }
    }
}