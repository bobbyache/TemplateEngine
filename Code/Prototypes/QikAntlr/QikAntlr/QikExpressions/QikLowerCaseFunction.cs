using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikLowerCaseFunction : QikFunction
    {
        public QikLowerCaseFunction(string text) : base(text)
        {
        }

        public QikLowerCaseFunction(QikFunction func) : base(func)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            return txt.ToLower();
            //return text.ToLower();
        }
    }
}
