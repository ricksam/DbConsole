namespace DbConsole
{
  partial class frmTables
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
            this.lstTables = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbMultipleFiles = new System.Windows.Forms.CheckBox();
            this.pnlContext.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContext
            // 
            this.pnlContext.Controls.Add(this.cbMultipleFiles);
            this.pnlContext.Controls.Add(this.button2);
            this.pnlContext.Controls.Add(this.button1);
            this.pnlContext.Controls.Add(this.label1);
            this.pnlContext.Controls.Add(this.lstTables);
            this.pnlContext.Size = new System.Drawing.Size(292, 477);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 477);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(84, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(180, 8);
            // 
            // lstTables
            // 
            this.lstTables.FormattingEnabled = true;
            this.lstTables.Location = new System.Drawing.Point(12, 25);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(268, 394);
            this.lstTables.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abaixo estão as tabelas que serão processadas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Marcar tudo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 448);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Desmarcar tudo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbMultipleFiles
            // 
            this.cbMultipleFiles.AutoSize = true;
            this.cbMultipleFiles.Location = new System.Drawing.Point(12, 425);
            this.cbMultipleFiles.Name = "cbMultipleFiles";
            this.cbMultipleFiles.Size = new System.Drawing.Size(163, 17);
            this.cbMultipleFiles.TabIndex = 4;
            this.cbMultipleFiles.Text = "Um arquivo para cada tabela";
            this.cbMultipleFiles.UseVisualStyleBackColor = true;
            // 
            // frmTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 522);
            this.Name = "frmTables";
            this.Text = "Tabelas";
            this.pnlContext.ResumeLayout(false);
            this.pnlContext.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox lstTables;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbMultipleFiles;
    }
}