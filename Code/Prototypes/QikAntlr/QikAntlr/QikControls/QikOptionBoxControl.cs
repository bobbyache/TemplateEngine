using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.QikScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.QikControls
{
    public class QikOptionBoxControl : QikControl, IQikOptionBoxControl
    {
        private QikOptionBoxOption selectedOption = null;
        private Dictionary<string, QikOptionBoxOption> optionsDictionary = new Dictionary<string,QikOptionBoxOption>();

        /// <summary>
        /// Index is used for any UI controls that might need to use an integer index rather than a
        /// a text-based symbol identifier.
        /// </summary>
        public Nullable<int> SelectedIndex
        {
            get { return this.selectedOption == null ? new Nullable<int>() : this.selectedOption.Index; }
        }

        public string SelectedSymbol { get { return this.selectedOption == null ? null : this.selectedOption.Symbol; } }

        public bool HasSelection
        {
            get
            {
                return this.selectedOption != null && this.optionsDictionary.ContainsKey(this.selectedOption.Symbol);
            }
        }

        public IQikOptionBoxOption[] Options
        {
            get { return optionsDictionary.Values.ToArray(); }
        }

        internal QikOptionBoxControl(ScopeTable scopeTable, string controlId, string defaultValue, string title)
            : base(scopeTable, controlId, defaultValue, title)
        {
        }

        public void AddOption(string id, string value)
        {
            
            if (this.optionsDictionary.ContainsKey(id))
            {
                QikOptionBoxOption option = this.optionsDictionary[id];
                option.Value = value;
                if (id == this.DefaultValue)
                    this.selectedOption = option;
            }
            else
            {
                QikOptionBoxOption option = new QikOptionBoxOption(id, value, this.optionsDictionary.Count());
                this.optionsDictionary.Add(id, option);
                if (id == this.DefaultValue)
                    this.selectedOption = option;
            }

        }

        public override string GetCurrentValue()
        {
            if (this.selectedOption != null)
                return this.selectedOption.Symbol;
            return null;
        }

        public override void SetCurrentValue(string value)
        {
            base.SetCurrentValue(value);
            this.SelectOption(value);
        }

        public void ClearSelection(bool restoreDefault)
        {
            this.selectedOption = null;
            if (restoreDefault)
                SelectOption(this.DefaultValue);
        }

        public void SelectOption(int index)
        {
            QikOptionBoxOption[] options = optionsDictionary.Values.ToArray();
            if (options.Any(o => o.Index == index))
            {
                string value = options.Where(o => o.Index == index).SingleOrDefault().Symbol;
                base.SetCurrentValue(value);
                this.selectedOption = options.Where(o => o.Index == index).SingleOrDefault();
            }
        }

        public void SelectOption(string symbol)
        {
            QikOptionBoxOption[] options = optionsDictionary.Values.ToArray();
            if (options.Any(o => o.Symbol == symbol))
            {
                string value = options.Where(o => o.Symbol == symbol).SingleOrDefault().Symbol;
                base.SetCurrentValue(value);
                this.selectedOption = options.Where(o => o.Symbol == symbol).SingleOrDefault();
            }
        }

        public string GetSymbolAt(int index)
        {
            QikOptionBoxOption[] options = optionsDictionary.Values.ToArray();
            if (options.Any(o => o.Index == index))
                return options.Where(o => o.Index == index).SingleOrDefault().Symbol;

            return null;
        }
    }
}
