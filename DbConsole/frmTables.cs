using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DbConsole
{
    public partial class frmTables : lib.Visual.Models.frmDialog
    {
        public frmTables()
        {
            InitializeComponent();
        }

        public void SetTables(ListBox.ObjectCollection list)
        {
            for (int i = 0; i < list.Count; i++)
            { lstTables.Items.Add(list[i], true); }
        }

        public string[] GetTablesCheckeds()
        {
            string[] list = new string[lstTables.CheckedItems.Count];
            for (int i = 0; i < lstTables.CheckedItems.Count; i++)
            { list[i] = lstTables.CheckedItems[i].ToString(); }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTables.Items.Count; i++)
            { lstTables.SetItemChecked(i, true); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstTables.Items.Count; i++)
            { lstTables.SetItemChecked(i, false); }
        }

        public bool MultiplosArquivos
        {
            get
            {
                return cbMultipleFiles.Checked;
            }
        }
    }
}
