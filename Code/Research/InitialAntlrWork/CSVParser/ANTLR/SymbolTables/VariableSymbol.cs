using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{
    // Symbols can be of type: Variable, Class, Function, Struct...
    public class VariableSymbol : Symbol
    {
        public VariableSymbol(string name, IType type) : base(name, type) {}
    }
}
