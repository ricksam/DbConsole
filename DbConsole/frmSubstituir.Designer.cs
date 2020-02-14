namespace DbConsole
{
  partial class frmSubstituir
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
      this.txtLocalizar = new System.Windows.Forms.TextBox();
      this.txtSubstituir = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cbIgnorar = new System.Windows.Forms.CheckBox();
      this.pnlContext.SuspendLayout();
      this.pnlBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlContext
      // 
      this.pnlContext.Controls.Add(this.cbIgnorar);
      this.pnlContext.Controls.Add(this.txtSubstituir);
      this.pnlContext.Controls.Add(this.label2);
      this.pnlContext.Controls.Add(this.txtLocalizar);
      this.pnlContext.Controls.Add(this.label1);
      this.pnlContext.Size = new System.Drawing.Size(292, 115);
      // 
      // pnlBottom
      // 
      this.pnlBottom.Location = new System.Drawing.Point(0, 115);
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
      this.label1.Size = new System.Drawing.Size(82, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Localizar Texto:";
      // 
      // txtLocalizar
      // 
      this.txtLocalizar.Location = new System.Drawing.Point(12, 25);
      this.txtLocalizar.Name = "txtLocalizar";
      this.txtLocalizar.Size = new System.Drawing.Size(268, 20);
      this.txtLocalizar.TabIndex = 1;
      // 
      // txtSubstituir
      // 
      this.txtSubstituir.Location = new System.Drawing.Point(12, 64);
      this.txtSubstituir.Name = "txtSubstituir";
      this.txtSubstituir.Size = new System.Drawing.Size(268, 20);
      this.txtSubstituir.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(77, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Substituir para:";
      // 
      // cbIgnorar
      // 
      this.cbIgnorar.AutoSize = true;
      this.cbIgnorar.Location = new System.Drawing.Point(15, 90);
      this.cbIgnorar.Name = "cbIgnorar";
      this.cbIgnorar.Size = new System.Drawing.Size(206, 17);
      this.cbIgnorar.TabIndex = 4;
      this.cbIgnorar.Text = "Ignorar letras maiúsculas e minúsculas";
      this.cbIgnorar.UseVisualStyleBackColor = true;
      // 
      // frmSubstituir
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 160);
      this.Name = "frmSubstituir";
      this.Text = "frmSubstituir";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSubstituir_FormClosed);
      this.Load += new System.EventHandler(this.frmSubstituir_Load);
      this.pnlContext.ResumeLayout(false);
      this.pnlContext.PerformLayout();
      this.pnlBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtSubstituir;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtLocalizar;
    private System.Windows.Forms.CheckBox cbIgnorar;
  }
}