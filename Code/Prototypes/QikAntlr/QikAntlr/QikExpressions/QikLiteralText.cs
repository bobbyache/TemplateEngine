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
            this.LiteralText = StripOuterQuotes(literalText);
        }

        private string StripOuterQuotes(string text)
        {
            if (text.Length != 0)
                return text.Substring(1, text.Length - 2);
            return text;
        }
    }
}
