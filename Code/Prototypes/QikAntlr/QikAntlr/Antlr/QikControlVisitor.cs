using QikAntlr.Antlr;
using QikLanguageEngine.QikControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.Antlr
{
    public class QikControlVisitor : QikTemplateBaseVisitor<string>
    {
        private Dictionary<string, QikControl> controlDictionary = new Dictionary<string, QikControl>();
        public Dictionary<string, QikControl> ControlDictionary
        {
            get { return this.controlDictionary; }
        }

        public override string VisitTextBox(QikTemplateParser.TextBoxContext context)
        {
            string controlId = context.ID().GetText();

            string titleText = GetTextBoxTitle(context);
            string defaultText = GetTextBoxDefaultText(context);

            controlDictionary.Add(controlId, new QikTextBoxControl(controlId, defaultText));

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            Dictionary<string, QikOptionBoxOption> optionsDictionary = new Dictionary<string,QikOptionBoxOption>();

            string controlId = context.ID().GetText();

            string titleText = GetOptionBoxTitle(context);
            string defaultId = GetOptionBoxDefaultId(context);

            foreach (QikTemplateParser.SingleOptionContext optionContext in context.optionsBody().singleOption())
            {
                string id = optionContext.ID().GetText();
                string value = StripQuotes(optionContext.valueArg().STRING().GetText());
                optionsDictionary.Add(id, new QikOptionBoxOption(id, value));
            }

            controlDictionary.Add(controlId, new QikOptionBoxControl(controlId, defaultId, optionsDictionary));

            return base.VisitOptionBox(context);
        }

        private string GetOptionBoxTitle(QikTemplateParser.OptionBoxContext context)
        {
            string titleText = null;
            if (context.optionBoxArgs().titleArg() != null)
            {
                titleText = StripQuotes(context.optionBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetTextBoxTitle(QikTemplateParser.TextBoxContext context)
        {
            string titleText = null;
            if (context.textBoxArgs().titleArg() != null)
            {
                titleText = StripQuotes(context.textBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetOptionBoxDefaultId(QikTemplateParser.OptionBoxContext context)
        {
            string defaultId = null;

            if (context.optionBoxArgs().defaultArg() != null)
            {
                defaultId = context.optionBoxArgs().defaultArg().ID().GetText();
            }
            return defaultId;
        }

        private string GetTextBoxDefaultText(QikTemplateParser.TextBoxContext context)
        {
            string defaultText = null;

            if (context.textBoxArgs().defaultArg() != null)
            {
                StripQuotes(context.textBoxArgs().defaultArg().STRING().GetText());
            }

            return defaultText;
        }

        private string StripQuotes(string text)
        {
            return text.Replace("\"", "");
        }
    }
}
