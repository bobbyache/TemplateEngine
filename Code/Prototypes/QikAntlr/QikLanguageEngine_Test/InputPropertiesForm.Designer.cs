namespace QikLanguageEngine_Test
{
    partial class InputPropertiesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputPropertiesForm));
            this.syntaxDocument = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnDisplaySymbolTable = new System.Windows.Forms.ToolStripButton();
            this.blueprintSyntaxDocument = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.outputSyntaxDocument = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlFile = new System.Windows.Forms.TabControl();
            this.tabBlueprint = new System.Windows.Forms.TabPage();
            this.blueprintSyntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.outputSyntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.syntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.inputPropertyGrid = new QikLanguageEngine_Test.InputPropertyGrid();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlFile.SuspendLayout();
            this.tabBlueprint.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.tabScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // syntaxDocument
            // 
            this.syntaxDocument.Lines = new string[] {
        ""};
            this.syntaxDocument.MaxUndoBufferSize = 1000;
            this.syntaxDocument.Modified = false;
            this.syntaxDocument.UndoStep = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnDisplaySymbolTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisplaySymbolTable
            // 
            this.btnDisplaySymbolTable.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplaySymbolTable.Image")));
            this.btnDisplaySymbolTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDisplaySymbolTable.Name = "btnDisplaySymbolTable";
            this.btnDisplaySymbolTable.Size = new System.Drawing.Size(140, 22);
            this.btnDisplaySymbolTable.Text = "Display Symbol Table";
            this.btnDisplaySymbolTable.Click += new System.EventHandler(this.btnDisplaySymbolTable_Click);
            // 
            // blueprintSyntaxDocument
            // 
            this.blueprintSyntaxDocument.Lines = new string[] {
        ""};
            this.blueprintSyntaxDocument.MaxUndoBufferSize = 1000;
            this.blueprintSyntaxDocument.Modified = false;
            this.blueprintSyntaxDocument.UndoStep = 0;
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // outputSyntaxDocument
            // 
            this.outputSyntaxDocument.Lines = new string[] {
        ""};
            this.outputSyntaxDocument.MaxUndoBufferSize = 1000;
            this.outputSyntaxDocument.Modified = false;
            this.outputSyntaxDocument.UndoStep = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.inputPropertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 534);
            this.splitContainer1.SplitterDistance = 586;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControlFile
            // 
            this.tabControlFile.Controls.Add(this.tabScript);
            this.tabControlFile.Controls.Add(this.tabBlueprint);
            this.tabControlFile.Controls.Add(this.tabOutput);
            this.tabControlFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFile.Location = new System.Drawing.Point(0, 0);
            this.tabControlFile.Name = "tabControlFile";
            this.tabControlFile.SelectedIndex = 0;
            this.tabControlFile.Size = new System.Drawing.Size(586, 534);
            this.tabControlFile.TabIndex = 3;
            this.tabControlFile.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlFile_Selected);
            // 
            // tabBlueprint
            // 
            this.tabBlueprint.Controls.Add(this.blueprintSyntaxBox);
            this.tabBlueprint.Location = new System.Drawing.Point(4, 22);
            this.tabBlueprint.Name = "tabBlueprint";
            this.tabBlueprint.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlueprint.Size = new System.Drawing.Size(578, 508);
            this.tabBlueprint.TabIndex = 0;
            this.tabBlueprint.Text = "Blueprint";
            this.tabBlueprint.UseVisualStyleBackColor = true;
            // 
            // blueprintSyntaxBox
            // 
            this.blueprintSyntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.blueprintSyntaxBox.AutoListPosition = null;
            this.blueprintSyntaxBox.AutoListSelectedText = "a123";
            this.blueprintSyntaxBox.AutoListVisible = false;
            this.blueprintSyntaxBox.BackColor = System.Drawing.Color.White;
            this.blueprintSyntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.blueprintSyntaxBox.CopyAsRTF = false;
            this.blueprintSyntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blueprintSyntaxBox.Document = this.syntaxDocument1;
            this.blueprintSyntaxBox.FontName = "Courier new";
            this.blueprintSyntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.blueprintSyntaxBox.InfoTipCount = 1;
            this.blueprintSyntaxBox.InfoTipPosition = null;
            this.blueprintSyntaxBox.InfoTipSelectedIndex = 1;
            this.blueprintSyntaxBox.InfoTipVisible = false;
            this.blueprintSyntaxBox.Location = new System.Drawing.Point(3, 3);
            this.blueprintSyntaxBox.LockCursorUpdate = false;
            this.blueprintSyntaxBox.Name = "blueprintSyntaxBox";
            this.blueprintSyntaxBox.ShowScopeIndicator = false;
            this.blueprintSyntaxBox.Size = new System.Drawing.Size(572, 502);
            this.blueprintSyntaxBox.SmoothScroll = false;
            this.blueprintSyntaxBox.SplitviewH = -4;
            this.blueprintSyntaxBox.SplitviewV = -4;
            this.blueprintSyntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.blueprintSyntaxBox.TabIndex = 0;
            this.blueprintSyntaxBox.Text = "syntaxBoxControl1";
            this.blueprintSyntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.outputSyntaxBox);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(578, 508);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // outputSyntaxBox
            // 
            this.outputSyntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.outputSyntaxBox.AutoListPosition = null;
            this.outputSyntaxBox.AutoListSelectedText = "a123";
            this.outputSyntaxBox.AutoListVisible = false;
            this.outputSyntaxBox.BackColor = System.Drawing.Color.White;
            this.outputSyntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.outputSyntaxBox.CopyAsRTF = false;
            this.outputSyntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputSyntaxBox.Document = this.outputSyntaxDocument;
            this.outputSyntaxBox.FontName = "Courier new";
            this.outputSyntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.outputSyntaxBox.InfoTipCount = 1;
            this.outputSyntaxBox.InfoTipPosition = null;
            this.outputSyntaxBox.InfoTipSelectedIndex = 1;
            this.outputSyntaxBox.InfoTipVisible = false;
            this.outputSyntaxBox.Location = new System.Drawing.Point(3, 3);
            this.outputSyntaxBox.LockCursorUpdate = false;
            this.outputSyntaxBox.Name = "outputSyntaxBox";
            this.outputSyntaxBox.ShowScopeIndicator = false;
            this.outputSyntaxBox.Size = new System.Drawing.Size(572, 502);
            this.outputSyntaxBox.SmoothScroll = false;
            this.outputSyntaxBox.SplitviewH = -4;
            this.outputSyntaxBox.SplitviewV = -4;
            this.outputSyntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.outputSyntaxBox.TabIndex = 1;
            this.outputSyntaxBox.Text = "syntaxBoxControl2";
            this.outputSyntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // tabScript
            // 
            this.tabScript.Controls.Add(this.syntaxBox);
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(578, 508);
            this.tabScript.TabIndex = 2;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // syntaxBox
            // 
            this.syntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBox.AutoListPosition = null;
            this.syntaxBox.AutoListSelectedText = "a123";
            this.syntaxBox.AutoListVisible = false;
            this.syntaxBox.BackColor = System.Drawing.Color.White;
            this.syntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBox.CopyAsRTF = false;
            this.syntaxBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.syntaxBox.Document = this.syntaxDocument;
            this.syntaxBox.FontName = "Courier new";
            this.syntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBox.InfoTipCount = 1;
            this.syntaxBox.InfoTipPosition = null;
            this.syntaxBox.InfoTipSelectedIndex = 1;
            this.syntaxBox.InfoTipVisible = false;
            this.syntaxBox.Location = new System.Drawing.Point(0, 0);
            this.syntaxBox.LockCursorUpdate = false;
            this.syntaxBox.Name = "syntaxBox";
            this.syntaxBox.ShowScopeIndicator = false;
            this.syntaxBox.Size = new System.Drawing.Size(578, 508);
            this.syntaxBox.SmoothScroll = false;
            this.syntaxBox.SplitviewH = -4;
            this.syntaxBox.SplitviewV = -4;
            this.syntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBox.TabIndex = 3;
            this.syntaxBox.Text = "syntaxBoxControl1";
            this.syntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // inputPropertyGrid
            // 
            this.inputPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.inputPropertyGrid.Name = "inputPropertyGrid";
            this.inputPropertyGrid.Size = new System.Drawing.Size(418, 534);
            this.inputPropertyGrid.TabIndex = 1;
            // 
            // InputPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 559);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "InputPropertiesForm";
            this.Text = "Form2";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlFile.ResumeLayout(false);
            this.tabBlueprint.ResumeLayout(false);
            this.tabOutput.ResumeLayout(false);
            this.tabScript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alsing.SourceCode.SyntaxDocument syntaxDocument;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnDisplaySymbolTable;
        private Alsing.SourceCode.SyntaxDocument blueprintSyntaxDocument;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.SourceCode.SyntaxDocument outputSyntaxDocument;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlFile;
        private System.Windows.Forms.TabPage tabScript;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBox;
        private System.Windows.Forms.TabPage tabBlueprint;
        private Alsing.Windows.Forms.SyntaxBoxControl blueprintSyntaxBox;
        private System.Windows.Forms.TabPage tabOutput;
        private Alsing.Windows.Forms.SyntaxBoxControl outputSyntaxBox;
        private InputPropertyGrid inputPropertyGrid;
    }
}