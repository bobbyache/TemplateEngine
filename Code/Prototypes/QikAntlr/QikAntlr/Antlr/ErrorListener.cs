using Antlr4.Runtime;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    internal class ErrorListener : BaseErrorListener
    {
        public event EventHandler<SyntaxErrorEventArgs> SyntaxErrorDetected;

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            //base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
            IList<string> stack = ((Parser)recognizer).GetRuleInvocationStack();
            stack.Reverse();
            //System.Diagnostics.Debug.WriteLine("rule stack: " + stack.ToString());
            //System.Diagnostics.Debug.WriteLine("line " + line + ":" + charPositionInLine + " at " + offendingSymbol + ": " + msg);

            if (SyntaxErrorDetected != null)
            {
                SyntaxErrorDetected(this, new SyntaxErrorEventArgs(stack.ToString(), line, charPositionInLine, offendingSymbol.ToString(), msg));
            }
        }
    }
}
