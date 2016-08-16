using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    internal abstract class BaseFunction
    {
        protected GlobalTable scopeTable = null;
        protected List<BaseFunction> functionArguments;

        internal BaseFunction(GlobalTable scopeTable, List<BaseFunction> functionArguments)
        {
            this.scopeTable = scopeTable;
            this.functionArguments = functionArguments;
        }

        internal BaseFunction(GlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
            this.functionArguments = new List<BaseFunction>();
        }

        public abstract string Execute();

        //public virtual string Execute()
        //{
        //    switch (this.InputType)
        //    {
        //        case ChildInputTypeEnum.LiteralText:
        //            return this.literalText.Value;
                    
        //        case ChildInputTypeEnum.Variable:
        //            return scopeTable.GetValueOfSymbol(this.variable.Symbol);
                    
        //        case ChildInputTypeEnum.Function:
        //            return this.childFunction.Execute();
                    
        //        default:
        //            return this.literalText.Value;
        //    }
        //}

    }
}
