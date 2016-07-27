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

            controlDictionary.Add(controlId, new QikTextBoxControl(controlId, defaultText, titleText ));

            return base.VisitTextBox(context);
        }

        public override string VisitOptionBox(QikTemplateParser.OptionBoxContext context)
        {
            string controlId = context.ID().GetText();
            string defaultId = GetOptionBoxDefaultId(context);
            string titleText = GetOptionBoxTitle(context);

            QikOptionBoxControl optionBox = new QikOptionBoxControl(controlId, defaultId, titleText);

            foreach (QikTemplateParser.SingleOptionContext optionContext in context.optionsBody().singleOption())
            {
                string id = QikCommon.StripOuterQuotes(optionContext.STRING().GetText());
                string value = QikCommon.StripOuterQuotes(optionContext.titleArg().STRING().GetText());
                optionBox.AddOption(id, value);
            }

            controlDictionary.Add(optionBox.ControlId, optionBox);

            return base.VisitOptionBox(context);
        }

        public override string VisitCheckBox(QikTemplateParser.CheckBoxContext context)
        {
            string controlId = context.ID().GetText();

            string titleText = GetCheckBoxTitle(context);
            string defaultId = GetCheckBoxDefaultText(context);

            controlDictionary.Add(controlId, new QikCheckBoxControl(controlId, defaultId, titleText));

            return base.VisitCheckBox(context);
        }

        private string GetCheckBoxTitle(QikTemplateParser.CheckBoxContext context)
        {
            string titleText = null;
            if (context.checkBoxArgs().titleArg() != null)
            {
                titleText = QikCommon.StripOuterQuotes(context.checkBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetCheckBoxDefaultText(QikTemplateParser.CheckBoxContext context)
        {
            string defaultText = null;

            if (context.checkBoxArgs().defaultArg() != null)
            {
                defaultText = QikCommon.StripOuterQuotes(context.checkBoxArgs().defaultArg().STRING().GetText());
            }

            return defaultText;
        }

        private string GetOptionBoxTitle(QikTemplateParser.OptionBoxContext context)
        {
            string titleText = null;
            if (context.optionBoxArgs().titleArg() != null)
            {
                titleText = QikCommon.StripOuterQuotes(context.optionBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetTextBoxTitle(QikTemplateParser.TextBoxContext context)
        {
            string titleText = null;
            if (context.textBoxArgs().titleArg() != null)
            {
                titleText = QikCommon.StripOuterQuotes(context.textBoxArgs().titleArg().STRING().GetText());
            }
            return titleText;
        }

        private string GetOptionBoxDefaultId(QikTemplateParser.OptionBoxContext context)
        {
            string defaultId = null;

            if (context.optionBoxArgs().defaultArg() != null)
            {
                defaultId = context.optionBoxArgs().defaultArg().STRING().GetText();
            }
            return defaultId;
        }

        private string GetTextBoxDefaultText(QikTemplateParser.TextBoxContext context)
        {
            string defaultText = null;

            if (context.textBoxArgs().defaultArg() != null)
            {
                defaultText = QikCommon.StripOuterQuotes(context.textBoxArgs().defaultArg().STRING().GetText());
            }

            return defaultText;
        }
    }
}
