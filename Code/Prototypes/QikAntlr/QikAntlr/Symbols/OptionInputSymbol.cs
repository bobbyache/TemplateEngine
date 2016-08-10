using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal class OptionInputSymbol : InputSymbol, IOptionsField
    {
        private class SymbolOption : IOption
        {
            public string Value { get; set; }
            public int Index { get; private set; }
            public string Title { get; private set; }

            internal SymbolOption(string value, int index, string title)
            {
                this.Value = value;
                this.Index = index;
                this.Title = title;
            }
        }

        private SymbolOption currentOption = null;
        private Dictionary<string, SymbolOption> optionsDictionary = new Dictionary<string, SymbolOption>();

        public OptionInputSymbol(string symbol, string title, string defaultValue = null) : base(symbol, title, defaultValue)
        {

        }

        public OptionInputSymbol(string symbol, string title, string defaultValue, string prefix, string postfix)
            : base(symbol, title, defaultValue, prefix, postfix)
        {

        }

        public IOption[] Options { get { return this.optionsDictionary.Values.ToArray(); } }

        public override string Value
        {
            get 
            {
                if (currentOption == null)
                    return null;
                return currentOption.Value; 
            }
        }

        public int? SelectedIndex 
        { 
            get 
            {
                if (currentOption == null)
                    return null;
                return currentOption.Index; 
            } 
        }

        public void AddOption(string value, string title)
        {

            if (this.optionsDictionary.ContainsKey(value))
            {
                SymbolOption option = this.optionsDictionary[value];
                option.Value = value;
            }
            else
            {
                SymbolOption option = new SymbolOption(value, this.optionsDictionary.Count(), title);
                this.optionsDictionary.Add(value, option);
            }

            if (value == this.DefaultValue)
                currentOption = optionsDictionary[value];
        }

        public void SelectOption(string option)
        {
            SymbolOption[] options = optionsDictionary.Values.ToArray();

            int index;
            bool isIndex = int.TryParse(option, out index);

            if (isIndex)
            {
                if (options.Any(o => o.Index == index))
                {
                    string value = options.Where(o => o.Index == index).SingleOrDefault().Value;
                    this.currentOption = options.Where(o => o.Index == index).SingleOrDefault();
                }
            }

            else if (options.Any(o => o.Value == option))
            {
                string value = options.Where(o => o.Value == option).SingleOrDefault().Value;
                this.currentOption = options.Where(o => o.Value == option).SingleOrDefault();
            }

            else
                this.currentOption = null;
        }

        public void SelectOption(int optionIndex)
        {
            // will always look at the index.
            SymbolOption[] options = optionsDictionary.Values.ToArray();

            int index = optionIndex;

            if (options.Any(o => o.Index == index))
            {
                string value = options.Where(o => o.Index == index).SingleOrDefault().Value;
                this.currentOption = options.Where(o => o.Index == index).SingleOrDefault();
            }
        }

        public string OptionTitle(string option)
        {
            SymbolOption[] options = optionsDictionary.Values.ToArray();

            int index;
            bool isIndex = int.TryParse(option, out index);

            string title = null;

            if (isIndex)
            {
                if (options.Any(o => o.Index == index))
                {
                    title = options.Where(o => o.Index == index).SingleOrDefault().Title;
                }
            }

            else if (options.Any(o => o.Value == option))
            {
                title = options.Where(o => o.Value == option).SingleOrDefault().Title;
            }

            return title;
        }

        public string OptionTitle(int optionIndex)
        {
            SymbolOption[] options = optionsDictionary.Values.ToArray();
            int index = optionIndex;
            string title = null;

            if (options.Any(o => o.Index == index))
            {
                title = options.Where(o => o.Index == index).SingleOrDefault().Title;
            }

            return title;
        }
    }
}
