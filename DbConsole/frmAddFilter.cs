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
    public partial class frmAddFilter : Form
    {
        public frmAddFilter()
        {
            InitializeComponent();
        }

        string[] Tables { get; set; }
        DbConsole DbConsole { get; set; }

        public void SetSQLFilter(string[] tables, DbConsole db, SQLFilter filter)
        {
            this.Tables = tables;
            this.DbConsole = db;

            if (!string.IsNullOrEmpty(filter.Table))
            {
                cmbTabela.Text = filter.Table;
            }

            if (filter.Field != null)
            {
                cmbCampo.Text = filter.Field.Name;
            }

            if (!string.IsNullOrEmpty(filter.Filter))
            {
                cmbExpressao.Text = filter.Filter;
            }

            if (!string.IsNullOrEmpty(filter.Value))
            {
                txtValor.Text = filter.Value;
            }
        }

        public SQLFilter GetSQLFilter() 
        {
            if (cmbTabela.SelectedIndex == -1 || cmbCampo.SelectedIndex == -1 || cmbExpressao.SelectedIndex == -1) 
            {
                MessageBox.Show("Preencha todos os campos");
            }

            SQLFilter s = new SQLFilter();
            s.Table = cmbTabela.Text;
            s.Field = (SQLField)cmbCampo.SelectedItem;
            s.Filter = cmbExpressao.Text;
            s.Value = txtValor.Text;
            return s;
        }

        private void cmbTabela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbTabela.Text))
            {
                System.Data.DataTable dt = DbConsole.GetQuery("SELECT * FROM " + cmbTabela.Text, cmbTabela.Text, 1);
                DbConsole.FillSchema(dt);

                string[] fields = new string[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    cmbCampo.Items.Add(new SQLField() { Name = dt.Columns[i].ColumnName, Type = this.DbConsole.DbCurrent.dbu.GetFieldType(dt.Columns[i].DataType) });
                }
            }
        }
    }
}
