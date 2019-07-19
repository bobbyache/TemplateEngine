using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate
{
    public class Placeholder
    {
        private string regExString = null;
        public string Caption { get; private set; }
        public string Output { get; private set; }

        public Placeholder(string caption, string output, string regExString)
        {
            this.Caption = caption;
            this.Output = output;
            this.regExString = regExString;
        }
    }
}
