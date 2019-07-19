using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class TextFunction : BaseFunction
    {
        private string text;

        internal TextFunction(FuncInfo funcInfo, GlobalTable scopeTable, string text) : base(funcInfo, scopeTable)
        {
            this.text = text;
        }

        public override string Execute(IErrorReport errorReport)
        {
            // NB !!! You don't ever want to do this, rather create a "doubleQuote" func or something
            // you might want literal text as replacement into code!

            //string result = this.text.Replace(@"\n", Environment.NewLine);
            ////result = result.Replace("\\\"", "\""); // doesn't work at the moment...
            //result = result.Replace(@"\t", "\t");
            //return result;

            return this.text;
        }
    }
}
