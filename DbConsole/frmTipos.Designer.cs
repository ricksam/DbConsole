namespace DbConsole
{
  partial class frmTipos
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtTextoGigante = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.lstTipos = new System.Windows.Forms.ListBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cmTipo = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pnlContext.SuspendLayout();
      this.pnlBottom.SuspendLayout();
      this.cmTipo.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlContext
      // 
      this.pnlContext.Controls.Add(this.label2);
      this.pnlContext.Controls.Add(this.lstTipos);
      this.pnlContext.Controls.Add(this.txtTextoGigante);
      this.pnlContext.Controls.Add(this.label5);
      this.pnlContext.Controls.Add(this.label1);
      this.pnlContext.Size = new System.Drawing.Size(296, 270);
      // 
      // pnlBottom
      // 
      this.pnlBottom.Location = new System.Drawing.Point(0, 270);
      this.pnlBottom.Size = new System.Drawing.Size(296, 45);
      // 
      // btnConfirm
      // 
      this.btnConfirm.Location = new System.Drawing.Point(88, 8);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(184, 8);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Padrão para tipos de dados:";
      // 
      // txtTextoGigante
      // 
      this.txtTextoGigante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtTextoGigante.Location = new System.Drawing.Point(12, 52);
      this.txtTextoGigante.Name = "txtTextoGigante";
      this.txtTextoGigante.Size = new System.Drawing.Size(272, 20);
      this.txtTextoGigante.TabIndex = 10;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 36);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(77, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Texto Gigante:";
      // 
      // lstTipos
      // 
      this.lstTipos.ContextMenuStrip = this.cmTipo;
      this.lstTipos.FormattingEnabled = true;
      this.lstTipos.Location = new System.Drawing.Point(12, 91);
      this.lstTipos.Name = "lstTipos";
      this.lstTipos.Size = new System.Drawing.Size(272, 160);
      this.lstTipos.TabIndex = 13;
      this.lstTipos.DoubleClick += new System.EventHandler(this.lstTipos_DoubleClick);
      this.lstTipos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTipos_KeyDown);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 75);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 14;
      this.label2.Text = "Outros tipos:";
      // 
      // cmTipo
      // 
      this.cmTipo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.removerToolStripMenuItem});
      this.cmTipo.Name = "cmTipo";
      this.cmTipo.Size = new System.Drawing.Size(126, 48);
      // 
      // adicionarToolStripMenuItem
      // 
      this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
      this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
      this.adicionarToolStripMenuItem.Text = "Adicionar";
      this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
      // 
      // removerToolStripMenuItem
      // 
      this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
      this.removerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.removerToolStripMenuItem.Text = "Remover";
      this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
      // 
      // frmTipos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 315);
      this.Name = "frmTipos";
      this.Text = "Tipos";
      this.Load += new System.EventHandler(this.Tipos_Load);
      this.Controls.SetChildIndex(this.pnlBottom, 0);
      this.Controls.SetChildIndex(this.pnlContext, 0);
      this.pnlContext.ResumeLayout(false);
      this.pnlContext.PerformLayout();
      this.pnlBottom.ResumeLayout(false);
      this.cmTipo.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtTextoGigante;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox lstTipos;
    private System.Windows.Forms.ContextMenuStrip cmTipo;
    private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
  }
}