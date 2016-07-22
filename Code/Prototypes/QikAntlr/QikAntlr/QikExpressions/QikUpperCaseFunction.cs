using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikUpperCaseFunction : QikFunction
    {
        public QikUpperCaseFunction(QikFunction func)
            : base(func)
        {

        }

        public QikUpperCaseFunction(QikLiteralText literalText)
            : base(literalText)
        {

        }

        public QikUpperCaseFunction(QikVariable variable)
            : base(variable)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            return txt.ToUpper();
        }
    }
}
