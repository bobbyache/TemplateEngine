using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikTextFunction : QikFunction
    {
        public QikTextFunction(QikFunction func)
            : base(func)
        {

        }

        public QikTextFunction(QikLiteralText literalText)
            : base(literalText)
        {

        }

        public QikTextFunction(QikVariable variable)
            : base(variable)
        {

        }

        public override string Execute()
        {
            return base.Execute();
        }
    }
}
