using CygSoft.Qik.LanguageEngine.Scope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Funcs
{
    public enum ChildInputTypeEnum
    {
        Concatenation,
        LiteralText,
        Variable,
        Function,
        IfStatement
    }

    internal class BaseFunction
    {
        protected BaseFunction childFunction = null;
        protected LiteralText literalText = null;
        protected Variable variable = null;
        private GlobalTable scopeTable = null;

        public ChildInputTypeEnum InputType { get; protected set; }

        internal BaseFunction(GlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        internal BaseFunction(GlobalTable scopeTable, LiteralText literalText)
        {
            this.literalText = literalText;
            this.InputType = ChildInputTypeEnum.LiteralText;
            this.scopeTable = scopeTable;
        }

        internal BaseFunction(GlobalTable scopeTable, BaseFunction childFunction)
        {
            this.childFunction = childFunction;
            this.InputType = ChildInputTypeEnum.Function;
            this.scopeTable = scopeTable;
        }

        internal BaseFunction(GlobalTable scopeTable, Variable variable)
        {
            this.variable = variable;
            this.InputType = ChildInputTypeEnum.Variable;
            this.scopeTable = scopeTable;
        }

        public virtual string Execute()
        {
            switch (this.InputType)
            {
                case ChildInputTypeEnum.LiteralText:
                    return this.literalText.Value;
                    
                case ChildInputTypeEnum.Variable:
                    return scopeTable.GetValueOfSymbol(this.variable.Symbol);
                    
                case ChildInputTypeEnum.Function:
                    return this.childFunction.Execute();
                    
                default:
                    return this.literalText.Value;
            }
        }

    }
}
