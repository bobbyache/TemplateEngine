using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<Placeholder> placeholders = new List<Placeholder>();
            placeholders.Add(new Placeholder("Simple", "@{var}", ""));
            placeholders.Add(new Placeholder("Upper Case", "@{var:toUpper}", ""));
            placeholders.Add(new Placeholder("Lower Case", "@{var:toLower}", ""));
            placeholders.Add(new Placeholder("Camel Case", "@{var:toCamel}", ""));

            placeholders.Add(new Placeholder("Variable Case", "@{var:case(upper,killSpacing)}", ""));

            quickTemplateBox1.ResetPlaceholders(placeholders.ToArray());
        }
    }
}
