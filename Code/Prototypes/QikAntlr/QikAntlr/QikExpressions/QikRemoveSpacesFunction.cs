using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikRemoveSpacesFunction : QikFunction
    {
        public QikRemoveSpacesFunction(string text) : base(text)
        {
        }

        public QikRemoveSpacesFunction(QikFunction func)
            : base(func)
        {

        }

        public override string Execute()
        {
            string txt = base.Execute();
            return txt.Replace(" ", "");
        }
    }
}
