﻿using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Functions.Core;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Symbols;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    [Category("Qik")]
    [Category("Qik.Functions")]
    [Category("Tests.UnitTests")]
    public class ProperCaseFunctionTests
    {
        [Test]
        public void ProperCaseFunction_InputUpperCase_OutputsProperCase_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            GlobalTable globalTable = new GlobalTable();

            List<IFunction> functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERAL TEXT")
            };

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@toProperCase", "Proper Case Function", "Proper Case Function", true, true, new ProperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@toProperCase", expressionSymbol.Symbol);
            Assert.AreEqual("@{toProperCase}", expressionSymbol.Placeholder);
            Assert.AreEqual("Proper Case Function", expressionSymbol.Title);

            Assert.AreEqual("Literal Text", expressionSymbol.Value);
        }

        [Test]
        public void ProperCaseFunction_InputUpperCase_OutputsProperCase()
        {
            string funcText = $"properCase(\"PROPERCASE TEXT\")";
            string output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("Propercase Text", output);
        }
    }
}
