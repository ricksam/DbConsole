namespace DbConsole
{
  partial class frmAlter
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
      this.lstFields = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lstConditions = new System.Windows.Forms.ListBox();
      this.btnGo = new System.Windows.Forms.Button();
      this.btnBack = new System.Windows.Forms.Button();
      this.pnlContext.SuspendLayout();
      this.pnlBottom.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlContext
      // 
      this.pnlContext.Controls.Add(this.btnBack);
      this.pnlContext.Controls.Add(this.btnGo);
      this.pnlContext.Controls.Add(this.lstConditions);
      this.pnlContext.Controls.Add(this.label1);
      this.pnlContext.Controls.Add(this.lstFields);
      this.pnlContext.Size = new System.Drawing.Size(391, 342);
      // 
      // pnlBottom
      // 
      this.pnlBottom.Location = new System.Drawing.Point(0, 342);
      this.pnlBottom.Size = new System.Drawing.Size(391, 45);
      // 
      // btnConfirm
      // 
      this.btnConfirm.Location = new System.Drawing.Point(183, 8);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(279, 8);
      // 
      // lstFields
      // 
      this.lstFields.FormattingEnabled = true;
      this.lstFields.Location = new System.Drawing.Point(12, 25);
      this.lstFields.Name = "lstFields";
      this.lstFields.Size = new System.Drawing.Size(162, 303);
      this.lstFields.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(339, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Selecione os campos que determinarão a condição para a atualização";
      // 
      // lstConditions
      // 
      this.lstConditions.FormattingEnabled = true;
      this.lstConditions.Location = new System.Drawing.Point(214, 25);
      this.lstConditions.Name = "lstConditions";
      this.lstConditions.Size = new System.Drawing.Size(162, 303);
      this.lstConditions.TabIndex = 2;
      // 
      // btnGo
      // 
      this.btnGo.Location = new System.Drawing.Point(180, 141);
      this.btnGo.Name = "btnGo";
      this.btnGo.Size = new System.Drawing.Size(28, 23);
      this.btnGo.TabIndex = 3;
      this.btnGo.Text = ">";
      this.btnGo.UseVisualStyleBackColor = true;
      this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
      // 
      // btnBack
      // 
      this.btnBack.Location = new System.Drawing.Point(180, 170);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(28, 23);
      this.btnBack.TabIndex = 4;
      this.btnBack.Text = "<";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // frmAlter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(391, 387);
      this.Name = "frmAlter";
      this.Text = "frmAlter";
      this.pnlContext.ResumeLayout(false);
      this.pnlContext.PerformLayout();
      this.pnlBottom.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnGo;
    private System.Windows.Forms.ListBox lstConditions;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lstFields;
    private System.Windows.Forms.Button btnBack;
  }
}