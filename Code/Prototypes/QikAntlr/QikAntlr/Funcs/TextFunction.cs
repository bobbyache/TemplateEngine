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

        internal TextFunction(GlobalTable scopeTable, string text) : base(scopeTable)
        {
            this.text = text;
        }

        public override string Execute()
        {
            string result = this.text.Replace(@"\n", Environment.NewLine);
            //result = result.Replace("\\\"", "\""); // doesn't work at the moment...
            result = result.Replace(@"\t", "\t");
            return result;
        }
    }
}
