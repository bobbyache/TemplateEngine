using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Functions.Core;
using CygSoft.Qik.LanguageEngine.Scope;
using CygSoft.Qik.LanguageEngine.Symbols;
using LanguageEngine.Tests.UnitTests.Helpers;
using NUnit.Framework;

namespace LanguageEngine.Tests.UnitTests.Functions
{
    [TestFixture]
    class ConcatenateFunctionTests
    {
        [Test]
        public void ConcatenateFunction_Input3Strings_ConcatenatesToSingleString_1()
        {
            var globalTable = new GlobalTable();

            var concatFunc = new ConcatenateFunction(new FuncInfo("stub", 1, 1), globalTable);

            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "hello"));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, " "));
            concatFunc.AddFunction(new TextFunction(new FuncInfo("stub", 1, 1), globalTable, "world"));

            var expressionSymbol = new ExpressionSymbol(new ErrorReport(), "@concat", "Concatenated String", "Description", true, true, concatFunc);

            Assert.AreEqual("@concat", expressionSymbol.Symbol);
            Assert.AreEqual("@{concat}", expressionSymbol.Placeholder);
            Assert.AreEqual("Concatenated String", expressionSymbol.Title);

            Assert.AreEqual("hello world", expressionSymbol.Value);
        }

        [Test]
        public void ConcatenateFunction_Input3Strings_ConcatenatesToSingleString()
        {
            var concatExpression = "\"hello\" + \" \" + \"world\"";
            var output = TestHelpers.EvaluateCompilerFunction(concatExpression);
            Assert.AreEqual("hello world", output);
        }
    }
}
