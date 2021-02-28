using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using LanguageEngine.Tests.UnitTests.Helpers;
using CygSoft.Qik.Api;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class QikApiTests
    {

        [Test]
        public void Test_It()
        {
            JsonApi qikApi = new JsonApi();
            var resultJson = qikApi.ReadScript(TxtFile.ReadText("InferPK.txt"));
            var expectedJson = TxtFile.ReadText("InferPk_ReadScript_Json.txt");
            Assert.AreEqual(expectedJson, resultJson);
        }
    }
}