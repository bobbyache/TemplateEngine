using System.IO;

namespace Qik.LanguageEngine.IntegrationTests.Helpers
{
    public class TxtFile
    {
        public static string GetFolder() => "../../../../QikTests/Scripts";
        public static string ResolvePath(string fileName) => Path.Combine(GetFolder(), fileName);
        public static string ReadText(string fileName) => File.ReadAllText(ResolvePath(fileName));
    }
}
