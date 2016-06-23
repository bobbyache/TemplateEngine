using QikLanguageEngine;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lblPath.Text = dialog.FileName;
                Qik engine = new Qik();
                engine.GetControlsVisitor(dialog.FileName);
                //txtOutput.Text = extractor.ExtractInterface(dialog.FileName);
            }
        }
    }
}
