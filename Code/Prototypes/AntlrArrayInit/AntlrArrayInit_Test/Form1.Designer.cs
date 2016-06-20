namespace AntlrArrayInit_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnShowTree = new System.Windows.Forms.Button();
            this.txtParseTree = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConversion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(728, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "{99, 3, 451}";
            // 
            // btnShowTree
            // 
            this.btnShowTree.Location = new System.Drawing.Point(665, 38);
            this.btnShowTree.Name = "btnShowTree";
            this.btnShowTree.Size = new System.Drawing.Size(75, 23);
            this.btnShowTree.TabIndex = 1;
            this.btnShowTree.Text = "Convert";
            this.btnShowTree.UseVisualStyleBackColor = true;
            this.btnShowTree.Click += new System.EventHandler(this.btnShowTree_Click);
            // 
            // txtParseTree
            // 
            this.txtParseTree.Location = new System.Drawing.Point(12, 84);
            this.txtParseTree.Multiline = true;
            this.txtParseTree.Name = "txtParseTree";
            this.txtParseTree.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParseTree.Size = new System.Drawing.Size(728, 63);
            this.txtParseTree.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parse Tree";
            // 
            // txtConversion
            // 
            this.txtConversion.Location = new System.Drawing.Point(12, 181);
            this.txtConversion.Multiline = true;
            this.txtConversion.Name = "txtConversion";
            this.txtConversion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConversion.Size = new System.Drawing.Size(728, 63);
            this.txtConversion.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Conversion";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 256);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConversion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtParseTree);
            this.Controls.Add(this.btnShowTree);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnShowTree;
        private System.Windows.Forms.TextBox txtParseTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConversion;
        private System.Windows.Forms.Label label2;
    }
}

