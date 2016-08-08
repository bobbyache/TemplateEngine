using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IQikCompiler
    {
        IQikExpression[] Expressions { get; }
        IQikControl[] Controls { get; }

        void ExecuteScript(string inputData);
        
        string FindOutput(string placeholder);
        string FindSymbolValue(string symbol);
        string FindTitle(string placeholder);
        string[] Placeholders { get; }
        string[] Symbols { get; }

        void UpdateControl(string symbol, string value);
        //void CalculateExpressions();
        string ResolveExpression(string symbol);
    }
}
