using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public class QikOptionBoxControl : QikControl
    {
        private Dictionary<string, QikOptionBoxOption> optionsDictionary = new Dictionary<string,QikOptionBoxOption>();

        public QikOptionBoxOption SelectedOption
        {
            get
            {
                if (base.Value != null && optionsDictionary.ContainsKey(base.Value))
                    return optionsDictionary[base.Value];
                return null;
            }
        }

        public Nullable<int> SelectedIndex
        {
            get
            {
                if (SelectedOption != null)
                {
                    return SelectedOption.Index;
                }
                return null;
            }
        }

        public QikOptionBoxOption[] Options
        {
            get { return optionsDictionary.Values.ToArray(); }
        }

        public QikOptionBoxControl(string controlId, string defaultValue, string title)
            : base(controlId, defaultValue, title)
        {
        }

        public void AddOption(string id, string value)
        {
            
            if (this.optionsDictionary.ContainsKey(id))
            {
                QikOptionBoxOption option = this.optionsDictionary[id];
                option.Value = value;
            }
            else
            {
                QikOptionBoxOption option = new QikOptionBoxOption(id, value, this.optionsDictionary.Count());
                this.optionsDictionary.Add(id, option);
            }
        }

        public string GetValueByIndex(int index)
        {
            QikOptionBoxOption[] options = optionsDictionary.Values.ToArray();
            if (options.Any(o => o.Index == index))
                return options.Where(o => o.Index == index).SingleOrDefault().Value;

            return null;
        }

        public string GetValue(string symbol)
        {
            if (optionsDictionary.ContainsKey(symbol))
                return optionsDictionary[symbol].Value;
            return null;
        }

        public int GetIndexBySymbol(string symbol)
        {
            return optionsDictionary[symbol].Index;
        }
    }
}
