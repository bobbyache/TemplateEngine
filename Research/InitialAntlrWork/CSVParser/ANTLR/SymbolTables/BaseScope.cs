using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Sharpen;

namespace CSVParsing.ANTLR.SymbolTables
{

    // Building a scope tree boils down to executing a sequence of these operations:
    // push, pop, and def. All of the patterns in this chapter and the
    // next populate symbol tables using these core abstract operations.
    // 
    // - push. At the start of a scope, push a new scope on the scope stack.
    // This works even for complicated scopes like classes. Because we
    // are building scope trees, push is more like an “add child” tree
    // 
    // construction operation than a conventional stack push. To make
    // things more concrete, here’s an implementation preview:
    //
    // 		// create new scope whose enclosing scope is the current scope
    // 		currentScope = new LocalScope(currentScope); // push new scope
    //
    // - pop. At the end of a scope, pop the current scope off the stack,
    // revealing the previous scope as the current scope. pop moves the
    // current scope pointer up one level in the tree:
    // 
    // 		currentScope = currentScope.getEnclosingScope(); // pop scope
    //
    // - def. Define a symbol in the current scope. We’ll always define
    // symbols like this:
    // 		Symbol s = «some-new-symbol »;
    // 		currentScope.define(s); // define s in current scope


    /*
        1. push global scope.
        2. def variable x in current scope.
        3. def method f in scope and push scope.
        4. def variable y.
        5. push local scope.
        6. def variable i.
        7. pop Ì revealing.
        8. push local scope Í.
        9. def variable j.
        10. pop Í revealing.
        11. pop function f scope revealing.
        12. def method g in scope and push scope.
        13. def variable i.
        14. pop function g scope revealing.
        15. pop global scope.

		
        // start of global scope
        int x; 							// define variable x in global scope
        Ë void f() { 					// define function f in global scope
        int y; 							// define variable y in local scope of f
            { int i; } 					// define variable i in nested local scope
            { int j; } 					// define variable j in another nested local scope
        }
        void g() { 						// define function g in global scope
        int i; 							// define variable i in local scope of g
        }
    */


    public abstract class BaseScope : IScope
    {
        // null if global (outermost) scope.
        private IScope enclosingScope;

        // Ordered because we may need to look at the order of the symbols in this scope.
        // ie.
        //      int x = 0;
        //      int y = x + 1;
        // Look for the OrderedDictionary implementation in your OneNote notes for Antlr. Might be
        // a good substitution here because he does seem to want an "ordered" dictionary.
        ConcurrentDictionary<string, Symbol> symbols = new ConcurrentDictionary<string, Symbol>();

        public List<Symbol> ScopedSymbols
        {
            get { return symbols.Values.ToList(); }
        }

        public BaseScope(IScope parent)
        {
            this.enclosingScope = parent;
        }

        public abstract string GetScopeName();

        // currentScope = currentScope.getEnclosingScope(); // pop scope
        // Will point to this.parent scope in the tree.
        public IScope GetEnclosingScope()
        {
            return enclosingScope;
        }

        // similar, will need to know if we really need this one...
        public IScope GetParentScope()
        {
            return GetEnclosingScope();
        }

        public void Define(Symbol symbol)
        {
            symbols[symbol.Name] = symbol;
            symbol.Scope = this; // track the scope in each symbol.
        }

        /*
            Here’s the best part about this algorithm and scope tree combination.
            No matter how complicated our scope tree gets, we can always resolve
            symbols with the same bit of code:
            currentScope.resolve(«symbol-name»);
         
         * The enclosingScope pointer tells resolve( ) exactly where to look next.
        */
        public Symbol Resolve(string name)
        {
            // look in this scope, return it if in this scope.
            if (symbols.ContainsKey(name))
                return symbols[name];

            // if not here then check any enclosing type.
            if (GetParentScope() != null)
                return GetParentScope().Resolve(name); // recursive

            return null; // not found in this scope or there's no parent scope.
        }

        public override string ToString()
        {
            return GetScopeName() + ":" + SymbolsToString();
        }

        private string SymbolsToString()
        {
            if (symbols.Count > 0)
                return string.Join(",", symbols.Keys.ToArray());
            else
                return string.Empty;
        }
    }
}
