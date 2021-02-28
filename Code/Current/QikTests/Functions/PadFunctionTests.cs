using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;

namespace Qik.LanguageEngine.UnitTests.Functions
{
    [TestFixture]
    public class PadFunctionTests
    {
        [Test]
        public void PadLeftFunction_Pads_Correctly()
        {
            var funcText = $"padLeft(\"12\", \"0\", 5)";
            var output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("00012", output);
        }

        [Test]
        public void PadRightFunction_Pads_Correctly()
        {
            var funcText = $"padRight(\"12\", \"0\", 5)";
            var output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("12000", output);
        }
    }
}
