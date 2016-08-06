using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikControls
{
    public class QikOptionBoxOption
    {
        public string Symbol { get; private set; }
        public string Value { get; set; }
        public int Index { get; private set; }

        public QikOptionBoxOption(string symbol, string value, int index)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.Index = index;
        }
    }
}
