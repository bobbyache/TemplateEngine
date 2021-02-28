using CygSoft.Qik.LanguageEngine.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CygSoft.Qik.LanguageEngine.Symbols
{
    internal class OptionInputSymbol : InputSymbol, IOptionsField
    {
        private class SymbolOption : IOption
        {
            public string Value { get; set; }
            public int Index { get; }
            public string Title { get; }
            public string Description { get; }

            internal SymbolOption(string value, int index, string title, string description)
            {
                Value = value;
                Index = index;
                Title = title;
                Description = description;
            }
        }

        private SymbolOption currentOption = null;
        private readonly Dictionary<string, SymbolOption> optionsDictionary = new Dictionary<string, SymbolOption>();

        public OptionInputSymbol(string symbol, string title, string description, string defaultValue = null, bool isPlaceholder = true)
            : base(symbol, title, description, defaultValue, isPlaceholder)
        {

        }

        public OptionInputSymbol(string symbol, string title, string description, string defaultValue, bool isPlaceholder, string prefix, string postfix)
            : base(symbol, title, description, defaultValue, isPlaceholder, prefix, postfix)
        {

        }

        public IOption[] Options => optionsDictionary.Values.ToArray();

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

        public void AddOption(string value, string title, string description = null)
        {

            if (optionsDictionary.ContainsKey(value))
            {
                var option = optionsDictionary[value];
                option.Value = value;
            }
            else
            {
                var option = new SymbolOption(value, optionsDictionary.Count(), title, description);
                optionsDictionary.Add(value, option);
            }

            if (value == DefaultValue)
                currentOption = optionsDictionary[value];
        }

        public void SelectOption(string option)
        {
            var options = optionsDictionary.Values.ToArray();

            if (int.TryParse(option, out int index))
            {
                if (options.Any(o => o.Index == index))
                {
                    string value = options.Where(o => o.Index == index).SingleOrDefault().Value;
                    currentOption = options.Where(o => o.Index == index).SingleOrDefault();
                }
            }

            else if (options.Any(o => o.Value == option))
            {
                string value = options.Where(o => o.Value == option).SingleOrDefault().Value;
                currentOption = options.Where(o => o.Value == option).SingleOrDefault();
            }

            else
                currentOption = null;
        }

        public void SelectOption(int optionIndex)
        {
            // will always look at the index.
            var options = optionsDictionary.Values.ToArray();

            if (options.Any(o => o.Index == optionIndex))
            {
                string value = options.Where(o => o.Index == optionIndex).SingleOrDefault().Value;
                currentOption = options.Where(o => o.Index == optionIndex).SingleOrDefault();
            }
        }

        public string OptionTitle(string option)
        {
            var options = optionsDictionary.Values.ToArray();
            string title = null;

            if (int.TryParse(option, out int index))
            {
                if (options.Any(o => o.Index == index))
                    title = options.Where(o => o.Index == index).SingleOrDefault().Title;
            }

            else if (options.Any(o => o.Value == option))
            {
                title = options.Where(o => o.Value == option).SingleOrDefault().Title;
            }

            return title;
        }

        public string OptionTitle(int optionIndex)
        {
            var options = optionsDictionary.Values.ToArray();
            string title = null;

            if (options.Any(o => o.Index == optionIndex))
                title = options.Where(o => o.Index == optionIndex).SingleOrDefault().Title;

            return title;
        }
    }
}
