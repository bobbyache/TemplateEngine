using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alsing.SourceCode;

namespace QuickTemplate
{
    public partial class QuickTemplateBox : UserControl
    {
        private Placeholder[] placeholders;

        public QuickTemplateBox()
        {
            InitializeComponent();
        }

        public void ResetPlaceholders(Placeholder[] placeholders)
        {
            this.placeholders = placeholders;
            RefreshAutoCompleteMenu();
        }

        public void RefreshAutoCompleteMenu()
        {
            syntaxBoxControl.AutoListClear();
            if (this.placeholders != null)
            {
                // set up syntax box placeholders.
                foreach (Placeholder placeholder in this.placeholders)
                {
                    //syntaxBoxControl.AutoListAdd(placeholder.ActionIdentifier, placeholder.ActionIdentifier, placeholder.ActionIdentifier, 0);
                    //syntaxBoxControl.AutoListAdd(string.Format("{0} ({1})", placeholder.ActionIdentifier, placeholder.OutputPlaceholder),
                    //    placeholder.OutputPlaceholder, placeholder.OutputPlaceholder, 4);
                    syntaxBoxControl.AutoListAdd(placeholder.Caption, placeholder.Output, 0);
                }
            }
        }

        private void syntaxBoxControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.placeholders == null)
                return;

            if (!this.syntaxBoxControl.ReadOnly && this.placeholders.Length > 0)
            {
                if (e.KeyData == (Keys.Shift | Keys.F8) || e.KeyData == Keys.OemPeriod || e.KeyData == Keys.F8)
                {
                    this.syntaxBoxControl.AutoListPosition = new TextPoint(syntaxBoxControl.Caret.Position.X, syntaxBoxControl.Caret.Position.Y);
                    this.syntaxBoxControl.AutoListVisible = true;
                }
            }
        }
    }
}
