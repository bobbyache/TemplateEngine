using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{
    // Symbols can be of type: Variable, Class, Function, Struct...
    public class FunctionSymbol
    {
        string name;
        int nargs;
        int nlocals;
        int address;

        public FunctionSymbol(string name)
        {
            this.name = name;
        }

        public FunctionSymbol(string name, int nargs, int nlocals, int address)
        {
            this.name = name;
            this.nargs = nargs;
            this.nlocals = nlocals;
            this.address = address;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FunctionSymbol && name.Equals(((FunctionSymbol)obj).name);
        }

        public override string ToString()
        {
            return "FunctionSymbol{" +
                   "name='" + name + '\'' +
                   ", args=" + nargs +
                   ", locals=" + nlocals +
                   ", address=" + address +
                   '}';
        }
    }
}
