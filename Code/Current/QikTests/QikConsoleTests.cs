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
            var fileFunctions = new FileFunctions();
            var interpreter = new Intepreter();
            var jsonFunctions = new JsonFunctions(interpreter);

            var appHost = new AppHost(interpreter, fileFunctions, jsonFunctions);
            var resultJson = appHost.GetJsonInputInterface(FileHelpers.ResolvePath("InferPrimaryKey.qik"));
            var expectedJson = FileHelpers.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }

        [Test]
        public void Should_Find_Script_In_Directory_And_Generate_Valid_Output()
        {
            var fileFunctions = new FileFunctions();
            var interpreter = new Intepreter();
            var jsonFunctions = new JsonFunctions(interpreter);

            var appHost = new AppHost(interpreter, fileFunctions, jsonFunctions);
            appHost.Generate(FileHelpers.GetSubFolder("QikDirectory"));

            var output_1 = FileHelpers.ReadText(@"QikDirectory\blueprint_1_output.txt");
            var output_2 = FileHelpers.ReadText(@"QikDirectory\blueprint_2_output.txt");

            FileHelpers.DeleteFile(@"QikDirectory\blueprint_1_output.txt");
            FileHelpers.DeleteFile(@"QikDirectory\blueprint_2_output.txt");

            Assert.AreEqual(output_1, "Table_1Id");
            Assert.AreEqual(output_2, "Table_1Id\r\nTable_1Id");
        }
    }
}