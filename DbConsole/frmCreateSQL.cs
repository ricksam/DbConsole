using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DbConsole
{
    public partial class frmCreateSQL : Form
    {
        public frmCreateSQL()
        {
            InitializeComponent();
        }

        DbConsole DbConsole { get; set; }

        public void Initialize(DbConsole db) 
        {
            this.DbConsole = db;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddFilter f = new frmAddFilter();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                //f.SetSQLFilter(DbConsole.GetTables(),DbConsole,);
            }
        }
    }
}
