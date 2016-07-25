using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikRemoveSpacesFunction : QikFunction
    {
        public QikRemoveSpacesFunction(QikFunction func)
            : base(func)
        {

        }

        public QikRemoveSpacesFunction(QikLiteralText literalText)
            : base(literalText)
        {

        }

        public QikRemoveSpacesFunction(QikVariable variable)
            : base(variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            if (txt != null && txt.Length >= 1)
            {
                return txt.Replace(" ", "");
            }
            return txt;
        }
    }
}
