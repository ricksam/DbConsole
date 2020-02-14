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
            this.lstTabelas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstTabelas
            // 
            this.lstTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTabelas.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTabelas.FormattingEnabled = true;
            this.lstTabelas.ItemHeight = 15;
            this.lstTabelas.Location = new System.Drawing.Point(0, 0);
            this.lstTabelas.Name = "lstTabelas";
            this.lstTabelas.Size = new System.Drawing.Size(625, 391);
            this.lstTabelas.TabIndex = 0;
            // 
            // frmTabelaTamanho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 391);
            this.Controls.Add(this.lstTabelas);
            this.Name = "frmTabelaTamanho";
            this.Text = "Tabelas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTabelas;
    }
}