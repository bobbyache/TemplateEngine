using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Funcs;

namespace UnitTests
{
    [TestClass]
    public class TestBench
    {

        [TestMethod]
        public void Create_GlobalTable_TestInput()
        {
            GlobalTable globalTable = new GlobalTable();

            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Description", "Rob Blake", true);

            List<BaseFunction> functionArguments = new List<BaseFunction> { new VariableFunction(globalTable, "@authorName") };
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@upperAuthorName", "Upper Author Name", "Description", true, true, new UpperCaseFunction(globalTable, functionArguments));

            globalTable.AddSymbol(textInputSymbol);
            globalTable.AddSymbol(expressionSymbol);

            string textOutput_A = globalTable.GetValueOfSymbol("@authorName");
            string exprOutput_A = globalTable.GetValueOfSymbol("@upperAuthorName");

            globalTable.Input("@authorName", "John Doe");

            string textOutput_B = globalTable.GetValueOfSymbol("@authorName");
            string exprOutput_B = globalTable.GetValueOfSymbol("@upperAuthorName");

            Assert.AreEqual("Rob Blake", textOutput_A);
            Assert.AreEqual("ROB BLAKE", exprOutput_A);

            Assert.AreEqual("John Doe", textOutput_B);
            Assert.AreEqual("JOHN DOE", exprOutput_B);
        }


        [TestMethod]
        public void Placeholder_NotAvailable_When_IsPlaceholder_False()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(globalTable, "dd/MM/yyyy"));

            CurrentDateFunction currentDateFunction = new CurrentDateFunction(globalTable, functionArguments);
            UpperCaseFunction upperCaseFunction = new UpperCaseFunction(globalTable, functionArguments);


            ExpressionSymbol expressionSymbol1 = new ExpressionSymbol("@currentDate", "Current Date", "Description", false, true, currentDateFunction);
            ExpressionSymbol expressionSymbol2 = new ExpressionSymbol("@camelCase", "Camel Cased", "Description", true, true, upperCaseFunction);

            globalTable.AddSymbol(expressionSymbol1);
            globalTable.AddSymbol(expressionSymbol2);

            Assert.AreEqual(1, globalTable.Placeholders.Length);
            Assert.AreEqual("@{camelCase}", globalTable.Placeholders[0]);
            Assert.AreEqual("DD/MM/YYYY", globalTable.GetValueOfSymbol("@camelCase"));
        }
    }
}
