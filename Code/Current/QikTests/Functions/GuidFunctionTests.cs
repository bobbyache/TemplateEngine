﻿using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System;

namespace Qik.LanguageEngine.UnitTests.Functions
{
    [TestFixture]
    public class GuidFunctionTests
    {
        [Test]
        public void GuidFunction_Returns_NewGuid()
        {
            var funcText = $"guid(\"u\")";
            var output = TestHelpers.EvaluateCompilerFunction(funcText);
            var guid = new Guid(output);
        }

        [Test]
        public void GuidFunction_Returns_UpperCase_Guid_When_No_Case_Specified()
        {
            var funcText = $"guid()";
            var original = TestHelpers.EvaluateCompilerFunction(funcText);
            var ucased = original;

            Assert.AreEqual(original.ToLower(), ucased, "Guid does not match or is in the incorrect case.");
        }

        [Test]
        public void GuidFunction_Returns_UpperCase_Guid_When_UpperCase_Specified()
        {
            var funcText = $"guid(\"u\")";
            var original = TestHelpers.EvaluateCompilerFunction(funcText);
            var ucased = original.ToUpper();

            Assert.AreEqual(original, ucased, "Guid does not match or is in the incorrect case.");
        }

        [Test]
        public void GuidFunction_Returns_LowerCase_Guid_When_LowerCase_Specified()
        {
            var funcText = $"guid(\"l\")";
            var original = TestHelpers.EvaluateCompilerFunction(funcText);
            var lcased = original.ToLower();

            Assert.AreEqual(original, lcased, "Guid does not match or is in the incorrect case.");
        }

        [Test]
        public void GuidFunction_Returns_LowerCase_Guid_When_Nothing_Specified()
        {
            var funcText = $"guid(\"\")";
            var original = TestHelpers.EvaluateCompilerFunction(funcText);
            var lcased = original.ToLower();

            Assert.AreEqual(original, lcased, "Guid does not match or is in the incorrect case.");
        }
    }
}
