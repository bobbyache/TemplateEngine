using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IQikOptionBoxControl : IQikControl
    {
        void AddOption(string id, string value);
        void ClearSelection(bool restoreDefault);
        string GetCurrentValue();
        string GetSymbolAt(int index);
        bool HasSelection { get; }
        IQikOptionBoxOption[] Options { get; }
        int? SelectedIndex { get; }
        string SelectedSymbol { get; }
        void SelectOption(int index);
        void SelectOption(string symbol);
        void SetCurrentValue(string value);
    }
}
