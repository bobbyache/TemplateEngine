using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IOptionsField : IInputField
    {
        int? SelectedIndex { get; }
        IOption[] Options { get; }
        string OptionTitle(string option);
        string OptionTitle(int optionIndex);
        void SelectOption(string option);
        void SelectOption(int optionIndex);
    }
}
