using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public class QikOptionBoxControl : QikControl
    {
        private Dictionary<string, QikOptionBoxOption> optionsDictionary = null;

        public QikOptionBoxOption SelectedOption
        {
            get
            {
                if (optionsDictionary.ContainsKey(base.Value))
                    return optionsDictionary[base.Value];
                return null;
            }
        }

        public QikOptionBoxOption[] Options
        {
            get { return optionsDictionary.Values.ToArray(); }
        }

        public QikOptionBoxControl(string controlId, string value, Dictionary<string, QikOptionBoxOption> optionsDictionary)
            : base(controlId, value)
        {
            this.optionsDictionary = optionsDictionary;
        }
    }
}
