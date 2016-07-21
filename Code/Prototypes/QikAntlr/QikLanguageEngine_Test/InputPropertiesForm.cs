using QikLanguageEngine;
using QikLanguageEngine.QikControls;
using QikLanguageEngine.QikExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QikLanguageEngine_Test
{
    public partial class InputPropertiesForm : Form
    {
        public InputPropertiesForm()
        {
            InitializeComponent();
            syntaxBox.Document.SyntaxFile = "qiktemplate.syn";
            // syntaxBox.Document.Text = "@exprVar = expression { return upperCase(\"yo bro\") + lowerCase(\"yo bro\") + removeSpaces(\"yo bro\"); };";
            // syntaxBox.Document.Text = "@exprVar = expression { return upperCase(\"yo bro\"); };";
            // syntaxBox.Document.Text = "@exprVar = expression { return upperCase(removeSpaces(lowerCase(\"yo bro\"))); };";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Qik engine = new Qik();
            QikControl[] controls = engine.GetControls(syntaxBox.Document.Text);
            inputPropertyGrid.Reset(controls);

            QikExpression[] expressions = engine.GetExpressions(syntaxBox.Document.Text);
        }
    }
}
