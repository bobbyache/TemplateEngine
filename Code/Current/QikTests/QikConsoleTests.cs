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
            var compiler = new Compiler();
            var jsonFunctions = new JsonFunctions(compiler);

            var appHost = new AppHost(compiler, fileFunctions, jsonFunctions);
            var resultJson = appHost.GetJsonInputInterface(FileHelpers.ResolvePath("InferPrimaryKey.qik"));
            var expectedJson = FileHelpers.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }

        [Test]
        public void Should_Find_Script_In_Direcctory_And_Return_Input_Manifest()
        {
            var fileFunctions = new FileFunctions();
            var compiler = new Compiler();
            var jsonFunctions = new JsonFunctions(compiler);

            var appHost = new AppHost(compiler, fileFunctions, jsonFunctions);
            var resultJson = appHost.GetJsonInputInterface(FileHelpers.GetSubFolder("QikDirectory"));
            var expectedJson = FileHelpers.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }
    }
}