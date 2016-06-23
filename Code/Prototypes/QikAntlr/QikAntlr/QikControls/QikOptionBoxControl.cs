using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public class QikOptionBoxControl : QikControl
    {
        Dictionary<string, QikOptionBoxOption> optionsDictionary;

        public QikOptionBoxControl(string symbol, string value, Dictionary<string, QikOptionBoxOption> optionsDictionary)
            : base(symbol, value)
        {
            this.optionsDictionary = optionsDictionary;
        }
    }
}
