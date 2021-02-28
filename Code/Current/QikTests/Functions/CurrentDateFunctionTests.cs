using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Functions.Core;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Symbols;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class CurrentDateFunctionTests
    {
        [Test]
        public void CurrentDateFunction_RequestDate_ReturnsCurrentDate_1()
        {
            //TODO: Wherever this message is in the function tests look to convert to the new form of the function test see 
                // var output = TestHelpers.EvaluateCompilerFunction(funcText);

            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW
            var globalTable = new GlobalTable();

            var functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "dd/MM/yyyy")
            };

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@currentDate", "Current Date", "Description", true, true, new 
                CurrentDateFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            
            Assert.AreEqual("@currentDate", expressionSymbol.Symbol);
            Assert.AreEqual("@{currentDate}", expressionSymbol.Placeholder);
            Assert.AreEqual("Current Date", expressionSymbol.Title);

            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), expressionSymbol.Value);
        }
    }
}
