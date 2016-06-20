using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntlrArrayInit_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowTree_Click(object sender, EventArgs e)
        {
            AntlrArrayInit.ArrayInit arrayInitializer = new AntlrArrayInit.ArrayInit();
            txtParseTree.Text = arrayInitializer.TreeString(txtInput.Text);
            txtConversion.Text = arrayInitializer.ConvertToUnicode(txtInput.Text);
        }
    }
}
