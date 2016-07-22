using QikLanguageEngine;
using QikLanguageEngine.QikControls;
using QikLanguageEngine.QikExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QikLanguageEngine_Test
{
    public partial class InputPropertiesForm : Form
    {
        private Qik engine = new Qik();

        public InputPropertiesForm()
        {
            InitializeComponent();
            syntaxBox.Document.SyntaxFile = "qiktemplate.syn";
            syntaxBox.Document.Text = File.ReadAllText("Example.txt");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            engine.ExecuteScript(syntaxBox.Document.Text);

            QikControl[] controls = engine.Controls;
            QikExpression[] expressions = engine.Expressions;

            inputPropertyGrid.Reset(engine.Controls, engine.Expressions);
        }

        private void btnDisplaySymbolTable_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string symbol in engine.Symbols)
            {
                builder.AppendLine(string.Format("{0} = \"{1}\"", symbol, engine.FindSymbolValue(symbol)));
            }

            MessageBox.Show(builder.ToString());
        }
    }
}
