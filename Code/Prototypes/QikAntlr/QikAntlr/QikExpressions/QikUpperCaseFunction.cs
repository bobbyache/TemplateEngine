using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikUpperCaseFunction : QikFunction
    {
        public QikUpperCaseFunction(string text) : base(text)
        {
        }

        public QikUpperCaseFunction(QikFunction func)
            : base(func)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            return txt.ToUpper();
        }
    }
}
