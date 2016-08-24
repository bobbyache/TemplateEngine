using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Scope
{
    internal class GlobalTable
    {
        private class SymbolInfo : ISymbolInfo
        {
            public string Symbol { get; private set; }
            public string Placeholder { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }

            public SymbolInfo(string placeholder, string symbol, string title, string description)
            {
                this.Symbol = symbol;
                this.Placeholder = placeholder;
                this.Title = title;
                this.Description = description;
            }
        }

        private Dictionary<string, BaseSymbol> table = new Dictionary<string, BaseSymbol>();

        public string[] Symbols
        {
            get
            {
                if (table.Keys.Select(r => r).Any())
                    return table.Keys.Select(r => r).ToArray();
                else
                    return new string[0];
            }
        }

        public string[] Placeholders
        {
            get
            {
                if (table.Values.Where(r => r.IsPlaceholder == true).Any())
                    return table.Values.Where(r => r.IsPlaceholder == true).Select(r => r.Placeholder).ToArray();
                //if (table.Values.Select(r => r).Any())
                //    return table.Values.Select(r => r.Placeholder).ToArray();
                else
                    return new string[0];
            }
        }

        public IInputField[] InputFields { get { return this.table.Values.OfType<IInputField>().ToArray(); } }
        public IExpression[] Expressions { get { return this.table.Values.OfType<IExpression>().ToArray(); } }

        internal void Clear()
        {
            table.Clear();
        }

        internal void AddSymbol(BaseSymbol symbol)
        {
            if (!table.ContainsKey(symbol.Symbol))
            {
                table.Add(symbol.Symbol, symbol);
            }
        }

        internal void Input(string inputSymbol, string value)
        {
            if (table.ContainsKey(inputSymbol))
            {
                TextInputSymbol textInputSymbol = table[inputSymbol] as TextInputSymbol;
                if (textInputSymbol != null)
                    textInputSymbol.SetValue(value);

                OptionInputSymbol optionInputSymbol = table[inputSymbol] as OptionInputSymbol;
                if (optionInputSymbol != null)
                    optionInputSymbol.SelectOption(value);
            }
        }

        public ISymbolInfo GetPlaceholderInfo(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                ISymbolInfo placeholderInfo =
                    new SymbolInfo(baseSymbol.Placeholder, baseSymbol.Symbol, baseSymbol.Title, baseSymbol.Description);
                return placeholderInfo;
            }

            return null;
        }

        public ISymbolInfo GetSymbolInfo(string symbol)
        {
            if (table.ContainsKey(symbol))
            {
                BaseSymbol baseSymbol = table[symbol];
                ISymbolInfo symbolInfo =
                    new SymbolInfo(baseSymbol.Placeholder, baseSymbol.Symbol, baseSymbol.Title, baseSymbol.Description);
                return symbolInfo;
            }
            return null;
        }

        public string GetValueOfSymbol(string symbol)
        {
            if (table.ContainsKey(symbol))
            {
                BaseSymbol baseSymbol = table[symbol];
                return baseSymbol.Value;
            }
            return null;
        }

        public string GetValueOfPlacholder(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                return baseSymbol.Value;
            }

            return null;
        }

        public string GetTitleOfPlacholder(string placeholder)
        {
            List<BaseSymbol> symbols = table.Values.Cast<BaseSymbol>().ToList();

            if (symbols.Any(s => s.Placeholder == placeholder))
            {
                BaseSymbol baseSymbol = symbols.Where(s => s.Placeholder == placeholder).SingleOrDefault() as BaseSymbol;
                return baseSymbol.Title;
            }

            return null;
        }
    }
}
