using CygSoft.Qik;
using CygSoft.Qik.Functions;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class IfDecisionFunction
    {
        [Test]
        public void IfDecissionFunction_GivenSelectedOption_ReturnsCorrectValue()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            var globalTable = new GlobalTable();

            var optionInputSymbol = new OptionInputSymbol("@databaseOptions", "Database Options", "Description", "ADVWORKS");
            optionInputSymbol.AddOption("ADVWORKS", "Adventure Works Database");
            optionInputSymbol.AddOption("PUBBOOKS", "Published Books Database");

            var decissionFunc = new IfDecissionFunction(new FuncInfo("stub", 1, 1), globalTable, "@databaseOptions");
            decissionFunc.AddFunction("ADVWORKS", new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "You chose DM"));
            decissionFunc.AddFunction("PUBBOOKS", new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "You chose Published Books Database"));

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@selectedDatabase", "Selected Database", "Description", true, true, decissionFunc);

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
