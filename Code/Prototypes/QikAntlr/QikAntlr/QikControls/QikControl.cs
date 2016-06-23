using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public abstract class QikControl
    {
        public string Symbol { get; private set; }
        public string Value { get; set; }

        public QikControl(string symbol, string value)
        {
            this.Symbol = symbol;
            this.Value = value;
        }
    }
}
