using Alsing.SourceCode;
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

            blueprintSyntaxBox.Document.SyntaxFile = "qikblueprint.syn";
            blueprintSyntaxBox.Document.Text = File.ReadAllText("BlueprintFile.txt");

            outputSyntaxBox.Document.SyntaxFile = "qikblueprint.syn";

            inputPropertyGrid.InputChanged += inputPropertyGrid_InputChanged;


            AddTemplateTab();

            ExecuteScript();
            //tabControlFile.TabPages.RemoveByKey("templateTabPage"); // the key can be the template file name !!!
        }

        private void AddTemplateTab()
        {
            TabPage tabPage = new TabPage("My New Tab Page");
            tabPage.Name = "templateTabPage";
            TemplateControl templateCtrl = new TemplateControl();
            tabPage.Controls.Add(templateCtrl);

            templateCtrl.Dock = DockStyle.Fill;
            tabControlFile.TabPages.Add(tabPage);
        }

        private void inputPropertyGrid_InputChanged(object sender, EventArgs e)
        {
            UpdateOutputDocument();
            UpdateAutoList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            engine.ExecuteScript(syntaxBox.Document.Text);

            QikControl[] controls = engine.Controls;
            QikExpression[] expressions = engine.Expressions;

            inputPropertyGrid.Reset(engine.Controls, engine.Expressions);

            UpdateOutputDocument();
            UpdateAutoList();
        }

        private void ExecuteScript()
        {
            engine.ExecuteScript(syntaxBox.Document.Text);

            QikControl[] controls = engine.Controls;
            QikExpression[] expressions = engine.Expressions;

            inputPropertyGrid.Reset(engine.Controls, engine.Expressions);

            UpdateOutputDocument();
            UpdateAutoList();
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

        private void tabControlFile_Selected(object sender, TabControlEventArgs e)
        {
            // e.Action == TabControlAction.Selected
            if (e.TabPage.Name == "tabOutput")
            {
                UpdateOutputDocument();
                UpdateAutoList();
            }
        }

        private void UpdateOutputDocument()
        {
            string input = blueprintSyntaxBox.Document.Text;
            foreach (string placeholder in engine.Placeholders)
            {
                string output = engine.FindOutput(placeholder);
                input = input.Replace(placeholder, output);
            }

            outputSyntaxBox.Document.Text = input;
        }

        private void UpdateAutoList()
        {
            blueprintSyntaxBox.AutoListClear();

            foreach (string placeholder in engine.Placeholders)
            {
                string title = engine.FindTitle(placeholder);
                blueprintSyntaxBox.AutoListAdd(string.Format("{0} ({1})", title, placeholder), placeholder, 0);
            }
        }

        private void blueprintSyntaxBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.blueprintSyntaxBox.ReadOnly)
            {
                if (e.KeyData == (Keys.Shift | Keys.F8) || e.KeyData == Keys.F8)
                {
                    this.blueprintSyntaxBox.AutoListPosition = new TextPoint(blueprintSyntaxBox.Caret.Position.X, blueprintSyntaxBox.Caret.Position.Y);
                    this.blueprintSyntaxBox.AutoListVisible = true;
                }
            }
        }
    }
}
