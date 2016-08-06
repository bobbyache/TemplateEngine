using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public class QikTextBoxControl : QikControl
    {
        private string currentValue = null;

        internal QikTextBoxControl(ScopeTable scopeTable, string symbol, string value, string title)
            : base(scopeTable, symbol, value, title)
        {
            this.currentValue = value;
        }

        public override  void SetCurrentValue(string value)
        {
            base.SetCurrentValue(value);
            this.currentValue = value;
        }

        public override string GetCurrentValue()
        {
            return this.currentValue;
        }
    }
}
