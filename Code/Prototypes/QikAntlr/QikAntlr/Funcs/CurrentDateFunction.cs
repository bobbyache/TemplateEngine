using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class CurrentDateFunction : BaseFunction
    {
        internal CurrentDateFunction(GlobalTable scopeTable, BaseFunction func)
            : base(scopeTable, func)
        {

        }

        internal CurrentDateFunction(GlobalTable scopeTable, LiteralText literalText)
            : base(scopeTable, literalText)
        {

        }

        internal CurrentDateFunction(GlobalTable scopeTable, Variable variable)
            : base(scopeTable, variable)
        {

        }

        public override string Execute()
        {
            string dateFormatText = base.Execute();

            if (dateFormatText != null && dateFormatText.Length >= 1)
            {
                string dateText = DateTime.Now.ToString(dateFormatText);
                return dateText;
            }
            return "";
        }
    }
}
