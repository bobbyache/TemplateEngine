using QikLanguageEngine;
using QikLanguageEngine.QikControls;
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Qik engine = new Qik();
            QikControl[] controls = engine.GetUserInputControls(syntaxBox.Document.Text);
            inputPropertyGrid.Reset(controls);

            engine.GetExpressions(syntaxBox.Document.Text);
        }
    }
}
