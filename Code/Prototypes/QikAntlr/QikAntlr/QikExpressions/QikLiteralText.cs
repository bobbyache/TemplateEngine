using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikLiteralText
    {
        public string LiteralText { get; private set; }

        public QikLiteralText(string literalText)
        {
            this.LiteralText = QikCommon.StripOuterQuotes(literalText);
        }
    }
}
