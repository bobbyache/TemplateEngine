using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IQikOptionBoxOption
    {
        int Index { get; }
        string Symbol { get; }
        string Value { get; set; }
    }
}
