﻿using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Funcs;
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
    [Category("Qik")]
    [Category("Qik.Functions")]
    [Category("Tests.UnitTests")]
    class CurrentDateFunctionTests
    {
        [Test]
        public void CurrentDateFunction_RequestDate_ReturnsCurrentDate_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW
            GlobalTable globalTable = new GlobalTable();

            List<IFunction> functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "dd/MM/yyyy")
            };

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@currentDate", "Current Date", "Description", true, true, new CurrentDateFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@currentDate", expressionSymbol.Symbol);
            Assert.AreEqual("@{currentDate}", expressionSymbol.Placeholder);
            Assert.AreEqual("Current Date", expressionSymbol.Title);

            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), expressionSymbol.Value);
        }

        //[Test]
        //public void CurrentDateFunction_RequestDate_ReturnsCurrentDate_2()
        //{
        //    // You might need to stub into this to have this work correctly.
        //    // Always difficult to test a current date time, and do you actually have to?
        //    string funcText = $"currentDate(\"dd/MM/yyyy\")";
        //    string output = FunctionHelpers.EvaluateCompilerFunction(funcText);
        //    Assert.IsNotNull(DateTime.Parse(output));
        //}
    }
}
