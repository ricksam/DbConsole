namespace DbConsole
{
  partial class frmItemTipo
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtSystemType = new System.Windows.Forms.TextBox();
      this.txtDatabaseType = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlContext.SuspendLayout();
      this.pnlBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlContext
      // 
      this.pnlContext.Controls.Add(this.txtDatabaseType);
      this.pnlContext.Controls.Add(this.label2);
      this.pnlContext.Controls.Add(this.txtSystemType);
      this.pnlContext.Controls.Add(this.label1);
      this.pnlContext.Size = new System.Drawing.Size(292, 98);
      // 
      // pnlBottom
      // 
      this.pnlBottom.Location = new System.Drawing.Point(0, 98);
      // 
      // btnConfirm
      // 
      this.btnConfirm.Location = new System.Drawing.Point(84, 8);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(180, 8);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(136, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Tipo de variável de sistema";
      // 
      // txtSystemType
      // 
      this.txtSystemType.Location = new System.Drawing.Point(12, 25);
      this.txtSystemType.Name = "txtSystemType";
      this.txtSystemType.Size = new System.Drawing.Size(268, 20);
      this.txtSystemType.TabIndex = 1;
      // 
      // txtDatabaseType
      // 
      this.txtDatabaseType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtDatabaseType.Location = new System.Drawing.Point(12, 64);
      this.txtDatabaseType.Name = "txtDatabaseType";
      this.txtDatabaseType.Size = new System.Drawing.Size(268, 20);
      this.txtDatabaseType.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(173, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Tipo de campo no banco de dados";
      // 
      // frmItemTipo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 143);
      this.Name = "frmItemTipo";
      this.Text = "Tipo";
      this.Load += new System.EventHandler(this.frmItemTipo_Load);
      this.pnlContext.ResumeLayout(false);
      this.pnlContext.PerformLayout();
      this.pnlBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtDatabaseType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtSystemType;
  }
}