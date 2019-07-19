using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrArrayInit
{
    internal class ShortToUnicodeString : ArrayInitBaseListener
    {
        public string OutputText { get; private set; }

        public override void EnterInit(ArrayInitParser.InitContext context)
        {
            base.EnterInit(context);
            this.OutputText += "\"";
            System.Diagnostics.Debug.WriteLine("\"");
        }

        public override void ExitInit(ArrayInitParser.InitContext context)
        {
            base.ExitInit(context);
            this.OutputText += "\"";
            System.Diagnostics.Debug.WriteLine("\"");
        }

        public override void EnterValue(ArrayInitParser.ValueContext context)
        {
            base.EnterValue(context);
            int value = Convert.ToInt32(context.INT().GetText());
            this.OutputText += string.Format("\\u{0}", value.ToString("X" + 4));
            System.Diagnostics.Debug.WriteLine("\\u{0}", value.ToString("X" + 4));
        }
    }
}
