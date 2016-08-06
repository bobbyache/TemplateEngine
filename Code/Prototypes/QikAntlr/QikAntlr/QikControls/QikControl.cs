using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikControls
{
    public abstract class QikControl : IQikControl
    {
        public string Symbol { get; private set; }
        public string Title { get; protected set; }
        public string DefaultValue { get; protected set; }

        private ScopeTable scopeTable;

        internal QikControl(ScopeTable scopeTable, string symbol, string defaultValue, string title)
        {
            this.Symbol = symbol;
            this.DefaultValue = QikCommon.StripOuterQuotes(defaultValue);
            this.Title = title;
            this.scopeTable = scopeTable;

            if (DefaultValue != null)
                scopeTable.UpdateSymbol(Title, Symbol, DefaultValue);
            else
                scopeTable.UpdateSymbol(Title, Symbol);
        }

        public abstract string GetCurrentValue();
        //public abstract void SetCurrentValue(string value);

        public virtual void SetCurrentValue(string value)
        {
            scopeTable.UpdateSymbol(this.Title, this.Symbol, value);
        }
    }
}
