using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Symbols;
using System.Collections.Generic;
using CygSoft.Qik.LanguageEngine;

namespace UnitTests.Tests
{
    [TestClass]
    public class FunctionTests
    {
        [TestMethod]
        public void Function_BasicText()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "Literal Text";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@authorName", "Author Name", "Description", true, true, new TextFunction(new FuncInfo("stub", 1, 1), globalTable, literalText));
            Assert.AreEqual("@authorName", expressionSymbol.Symbol);
            Assert.AreEqual("@{authorName}", expressionSymbol.Placeholder);
            Assert.AreEqual("Author Name", expressionSymbol.Title);

            Assert.AreEqual("Literal Text", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_CamelCase()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LiteralText"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new CamelCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literalText", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_LowerCase()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERALTEXT"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new LowerCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_UpperCase()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literaltext"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new UpperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_ProperCase()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERAL TEXT"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@toProperCase", "Proper Case Function", "Proper Case Function", true, true, new ProperCaseFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@toProperCase", expressionSymbol.Symbol);
            Assert.AreEqual("@{toProperCase}", expressionSymbol.Placeholder);
            Assert.AreEqual("Proper Case Function", expressionSymbol.Title);

            Assert.AreEqual("Literal Text", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_RemovePunctuation()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "LITERAL?!..TEXT."));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@removePunctuation", "Remove Punctuation Function", "Remove Punctuation Function", true, true, new RemovePunctuationFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@removePunctuation", expressionSymbol.Symbol);
            Assert.AreEqual("@{removePunctuation}", expressionSymbol.Placeholder);
            Assert.AreEqual("Remove Punctuation Function", expressionSymbol.Title);

            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }


        [TestMethod]
        public void Function_DoubleQuote()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literal text"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new DoubleQuoteFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("\"literal text\"", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_RemoveSpaces()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literal text"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new RemoveSpacesFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_Replace()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "Dashboard Usage"));
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, " "));
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "_"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new ReplaceFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("Dashboard_Usage", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_CurrentDate()
        {
            GlobalTable globalTable = new GlobalTable();

            List<BaseFunction> functionArguments = new List<BaseFunction>();
            functionArguments.Add(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "dd/MM/yyyy"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@currentDate", "Current Date", "Description", true, true, new CurrentDateFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@currentDate", expressionSymbol.Symbol);
            Assert.AreEqual("@{currentDate}", expressionSymbol.Placeholder);
            Assert.AreEqual("Current Date", expressionSymbol.Title);

            DateTime dateTime = DateTime.Now;

            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_Concatenate()
        {
            GlobalTable globalTable = new GlobalTable();

            ConcatenateFunction concatFunc = new ConcatenateFunction(new FuncInfo("stub", 1, 1), globalTable);

            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "hello"));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, " "));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "world"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@concat", "Concatenated String", "Description", true, true, concatFunc);
            Assert.AreEqual("@concat", expressionSymbol.Symbol);
            Assert.AreEqual("@{concat}", expressionSymbol.Placeholder);
            Assert.AreEqual("Concatenated String", expressionSymbol.Title);

            Assert.AreEqual("hello world", expressionSymbol.Value);
        }

        [TestMethod]
        public void Function_IfDecision()
        {
            GlobalTable globalTable = new GlobalTable();

            OptionInputSymbol optionInputSymbol = new OptionInputSymbol(new ErrorReport(), "@databaseOptions", "Database Options", "Description", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IfDecissionFunction decissionFunc = new IfDecissionFunction(new FuncInfo("stub", 1, 1), globalTable, "@databaseOptions");
            decissionFunc.AddFunction("ADVWORKS", new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "You chose DM"));
            decissionFunc.AddFunction("PUBBOOKS", new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "You chose Published Books Database"));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@selectedDatabase", "Selected Database", "Description", true, true, decissionFunc);

            globalTable.AddSymbol(optionInputSymbol);
            globalTable.AddSymbol(expressionSymbol);

            Assert.AreEqual("ADVWORKS", globalTable.GetValueOfSymbol("@databaseOptions"));
            Assert.AreEqual("You chose DM", globalTable.GetValueOfSymbol("@selectedDatabase"));

            globalTable.Input("@databaseOptions", "1");

            Assert.IsTrue(expressionSymbol.IsPlaceholder);
            Assert.IsTrue(expressionSymbol.IsVisibleToEditor);

            Assert.AreEqual("PUBBOOKS", globalTable.GetValueOfSymbol("@databaseOptions"));
            Assert.AreEqual("You chose Published Books Database", globalTable.GetValueOfSymbol("@selectedDatabase"));
        }
    }
}
