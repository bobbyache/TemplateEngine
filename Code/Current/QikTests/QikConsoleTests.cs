using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using CygSoft.Qik;
using CygSoft.Qik.Console;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class QikConsoleTests
    {
        // TODO: If the API will take the "path" and determine whether it's a qik file or
        //  a folder, there needs to be a test for handling both cases.
        // May have to set up a setup and teardown w/ temporary files and folders.
        [Test]
        public void Should_Read_Script_And_Return_Input_Manifest()
        {
            var fileFunctions = new FileFunctions();
            var compiler = new Compiler();
            var jsonFunctions = new JsonFunctions(compiler);

            var appHost = new AppHost(compiler, fileFunctions, jsonFunctions);
            var resultJson = appHost.Read(FileHelpers.ResolvePath("InferPrimaryKey.qik"));
            var expectedJson = FileHelpers.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }
    }
}