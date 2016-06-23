using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public class QikOptionBoxOption
    {
        public string Symbol { get; private set; }
        public string Value { get; private set; }

        public QikOptionBoxOption(string symbol, string value)
        {
            this.Symbol = symbol;
            this.Value = value;
        }
    }
}
