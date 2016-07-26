using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
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

        public QikChildInputTypeEnum InputType { get; protected set; }

        //public QikFunction(string literalText)
        //{
        //    QikLiteralText literal = new QikLiteralText(literalText);
        //    this.literalText = literal;
        //    this.InputType = QikChildInputTypeEnum.LiteralText;
        //}

        public QikFunction()
        {
        }

        public QikFunction(QikLiteralText literalText)
        {
            this.literalText = literalText;
            this.InputType = QikChildInputTypeEnum.LiteralText;
        }

        public QikFunction(QikFunction childFunction)
        {
            this.childFunction = childFunction;
            this.InputType = QikChildInputTypeEnum.Function;
        }

        public QikFunction(QikVariable variable)
        {
            this.variable = variable;
            this.InputType = QikChildInputTypeEnum.Variable;
        }

        public virtual string Execute()
        {
            switch (this.InputType)
            {
                case QikChildInputTypeEnum.LiteralText:
                    return this.literalText.LiteralText;
                    
                case QikChildInputTypeEnum.Variable:
                    return ScopeTable.FindSymbol(this.variable.Symbol);
                    
                case QikChildInputTypeEnum.Function:
                    return this.childFunction.Execute();
                    
                default:
                    return this.literalText.LiteralText;
            }
        }
    }
}
