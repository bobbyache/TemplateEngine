using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface ISymbol
    {
        string Symbol { get; }
        string Title { get; }
        string Description { get; }
        string Value { get; }
        string Placeholder { get; }
        bool IsPlaceholder { get; }
    }
}
