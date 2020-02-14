namespace DbConsole
{
    partial class frmBICampos
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstTabela = new System.Windows.Forms.ListBox();
            this.lstCampo = new System.Windows.Forms.ListBox();
            this.lstOperacao = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do Campo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 20);
            this.textBox1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTabela);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabela";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstCampo);
            this.groupBox2.Location = new System.Drawing.Point(218, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 209);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campo";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstOperacao);
            this.groupBox3.Location = new System.Drawing.Point(424, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 209);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operação";
            // 
            // lstTabela
            // 
            this.lstTabela.FormattingEnabled = true;
            this.lstTabela.Location = new System.Drawing.Point(6, 19);
            this.lstTabela.Name = "lstTabela";
            this.lstTabela.Size = new System.Drawing.Size(188, 186);
            this.lstTabela.TabIndex = 0;
            // 
            // lstCampo
            // 
            this.lstCampo.FormattingEnabled = true;
            this.lstCampo.Location = new System.Drawing.Point(6, 19);
            this.lstCampo.Name = "lstCampo";
            this.lstCampo.Size = new System.Drawing.Size(188, 186);
            this.lstCampo.TabIndex = 1;
            // 
            // lstOperacao
            // 
            this.lstOperacao.FormattingEnabled = true;
            this.lstOperacao.Items.AddRange(new object[] {
            "Listar",
            "Soma",
            "Média",
            "Porcentagem"});
            this.lstOperacao.Location = new System.Drawing.Point(6, 17);
            this.lstOperacao.Name = "lstOperacao";
            this.lstOperacao.Size = new System.Drawing.Size(188, 186);
            this.lstOperacao.TabIndex = 1;
            // 
            // frmBICampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 272);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Name = "frmBICampos";
            this.Text = "frmBICampos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstTabela;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstCampo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstOperacao;
    }
}