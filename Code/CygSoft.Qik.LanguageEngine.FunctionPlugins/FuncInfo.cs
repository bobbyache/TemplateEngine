using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.FunctionPlugins
{
    public class FuncInfo
    {
        public int Line { get; private set; }
        public int Column { get; private set; }
        public string Name { get; private set; }

        public FuncInfo(string name, int line, int column)
        {
            this.Line = line;
            this.Column = column;
            this.Name = name;
        }
    }
}
