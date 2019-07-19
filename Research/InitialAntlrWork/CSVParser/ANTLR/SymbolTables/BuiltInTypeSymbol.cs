using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{

    // Symbols can be of type: Variable, Class, Function, Struct...

    //To distinguish between user-defined types and other program symbols,
    //it’s a good idea to tag types with a Type interface. For example, here’s
    //the class that represents built-in types like int and float:

    public class BuiltInTypeSymbol : Symbol, IType
    {
        public BuiltInTypeSymbol(string name) : base(name)
        {

        }
    }
}
