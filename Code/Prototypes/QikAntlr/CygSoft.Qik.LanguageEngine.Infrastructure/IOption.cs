using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Infrastructure
{
    public interface IOption
    {
        string Value { get; set; }
        int Index { get; }
        string Title { get; }
        string Description { get; }
    }
}
