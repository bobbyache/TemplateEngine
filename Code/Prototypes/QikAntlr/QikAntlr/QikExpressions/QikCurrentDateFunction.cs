using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikCurrentDateFunction : QikFunction
    {
        public QikCurrentDateFunction(QikFunction func)
            : base(func)
        {

        }

        public QikCurrentDateFunction(QikLiteralText literalText)
            : base(literalText)
        {

        }

        public QikCurrentDateFunction(QikVariable variable)
            : base(variable)
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
