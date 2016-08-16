using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class LiteralTextFunction : BaseFunction
    {
        private string text;

        public LiteralTextFunction(GlobalTable scopeTable, string text) : base(scopeTable)
        {
            this.text = text;
        }

        public override string Execute()
        {
            return this.text;
        }

    }
}
