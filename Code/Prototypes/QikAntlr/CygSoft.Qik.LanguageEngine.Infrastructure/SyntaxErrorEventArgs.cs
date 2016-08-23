using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public sealed class SyntaxErrorEventArgs : EventArgs
    {
        public int Line { get; private set; }
        public int Column { get; private set; }
        public string Message { get; private set; }
        public string OffendingSymbol { get; private set; }
        public string RuleStack { get; private set; }

        public SyntaxErrorEventArgs(string stack, int line, int column, string offendingSymbol, string message)
        {
            this.Line = line;
            this.Column = column;
            this.Message = message;
            this.OffendingSymbol = offendingSymbol;
            this.RuleStack = stack;
        }
    }
}
