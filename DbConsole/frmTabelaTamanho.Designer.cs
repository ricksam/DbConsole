namespace DbConsole
{
    partial class frmTabelaTamanho
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
            this.txtTabelas = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTabelas
            // 
            this.txtTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTabelas.Location = new System.Drawing.Point(0, 0);
            this.txtTabelas.Multiline = true;
            this.txtTabelas.Name = "txtTabelas";
            this.txtTabelas.Size = new System.Drawing.Size(833, 481);
            this.txtTabelas.TabIndex = 0;
            // 
            // frmTabelaTamanho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 481);
            this.Controls.Add(this.txtTabelas);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTabelaTamanho";
            this.Text = "Tabelas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTabelas;
    }
}