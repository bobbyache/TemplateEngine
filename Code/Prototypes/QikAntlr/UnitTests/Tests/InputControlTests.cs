using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CygSoft.Qik.LanguageEngine.Symbols;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System.IO;
using CygSoft.Qik.LanguageEngine;

namespace UnitTests.Tests
{
    [TestClass]
    [DeploymentItem(@"Files\Scripts\OptionBox.txt")]
    public class InputControlTests
    {
        [TestMethod]
        public void OptionInput_WithoutDefault()
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

            Assert.AreEqual("Adventure Works Database", optionsField.OptionTitle("ADVWORKS"));
            Assert.AreEqual("Published Books Database", optionsField.OptionTitle("PUBBOOKS"));

            Assert.AreEqual(null, optionsField.SelectedIndex);
            Assert.AreEqual(null, optionsField.DefaultValue);
            Assert.AreEqual(null, optionsField.Value);
        }

        [TestMethod]
        public void OptionInput_WithDefault()
        {
            OptionInputSymbol optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "Description", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            IOptionsField optionsField = optionInputSymbol;

            Assert.AreEqual("ADVWORKS", optionInputSymbol.DefaultValue);
            Assert.AreEqual("ADVWORKS", optionInputSymbol.Value);

            Assert.AreEqual(0, optionsField.SelectedIndex);
            Assert.AreEqual("ADVWORKS", optionsField.DefaultValue);
            Assert.AreEqual("ADVWORKS", optionsField.Value);
        }

        [TestMethod]
        public void OptionInput_MakeSelections()
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
        public void OptionInput_MakeSelections_Interface()
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
        public void OptionInput_GetOptionTitles()
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
        public void OptionInput_GetOptionTitles_Interface()
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
        public void OptionInput_Parse_IsPlaceholder()
        {
            string scriptText = File.ReadAllText("OptionBox.txt");
            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);

            IInputField inputField = compiler.InputFields[0];
            Assert.IsFalse(inputField.IsPlaceholder);
        }

        [TestMethod]
        public void TextInput_Create()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Description", null, true);
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
        }

        [TestMethod]
        public void TextInput_WithDefault()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Description", "Rob Blake", true);
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
            Assert.AreEqual("Rob Blake", textInputSymbol.DefaultValue);
            Assert.AreEqual("Rob Blake", textInputSymbol.Value);
        }

        [TestMethod]
        public void TextInput_WithoutDefault()
        {
            TextInputSymbol textInputSymbol = new TextInputSymbol("@authorName", "Author Name", "Description", null, true);
            Assert.AreEqual("@authorName", textInputSymbol.Symbol);
            Assert.AreEqual("@{authorName}", textInputSymbol.Placeholder);
            Assert.AreEqual("Author Name", textInputSymbol.Title);
            Assert.AreEqual(null, textInputSymbol.DefaultValue);
            Assert.AreEqual(null, textInputSymbol.Value);

            textInputSymbol.SetValue("Andrew Botha");
            Assert.AreEqual("Andrew Botha", textInputSymbol.Value);
            Assert.AreEqual(null, textInputSymbol.DefaultValue);
        }
    }
}
