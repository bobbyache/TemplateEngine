using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IQikTextBoxControl : IQikControl
    {
        string GetCurrentValue();
        void SetCurrentValue(string value);
    }
}
