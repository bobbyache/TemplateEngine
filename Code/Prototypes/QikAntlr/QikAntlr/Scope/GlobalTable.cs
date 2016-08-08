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
                if (table.Values.Select(r => r).Any())
                    return table.Values.Select(r => r.Placeholder).ToArray();
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
