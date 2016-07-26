﻿using QikLanguageEngine;
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
        }

        private void inputPropertyGrid_InputChanged(object sender, EventArgs e)
        {
            UpdateOutputDocument();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            engine.ExecuteScript(syntaxBox.Document.Text);

            QikControl[] controls = engine.Controls;
            QikExpression[] expressions = engine.Expressions;

            inputPropertyGrid.Reset(engine.Controls, engine.Expressions);

            UpdateOutputDocument();
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
    }
}
