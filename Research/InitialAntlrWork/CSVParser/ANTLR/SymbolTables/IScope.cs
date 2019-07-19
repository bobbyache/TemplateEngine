using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{

    // To represent a scope, we’ll use an interface so that we can tag entities
    // like functions and classes as scopes. For example, a function is a kind
    // of Symbol that also plays the role of a scope. Scopes have pointers to
    // their enclosing scopes (we’ll talk about this more later) and can have
    // names. Scopes don’t need to track the code region from which we create
    // them. Instead, the AST for the code regions point to their scopes.
    // This makes sense because we’re going to look up symbols in scopes
    // according to what we find in the AST nodes.

    public interface IScope
    {
        string GetScopeName(); // do I have a name? some scopes like global and local scopes do not...

        /** Where to look next for symbols;  */
        IScope GetEnclosingScope(); // am I nested within another scope?

        List<Symbol> ScopedSymbols { get; }

        /** Define a symbol in the current scope */
        void Define(Symbol symbol);
        /** Look up name in this scope or in enclosing scope if not here */
        Symbol Resolve(string name);
    }
}
