using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace CygSoft.Qik.LanguageEngine.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Create_OptionInputSymbol_WithoutDefault()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", null);
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IOptionsField optionsField = optionInputSymbol;

            Assert.AreEqual("@databaseOptions", optionInputSymbol.Symbol);
            Assert.AreEqual("@{databaseOptions}", optionInputSymbol.Placeholder);
            Assert.AreEqual("Database Options", optionInputSymbol.Title);

            Assert.AreEqual(null, optionInputSymbol.DefaultValue);
            Assert.AreEqual(null, optionInputSymbol.Value);

            Assert.AreEqual("@databaseOptions", optionsField.Symbol);
            Assert.AreEqual("@{databaseOptions}", optionsField.Placeholder);
            Assert.AreEqual("Database Options", optionsField.Title);

            Assert.AreEqual(null, optionsField.DefaultValue);
            Assert.AreEqual(null, optionsField.Value);
        }

        [TestMethod]
        public void Create_OptionInputSymbol_WithDefault()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IOptionsField optionsField = optionInputSymbol;

            Assert.AreEqual("ADVWORKS", optionInputSymbol.DefaultValue);
            Assert.AreEqual("ADVWORKS", optionInputSymbol.Value);

            Assert.AreEqual("ADVWORKS", optionsField.DefaultValue);
            Assert.AreEqual("ADVWORKS", optionsField.Value);
        }

        [TestMethod]
        public void Create_OptionInputSymbol_MakeSelections()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            optionInputSymbol.SelectOption("0");
            string indexOption_at_0 = optionInputSymbol.Value;

            optionInputSymbol.SelectOption("1");
            string indexOption_at_1 = optionInputSymbol.Value;

            optionInputSymbol.SelectOption(0);
            string indexOption_index_at_0 = optionInputSymbol.Value;

            optionInputSymbol.SelectOption("ADVWORKS");
            string valueOption_at_0 = optionInputSymbol.Value;

            optionInputSymbol.SelectOption("PUBBOOKS");
            string valueOption_at_1 = optionInputSymbol.Value;

            Assert.AreEqual("ADVWORKS", indexOption_at_0);
            Assert.AreEqual("PUBBOOKS", indexOption_at_1);
            Assert.AreEqual("ADVWORKS", valueOption_at_0);
            Assert.AreEqual("PUBBOOKS", valueOption_at_1);
            Assert.AreEqual("ADVWORKS", indexOption_index_at_0);
        }

        [TestMethod]
        public void Create_OptionInputSymbolInterface_MakeSelections()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IOptionsField optionsField = optionInputSymbol;

            optionsField.SelectOption("0");
            string indexOption_at_0 = optionsField.Value;

            optionsField.SelectOption("1");
            string indexOption_at_1 = optionsField.Value;

            optionsField.SelectOption(0);
            string indexOption_index_at_0 = optionsField.Value;

            optionsField.SelectOption("ADVWORKS");
            string valueOption_at_0 = optionsField.Value;

            optionsField.SelectOption("PUBBOOKS");
            string valueOption_at_1 = optionsField.Value;

            Assert.AreEqual("ADVWORKS", indexOption_at_0);
            Assert.AreEqual("PUBBOOKS", indexOption_at_1);
            Assert.AreEqual("ADVWORKS", valueOption_at_0);
            Assert.AreEqual("PUBBOOKS", valueOption_at_1);
            Assert.AreEqual("ADVWORKS", indexOption_index_at_0);
        }

        [TestMethod]
        public void Create_OptionInputSymbol_GetOptionTitles()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            string indexOption_at_0 = optionInputSymbol.OptionTitle("0");
            string indexOption_at_1 = optionInputSymbol.OptionTitle("1");
            string valueOption_at_0 = optionInputSymbol.OptionTitle("ADVWORKS");
            string valueOption_at_1 = optionInputSymbol.OptionTitle("PUBBOOKS");

            string optionIndex_at_0 = optionInputSymbol.OptionTitle(0);
            string optionIndex_at_1 = optionInputSymbol.OptionTitle(1);

            Assert.AreEqual("Adventure Works Database", indexOption_at_0);
            Assert.AreEqual("Published Books Database", indexOption_at_1);
            Assert.AreEqual("Adventure Works Database", valueOption_at_0);
            Assert.AreEqual("Published Books Database", valueOption_at_1);

            Assert.AreEqual("Adventure Works Database", optionIndex_at_0);
            Assert.AreEqual("Published Books Database", optionIndex_at_1);
        }

        [TestMethod]
        public void Create_OptionInputSymbolInterface_GetOptionTitles()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IOptionsField optionsField = optionInputSymbol;

            string indexOption_at_0 = optionsField.OptionTitle("0");
            string indexOption_at_1 = optionsField.OptionTitle("1");
            string valueOption_at_0 = optionsField.OptionTitle("ADVWORKS");
            string valueOption_at_1 = optionsField.OptionTitle("PUBBOOKS");

            string optionIndex_at_0 = optionsField.OptionTitle(0);
            string optionIndex_at_1 = optionsField.OptionTitle(1);

            Assert.AreEqual("Adventure Works Database", indexOption_at_0);
            Assert.AreEqual("Published Books Database", indexOption_at_1);
            Assert.AreEqual("Adventure Works Database", valueOption_at_0);
            Assert.AreEqual("Published Books Database", valueOption_at_1);

            Assert.AreEqual("Adventure Works Database", optionIndex_at_0);
            Assert.AreEqual("Published Books Database", optionIndex_at_1);
        }

        [TestMethod]
        public void Create_TextInputSymbol()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", null);
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
        }

        [TestMethod]
        public void Create_TextInputSymbol_WithDefault()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Rob Blake");
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
            Assert.AreEqual("Rob Blake", textInputSymbol.DefaultValue);
            Assert.AreEqual("Rob Blake", textInputSymbol.Value);
        }

        [TestMethod]
        public void Create_TextInputSymbol_WithoutDefault()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", null);
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
            Assert.AreEqual(null, textInputSymbol.DefaultValue);
            Assert.AreEqual(null, textInputSymbol.Value);

            textInputSymbol.SetValue("Andrew Botha");
            Assert.AreEqual("Andrew Botha", textInputSymbol.Value);
            Assert.AreEqual(null, textInputSymbol.DefaultValue);
        }

        [TestMethod]
        public void Create_BasicText_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "Literal Text";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@authorName", "Author Name", new TextFunction(globalTable, new LiteralText(literalText)));
            Assert.AreEqual("@authorName", expressionSymbol.Symbol);
            Assert.AreEqual("@{authorName}", expressionSymbol.Placeholder);
            Assert.AreEqual("Author Name", expressionSymbol.Title);

            Assert.AreEqual("Literal Text", expressionSymbol.Value);
        }

        [TestMethod]
        public void Create_CamelCase_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "LiteralText";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@classInstance", "Class Instance", new CamelCaseFunction(globalTable, new LiteralText(literalText)));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literalText", expressionSymbol.Value);
        }

        [TestMethod]
        public void Create_LowerCase_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "LITERALTEXT";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@classInstance", "Class Instance", new LowerCaseFunction(globalTable, new LiteralText(literalText)));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [TestMethod]
        public void Create_UpperCase_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "literaltext";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@classInstance", "Class Instance", new UpperCaseFunction(globalTable, new LiteralText(literalText)));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("LITERALTEXT", expressionSymbol.Value);
        }


        [TestMethod]
        public void Create_RemoveSpaces_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            string literalText = "literal text";
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@classInstance", "Class Instance", new RemoveSpacesFunction(globalTable, new LiteralText(literalText)));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [TestMethod]
        public void Create_CurrentDate_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@currentDate", "Current Date", new CurrentDateFunction(globalTable, new LiteralText("dd/MM/yyyy")));
            Assert.AreEqual("@currentDate", expressionSymbol.Symbol);
            Assert.AreEqual("@{currentDate}", expressionSymbol.Placeholder);
            Assert.AreEqual("Current Date", expressionSymbol.Title);

            DateTime dateTime = DateTime.Now;

            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), expressionSymbol.Value);
        }

        [TestMethod]
        public void Create_Concatenate_ExpressionSymbol()
        {
            GlobalTable globalTable = new GlobalTable();

            ConcatenateFunction concatFunc = new ConcatenateFunction(globalTable);
            concatFunc.AddFunction(new TextFunction(globalTable, new TextFunction(globalTable, new LiteralText("hello"))));
            concatFunc.AddFunction(new TextFunction(globalTable, new TextFunction(globalTable, new LiteralText(" "))));
            concatFunc.AddFunction(new TextFunction(globalTable, new TextFunction(globalTable, new LiteralText("world"))));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@concat", "Concatenated String", concatFunc);
            Assert.AreEqual("@concat", expressionSymbol.Symbol);
            Assert.AreEqual("@{concat}", expressionSymbol.Placeholder);
            Assert.AreEqual("Concatenated String", expressionSymbol.Title);

            Assert.AreEqual("hello world", expressionSymbol.Value);
        }

        // NB: CAN'T REALLY TEST IF YET !!!!!!!!!!!!

        [TestMethod]
        public void Create_GlobalTable_TestInput()
        {
            GlobalTable globalTable = new GlobalTable();

            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Rob Blake");
            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@upperAuthorName", "Upper Author Name", new UpperCaseFunction(globalTable, new Variable("@authorName")));
            
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
        public void Create_IfDecisionStatement_ResolveSelection()
        {
            GlobalTable globalTable = new GlobalTable();

            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IfDecissionFunction decissionFunc = new IfDecissionFunction(globalTable, "@databaseOptions");
            decissionFunc.AddFunction("ADVWORKS", new TextFunction(globalTable, new LiteralText("You chose DM")));
            decissionFunc.AddFunction("PUBBOOKS", new TextFunction(globalTable, new LiteralText("You chose Published Books Database")));

            ExpressionSymbol expressionSymbol = new ExpressionSymbol("@selectedDatabase", "Selected Database", decissionFunc);

            globalTable.AddSymbol(optionInputSymbol);
            globalTable.AddSymbol(expressionSymbol);

            Assert.AreEqual("ADVWORKS", globalTable.GetValueOfSymbol("@databaseOptions"));
            Assert.AreEqual("You chose DM", globalTable.GetValueOfSymbol("@selectedDatabase"));

            globalTable.Input("@databaseOptions", "1");

            Assert.AreEqual("PUBBOOKS", globalTable.GetValueOfSymbol("@databaseOptions"));
            Assert.AreEqual("You chose Published Books Database", globalTable.GetValueOfSymbol("@selectedDatabase"));
        }
    }
}
