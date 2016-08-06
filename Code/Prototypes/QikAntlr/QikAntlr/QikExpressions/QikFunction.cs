using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikExpressions
{
    public enum QikChildInputTypeEnum
    {
        Concatenation,
        LiteralText,
        Variable,
        Function,
        IfStatement
    }

    public abstract class QikFunction
    {
        protected QikFunction childFunction = null;
        protected QikLiteralText literalText = null;
        protected QikVariable variable = null;

        private ScopeTable scopeTable;

        public QikChildInputTypeEnum InputType { get; protected set; }

        //public QikFunction(string literalText)
        //{
        //    QikLiteralText literal = new QikLiteralText(literalText);
        //    this.literalText = literal;
        //    this.InputType = QikChildInputTypeEnum.LiteralText;
        //}

        internal QikFunction(ScopeTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        internal QikFunction(ScopeTable scopeTable, QikLiteralText literalText)
        {
            this.literalText = literalText;
            this.InputType = QikChildInputTypeEnum.LiteralText;
            this.scopeTable = scopeTable;
        }

        internal QikFunction(ScopeTable scopeTable, QikFunction childFunction)
        {
            this.childFunction = childFunction;
            this.InputType = QikChildInputTypeEnum.Function;
            this.scopeTable = scopeTable;
        }

        internal QikFunction(ScopeTable scopeTable, QikVariable variable)
        {
            this.variable = variable;
            this.InputType = QikChildInputTypeEnum.Variable;
            this.scopeTable = scopeTable;
        }

        public virtual string Execute()
        {
            switch (this.InputType)
            {
                case QikChildInputTypeEnum.LiteralText:
                    return this.literalText.LiteralText;
                    
                case QikChildInputTypeEnum.Variable:
                    return scopeTable.FindSymbol(this.variable.Symbol);
                    
                case QikChildInputTypeEnum.Function:
                    return this.childFunction.Execute();
                    
                default:
                    return this.literalText.LiteralText;
            }
        }
    }
}
