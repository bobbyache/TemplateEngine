using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{
    public class Symbol // a generic programming language symbol.
    {
        public enum TypeEnum
        {
            tINVALID,
            tVOID,
            tINT,
            tFLOAT
        }

        private string name { get; set; }    // All symbols at least have a name
        public IType Type { get; set; }
        public IScope Scope { get; set; } // All symbols know what scope contains them.
        public CymbolAST Def { get; set; } // points to at ID node in the tree.

        public Symbol(string name)
        {
            this.name = name;
        }

        public Symbol(string name, IType type) 
        {
            this.name = name; 
            this.Type = type; 
        }

        public string Name { get { return this.name; } }

        public override string ToString()
        {
            String s = "";
            if (this.Scope != null) s = Scope.GetScopeName() + ".";
            if (this.Type != null) return '<' + s + this.Name + ":" + this.Type + '>';
            return s + this.Name;
        }
    }
}
