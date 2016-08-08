using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IQikCompiler
    {
        CygSoft.Qik.LanguageEngine.Infrastructure.IQikControl[] Controls { get; }
        void ExecuteScript(string inputData);
        CygSoft.Qik.LanguageEngine.Infrastructure.IQikExpression[] Expressions { get; }
        string FindOutput(string placeholder);
        string FindSymbolValue(string symbol);
        string FindTitle(string placeholder);
        string[] Placeholders { get; }
        string[] Symbols { get; }
    }
}
