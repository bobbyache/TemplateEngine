using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal class ConcatenateFunction : BaseFunction
    {
        private List<BaseFunction> functions = new List<BaseFunction>();
        private GlobalTable scopeTable;

        internal ConcatenateFunction(GlobalTable scopeTable) : base(scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public override string Execute()
        {
            string result = "";
            foreach (BaseFunction func in functions)
            {
                result += func.Execute();
            }
            return result;
        }

        public void AddFunction(BaseFunction func)
        {
            functions.Add(func);
        }

    }
}
