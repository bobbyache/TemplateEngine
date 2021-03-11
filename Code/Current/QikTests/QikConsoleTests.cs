using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using CygSoft.Qik;
using CygSoft.Qik.Console;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class QikConsoleTests
    {
        [Test]
        public void Should_Read_Script_And_Return_Input_Manifest()
        {
            var fileSettings = new CygSoft.Qik.Console.FileSettings() { CommaDelimitedBlueprintExtensions = ".blu", ScriptFileName = "InferPrimaryKey.qik", InputsFileName = "input.json" };
            var fileFunctions = new FileFunctions(fileSettings);
            var interpreter = new Interpreter();
            var jsonFunctions = new JsonFunctions(interpreter);

            var appHost = new AppHost(interpreter, fileFunctions, jsonFunctions);
            var resultJson = appHost.GetJsonInputInterface(FileHelpers.ResolvePath("InferPrimaryKey.qik"));
            var expectedJson = FileHelpers.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }

        [Test]
        public void Should_Find_Script_In_Directory_And_Generate_Valid_Output()
        {
            var fileSettings = new CygSoft.Qik.Console.FileSettings() { CommaDelimitedBlueprintExtensions = ".blu", ScriptFileName = "file.qik", InputsFileName = "input.json" };
            var fileFunctions = new FileFunctions(fileSettings);
            var interpreter = new Interpreter();
            var jsonFunctions = new JsonFunctions(interpreter);

            var appHost = new AppHost(interpreter, fileFunctions, jsonFunctions);
            appHost.Generate(FileHelpers.GetSubFolder("QikDirectory"));

            var output_1 = FileHelpers.ReadText(@"QikDirectory\output\blueprint_1.blu");
            var output_2 = FileHelpers.ReadText(@"QikDirectory\output\blueprint_2.blu");

            FileHelpers.DeleteDirectory(@"QikDirectory\output");

            Assert.AreEqual(output_1, "Table_1Id");
            Assert.AreEqual(output_2, "Table_1Id\r\nTable_1Id");
        }
    }
}