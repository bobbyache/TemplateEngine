namespace CygSoft.Qik.Console
{
    public class FileSettings
    {
        public string CommaDelimitedBlueprintExtensions { get; set; }

        public string[] BlueprintExtensions => CommaDelimitedBlueprintExtensions.Split(",");

        public string ScriptFileName { get; set; }
        public string InputsFileName { get; set; }
    }
}