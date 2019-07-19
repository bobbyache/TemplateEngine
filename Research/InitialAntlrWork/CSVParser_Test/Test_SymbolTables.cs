using System;
using CSVParsing.ANTLR.SymbolTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVParser_Test
{
    [TestClass]
    public class Test_SymbolTables
    {
        [TestMethod]
        public void Test_GlobalScope()
        {
            BuiltInTypeSymbol typeInt = new BuiltInTypeSymbol("int");
            BuiltInTypeSymbol typeDbl = new BuiltInTypeSymbol("double");
            BuiltInTypeSymbol typeFlt = new BuiltInTypeSymbol("float");
            
            // name of symbol and type...
            Symbol symbolVarA = new Symbol("varA", typeInt);
            Symbol symbolVarB = new Symbol("varB", typeDbl);

            GlobalScope globalScope = new GlobalScope();
            globalScope.Define(symbolVarA);
            globalScope.Define(symbolVarB);

            Symbol existingA = globalScope.Resolve("varA");
            Symbol existingB = globalScope.Resolve("varB");
            Symbol missing = globalScope.Resolve("varC");


            Assert.IsNull(globalScope.GetParentScope());
            Assert.IsNull(globalScope.GetEnclosingScope());

            Assert.AreEqual("global", globalScope.GetScopeName());

            Assert.IsNotNull(existingA);
            Assert.IsNotNull(existingB);
            Assert.IsNull(missing);

            Assert.AreSame(symbolVarA, existingA);
            Assert.AreSame(symbolVarB, existingB);

            // test that the types are saved correctly. Each symbol has a
            // type int, double, float, datetime, etc...
            Assert.IsTrue(existingA.Type.Name == "int");
            Assert.IsTrue(existingB.Type.Name == "double");


            Assert.AreEqual("global:varB,varA", globalScope.ToString());
        }


        [TestMethod]
        public void Test_LocalScope()
        {
            // Test that local scope returns the correct name and that local scope contains
            // the correct version to its parent.
            // Scopes look up the tree instead of down them to check for symbol information
            // from "in scope" symbols.
            GlobalScope globalScope = new GlobalScope();
            LocalScope localScopeA = new LocalScope(globalScope);
            LocalScope localScopeB = new LocalScope(localScopeA);

            Assert.IsTrue(localScopeA.GetScopeName() == "local");
            Assert.IsTrue(localScopeB.GetScopeName() == "local");

            Assert.AreSame(localScopeB.GetEnclosingScope(), localScopeA);
            Assert.AreSame(localScopeA.GetEnclosingScope(), globalScope);
        }

        [TestMethod]
        public void Test_LocalScope_Walkup_OneLevel()
        {
            // test to see we can walk up one level.
            IScope currentScope;

            GlobalScope globalScope = new GlobalScope();
            currentScope = globalScope;

            currentScope = new LocalScope(globalScope);
            currentScope = currentScope.GetEnclosingScope();

            // Here we are walking one step up the scope tree. Need to ensure
            // that this method works...
            Assert.AreSame(globalScope, currentScope);
        }

        [TestMethod]
        public void Test_Symbol()
        {
            Symbol symbol = new Symbol("mySymbol", new BuiltInTypeSymbol("int"));
            Assert.IsTrue(symbol.Type.Name == "int");
            Assert.IsTrue(symbol.Scope == null);    // all symbols should know what scope they're in. Here it's not set.
                                                    // perhaps look at making this a rule.
            //Assert.IsTrue(symbol.Def == null);      // points to an id node in the parse tree... haven't implemented this yet.
            Assert.IsTrue(symbol.Name == "mySymbol");
        }

        [TestMethod]
        public void Test_Symbol_KnowsScope()
        {
            GlobalScope globalScope = new GlobalScope();
            LocalScope localScopeA = new LocalScope(globalScope);
            LocalScope localScopeB = new LocalScope(localScopeA);

            Symbol scopeASymbol = new Symbol("depositId", new BuiltInTypeSymbol("int"));
            localScopeA.Define(scopeASymbol);

            Assert.AreSame(localScopeA, scopeASymbol.Scope);
        }

        //[TestMethod]
        //public void Test_FunctionSymbol()
        //{
        //    FunctionSymbol functionSymbol = new FunctionSymbol("name", 2, 3, 5324234);
            
        //}

        [TestMethod]
        public void Test_MethodSymbol()
        {
            GlobalScope globalScope = new GlobalScope();
            LocalScope localScopeA = new LocalScope(globalScope);

            MethodSymbol methodSymbol = new MethodSymbol("addOne", new BuiltInTypeSymbol("int"), localScopeA);

            Symbol symbol = new Symbol("mySymbol", new BuiltInTypeSymbol("int"));
            methodSymbol.Define(symbol);

            Symbol exists = methodSymbol.Resolve("mySymbol");

            // method is both a scope and a symbol!
            Assert.IsTrue(methodSymbol is IScope);
            Assert.IsTrue(methodSymbol is Symbol);

            Assert.AreSame(methodSymbol, symbol.Scope);
            Assert.AreSame(localScopeA, methodSymbol.Scope);

            Assert.AreSame(symbol, exists);
        }
    }
}
