using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Tree.Pattern;

namespace CSVParsing.ANTLR.SymbolTables
{
    // AST = Abstract Symbol Tree.
    public class CymbolAST : Antlr4.Runtime.Tree.TerminalNodeImpl
    {
        public IScope Scope { get; set; }
        public Symbol Symbol { get; set; }
        public CymbolAST(IToken token) : base(token) { }
    }
}
