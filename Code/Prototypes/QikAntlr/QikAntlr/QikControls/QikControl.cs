using QikLanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikControls
{
    public abstract class QikControl
    {
        public string ControlId { get; private set; }
        public string Title { get; protected set; }
        public string DefaultValue { get; protected set; }

        public QikControl(string controlId, string defaultValue, string title)
        {
            this.ControlId = controlId;
            this.DefaultValue = defaultValue;
            this.Title = title;
            if (DefaultValue != null)
                ScopeTable.UpdateSymbol(ControlId, DefaultValue);
            else
                ScopeTable.UpdateSymbol(ControlId);
        }

        public abstract string GetCurrentValue();
        //public abstract void SetCurrentValue(string value);

        public virtual void SetCurrentValue(string value)
        {
            ScopeTable.UpdateSymbol(this.ControlId, value);
        }
    }
}
