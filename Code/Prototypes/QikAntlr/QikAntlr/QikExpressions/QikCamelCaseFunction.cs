using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikCamelCaseFunction : QikFunction
    {
        public QikCamelCaseFunction(QikFunction func)
            : base(func)
        {

        }

        public QikCamelCaseFunction(QikLiteralText literalText)
            : base(literalText)
        {

        }

        public QikCamelCaseFunction(QikVariable variable)
            : base(variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();

            if (txt != null && txt.Length >= 1)
            {
                string firstChar = txt.Substring(0, 1);
                string theRest = txt.Substring(1, txt.Length - 1);
                return firstChar.ToLower() + theRest;
            }
            return txt;
        }
    }
}
