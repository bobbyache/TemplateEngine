using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class NewlineFunction : BaseFunction
    {
        internal NewlineFunction() : base(null)
        {
        }

        public override string Execute()
        {
            return Environment.NewLine;
        }
    }
}
