using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class IndentFunction : BaseFunction
    {
        private string indentFragment;

        internal IndentFunction(GlobalTable scopeTable, BaseFunction func, string indentFragment)
            : base(scopeTable, func)
        {
            this.indentFragment = indentFragment;
        }

        internal IndentFunction(GlobalTable scopeTable, LiteralText literalText, string indentFragment)
            : base(scopeTable, literalText)
        {
            this.indentFragment = indentFragment;
        }

        internal IndentFunction(GlobalTable scopeTable, Variable variable, string indentFragment)
            : base(scopeTable, variable)
        {
            this.indentFragment = indentFragment;
        }

        public override string Execute()
        {
            string indentedText = "";
            string txt = base.Execute();

            if (txt != null && txt.Length >= 1)
            {
                //return txt.ToLower();
                if (indentFragment.StartsWith("T"))
                {
                    int numberTimes = int.Parse(indentFragment.Replace("TAB[", "").Replace("]", ""));
                    indentedText = txt.PadLeft(txt.Length + numberTimes, '\t');
                }
                else
                {
                    int numberTimes = int.Parse(indentFragment.Replace("SPACE[", "").Replace("]", ""));
                    indentedText = txt.PadLeft(txt.Length + numberTimes, ' ');
                }
                return indentedText;
            }
            return txt;
        }
    }
}
