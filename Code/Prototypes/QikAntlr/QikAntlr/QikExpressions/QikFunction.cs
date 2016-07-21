using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public abstract class QikFunction
    {
        protected string text;
        protected QikFunction childFunction;

        public QikFunction(string text)
        {
            this.text = StripOuterQuotes(text);
            this.childFunction = null;
        }

        public QikFunction(QikFunction childFunction)
        {
            this.text = null;
            this.childFunction = childFunction;
        }

        //public abstract string Execute();

        public virtual string Execute()
        {
            if (this.childFunction == null)
            {
                return this.text;
            }
            else
            {
                return childFunction.Execute();
            }
        }

        private string StripOuterQuotes(string text)
        {
            if (text.Length != 0)
                return text.Substring(1, text.Length - 2);
            return text;
        }
    }
}
