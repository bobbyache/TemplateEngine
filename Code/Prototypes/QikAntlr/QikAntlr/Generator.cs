using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine
{
    public class Generator : IGenerator
    {
        public string Generate(ICompiler compiler, string templateText)
        {
            string input = templateText;

            foreach (string placeholder in compiler.Placeholders)
            {
                string output = compiler.GetValueOfPlaceholder(placeholder);
                input = input.Replace(placeholder, output);
            }

            return input;
        }
    }
}
