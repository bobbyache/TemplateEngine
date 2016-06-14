using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing.ANTLR.SymbolTables
{
    public class GlobalScope : BaseScope
    {
        public GlobalScope() : base(null) { }
        public override string GetScopeName()
        {
            return "global";
        }
    }
}
