using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{
    public class MethodSymbol : Symbol, IScope
    {
        private Dictionary<string, Symbol> orderedArgs = new Dictionary<string, Symbol>();
        private IScope enclosingScope;

        public MethodSymbol(string name, IType retType, IScope enclosingType) : base(name, retType)
        {
            //this.Scope = enclosingScope;
            this.enclosingScope = enclosingType;
        }

        public List<Symbol> ScopedSymbols
        {
            get { return orderedArgs.Values.ToList(); }
        }

        public string GetScopeName()
        {
            return this.Name;
        }

        public IScope GetEnclosingScope()
        {
            return enclosingScope;
        }

        public void Define(Symbol symbol)
        {
            orderedArgs[symbol.Name] = symbol;
            symbol.Scope = this; // track the scope in each variable.
        }

        public Symbol Resolve(string name)
        {
            if (orderedArgs.ContainsKey(name))
                return orderedArgs[name];

            // if not here then check any enclosing scope.
            if (GetEnclosingScope() != null)
                return GetEnclosingScope().Resolve(name); // recursive

            return null; // not found in this scope or there's no parent scope.
        }

        public override string ToString()
        {
            return "method" + base.ToString() + ":" + OrderedArgsToString();
        }

        private string OrderedArgsToString()
        {
            if (orderedArgs.Count > 0)
                return string.Join(", ", orderedArgs.Keys.ToArray());
            else
                return string.Empty;
        }
    }
}
