using QikAntlr.Antlr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CygSoft.Qik.LanguageEngine.Antlr
{
    internal class SymbolArguments
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Default { get; private set; }
        public bool IsVisibleToEditor { get; private set; }
        public bool IsPlaceholder { get; private set; }

        public SymbolArguments()
        {
            this.IsVisibleToEditor = true;
            this.IsPlaceholder = true;
        }

        public void Process(QikTemplateParser.DeclArgsContext context)
        {
            foreach (QikTemplateParser.DeclArgContext declArg in context.declArg())
            {
                if (declArg.IDENTIFIER() != null)
                {
                    string identifier = declArg.IDENTIFIER().GetText();
                    string value = Common.StripOuterQuotes(declArg.STRING().GetText());

                    switch (identifier)
                    {
                        case "Title":
                            this.Title = value;
                            break;
                        case "Description":
                            this.Description = value;
                            break;
                        case "Default":
                            this.Default = value;
                            break;
                        case "IsVisibleToEditor":
                            this.IsVisibleToEditor = bool.Parse(value);
                            break;
                        case "IsPlaceholder":
                            this.IsPlaceholder = bool.Parse(value);
                            break;
                        default:
                            throw new NotSupportedException(string.Format("Declaration argument \"{0}\" is not supported in this context.", identifier));
                    }
                }
            }
        }
    }
}
