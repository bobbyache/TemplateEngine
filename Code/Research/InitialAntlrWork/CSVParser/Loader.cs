using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParsing
{
    // java -jar antlr-4.5-complete.jar -Dlanguage=CSharp "CSV.g4" -visitor
    // P. 129, 131

    public class Loader : CSVBaseListener
    {
        public readonly string EMPTY = "";

        public List<Dictionary<string, string>> Rows = new List<Dictionary<string,string>>();
        private List<string> header;
        private List<string> currentRowFieldValues = new List<string>();

        public override void ExitString(CSVParser.StringContext context)
        {
            base.ExitString(context);
            currentRowFieldValues.Add(context.STRING().GetText());
        }

        public override void ExitText(CSVParser.TextContext context)
        {
            base.ExitText(context);
            currentRowFieldValues.Add(context.TEXT().GetText());
        }

        public override void ExitEmpty(CSVParser.EmptyContext context)
        {
            base.ExitEmpty(context);
            currentRowFieldValues.Add(EMPTY);
        }

        // before we can process the rows, we'll need to get the list of column names
        // from the first row:
        public override void ExitHdr(CSVParser.HdrContext context)
        {
            base.ExitHdr(context);
            header = new List<string>();
            header.AddRange(currentRowFieldValues);
        }

        public override void EnterRow(CSVParser.RowContext context)
        {
            base.EnterRow(context);
            currentRowFieldValues = new List<string>();

        }

        public override void ExitRow(CSVParser.RowContext context)
        {
            base.ExitRow(context);

            
            if (context.Parent.RuleIndex == CSVParser.RULE_hdr)
                return;

            Dictionary<string, string> m = new Dictionary<string, string>();
            int i = 0;
            foreach (string v in currentRowFieldValues)
            {
                m.Add(header[i], v);
                i++;
            }
            Rows.Add(m);
        }
    }
}
