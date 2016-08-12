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
        private string indentType;
        private int noOfTimes;

        internal IndentFunction(GlobalTable scopeTable, BaseFunction func, string indentType, string noOfTimes)
            : base(scopeTable, func)
        {
            this.indentType = indentType;
            this.noOfTimes = int.Parse(noOfTimes);
        }

        internal IndentFunction(GlobalTable scopeTable, LiteralText literalText, string indentType, string noOfTimes)
            : base(scopeTable, literalText)
        {
            this.indentType = indentType;
            this.noOfTimes = int.Parse(noOfTimes);
        }

        internal IndentFunction(GlobalTable scopeTable, Variable variable, string indentType, string noOfTimes)
            : base(scopeTable, variable)
        {
            this.indentType = indentType;
            this.noOfTimes = int.Parse(noOfTimes);
        }

        public override string Execute()
        {
            string indentedText = "";
            string txt = base.Execute();

            if (txt != null && txt.Length >= 1)
            {
                if (indentType == "TAB")
                    indentedText = txt.PadLeft(txt.Length + noOfTimes, '\t');
                else // SPACE
                    indentedText = txt.PadLeft(txt.Length + noOfTimes, ' ');

                //if (indentFragment.StartsWith("T"))
                //{
                //    int numberTimes = int.Parse(indentFragment.Replace("TAB[", "").Replace("]", ""));
                //    indentedText = txt.PadLeft(txt.Length + numberTimes, '\t');
                //}
                //else
                //{
                //    int numberTimes = int.Parse(indentFragment.Replace("SPACE[", "").Replace("]", ""));
                //    indentedText = txt.PadLeft(txt.Length + numberTimes, ' ');
                //}
                return indentedText;
            }
            return txt;
        }
    }
}
