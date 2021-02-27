using CygSoft.Qik.LanguageEngine;
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
    class RemoveSpacesFunctionTests
    {
        [Test]
        public void RemoveSpacesFunction_InputSpacedText_RemovesSpaces_1()
        {
            // BEFORE REMOVING THIS TEST METHOD YOU NEED TO WRITE TESTS FOR ALL ITS POSSIBILITIES IN THE NEW STYLE BELOW

            GlobalTable globalTable = new GlobalTable();

            List<IFunction> functionArguments = new List<IFunction>
            {
                new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "literal text")
            };

            ExpressionSymbol expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@classInstance", "Class Instance", "Description", true, true, new RemoveSpacesFunction(new FuncInfo("stub", 1, 1), globalTable, functionArguments));
            Assert.AreEqual("@classInstance", expressionSymbol.Symbol);
            Assert.AreEqual("@{classInstance}", expressionSymbol.Placeholder);
            Assert.AreEqual("Class Instance", expressionSymbol.Title);

            Assert.AreEqual("literaltext", expressionSymbol.Value);
        }

        [Test]
        public void RemoveSpacesFunction_InputSpacedText_RemovesSpaces()
        {
            string funcText = $"removeSpaces(\"literal text ya all\")";
            string output = TestHelpers.EvaluateCompilerFunction(funcText);
            Assert.AreEqual("literaltextyaall", output);
        }
    }
}
