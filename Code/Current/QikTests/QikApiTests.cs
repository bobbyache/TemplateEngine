using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using CygSoft.Qik.Api;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class QikApiTests
    {

        [Test]
        public void Should_Read_Script_And_Return_Input_Manifest()
        {
            JsonApi qikApi = new JsonApi();
            var resultJson = qikApi.ReadScript(TxtFile.ResolvePath("InferPK.txt"));
            var expectedJson = TxtFile.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }
    }
}