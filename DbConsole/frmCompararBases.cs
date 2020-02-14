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
    public partial class frmCompararBases : Form
    {
        public frmCompararBases()
        {
            InitializeComponent();
        }

        public List<lib.Database.Connection> Connections { get; set; }
        public List<string> Alias { get; set; }

        private void frmCompararBases_Load(object sender, EventArgs e)
        {
            cmbOrigem.Items.AddRange(Alias.ToArray());
            cmbComparacao.Items.AddRange(Alias.ToArray());    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbOrigem.SelectedIndex == -1 || cmbComparacao.SelectedIndex == -1) {
                lib.Visual.Msg.Information("Informe a conexão de origem e de comparação");
            }

            
            
            lib.Database.Connection cnnOrigem = Connections[cmbOrigem.SelectedIndex];
            lib.Database.Connection cnnComparacao = Connections[cmbComparacao.SelectedIndex];

            /*lib.Database.DbScript dbScriptOrigem = new lib.Database.DbScript(cnnOrigem);
            lib.Database.DbScript dbScriptComparacao = new lib.Database.DbScript(cnnComparacao);

            string[] TablesOrigem = cnnOrigem.GetTables();
            string[] TablesComparacao = cnnComparacao.GetTables();

            foreach (var item in TablesOrigem)
            {
                if (!TablesComparacao.Contains(item)) {
                    DbConsole.GetMetadataTable(tb, cbUtilizaColchetes.Checked)
                }
            }*/

            List<Columns> FieldsOrigem = GetFields(cnnOrigem);
            List<Columns> FieldsComparacao = GetFields(cnnComparacao);

            Log("-- Aplicar script na base " + Alias[cmbComparacao.SelectedIndex]);
            GeraLogsAlteracao(FieldsOrigem, FieldsComparacao);
            Log(" ");
            Log("-- Aplicar script na base " + Alias[cmbOrigem.SelectedIndex]);
            GeraLogsAlteracao(FieldsComparacao, FieldsOrigem);
        }

        private void GeraLogsAlteracao(List<Columns> De, List<Columns> Para)
        {
            foreach (var item in De)
            {
                Columns col = Para.FirstOrDefault(q => q.Table == item.Table && q.Column == item.Column);
                if (col == null)
                {
                    GeraLogColumn(item, "add");
                }
                else if (col.DataType != item.DataType || col.MaxLength != item.MaxLength)
                {
                    GeraLogColumn(item, "alter column");
                }
            }
        }

        private void GeraLogColumn(Columns item, string command)
        {
            if (item.DataType.ToLower() == "varchar")
            {
                int MaxLength = Convert.ToInt32(item.MaxLength);
                if (MaxLength > 100000) {
                    item.MaxLength = "max";
                }
                Log(string.Format("alter table {0} {1} {2} {3}({4});", item.Table, command, item.Column, item.DataType, item.MaxLength));
            }
            else if (!string.IsNullOrEmpty(item.Digits) && Convert.ToInt32(item.Digits) != 0)
            {
                Log(string.Format("alter table {0} {1} {2} {3}({4}, {5});", item.Table, command, item.Column, item.DataType, item.ColumnSize, item.Digits));
            }
            else
            {
                Log(string.Format("alter table {0} {1} {2} {3};", item.Table, command, item.Column, item.DataType));
            }
        }

        private List<Columns> GetFields(lib.Database.Connection cnn)
        {

            System.Data.DataTable dt = cnn.GetSchema("Columns");

            string ColumnDataType = "";
            string ColumnSize = "";
            string ColumnDecimalDigits = "";

            if (ColumnExists(dt, "TYPE_NAME"))
            { ColumnDataType = "TYPE_NAME"; }
            else if (ColumnExists(dt, "DATA_TYPE"))
            { ColumnDataType = "DATA_TYPE"; }
            else if (ColumnExists(dt, "COLUMN_DATA_TYPE"))
            { ColumnDataType = "COLUMN_DATA_TYPE"; }

            if (ColumnExists(dt, "NUMERIC_SCALE"))
            { ColumnDecimalDigits = "NUMERIC_SCALE"; }
            else if (ColumnExists(dt, "DECIMAL_DIGITS"))
            { ColumnDecimalDigits = "DECIMAL_DIGITS"; }

            if (ColumnExists(dt, "CHARACTER_MAXIMUM_LENGTH"))
            { ColumnSize = "CHARACTER_MAXIMUM_LENGTH"; }
            else if (ColumnExists(dt, "COLUMN_SIZE"))
            { ColumnSize = "COLUMN_SIZE"; }

            bool NumericPrecisionExists = ColumnExists(dt, "NUMERIC_PRECISION");

            List<Columns> Columns = new List<Columns>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Columns column = new Columns();
                column.Table = dt.Rows[i]["TABLE_NAME"].ToString();
                column.Column = dt.Rows[i]["COLUMN_NAME"].ToString();
                column.DataType = dt.Rows[i][ColumnDataType].ToString();
                column.MaxLength = dt.Rows[i][ColumnSize].ToString();
                column.Digits = dt.Rows[i][ColumnDecimalDigits].ToString();

                if (NumericPrecisionExists)
                {
                    column.ColumnSize = 
                        string.IsNullOrEmpty(dt.Rows[i]["NUMERIC_PRECISION"].ToString()) 
                        || dt.Rows[i]["NUMERIC_PRECISION"].ToString() == "0" ?
                          dt.Rows[i][ColumnSize].ToString() : dt.Rows[i]["NUMERIC_PRECISION"].ToString();
                }
                else
                { column.ColumnSize = dt.Rows[i][ColumnSize].ToString(); }

                Columns.Add(column);
            }

            return Columns;
        }

        private bool ColumnExists(DataTable dt, string ColumnName)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (ColumnName.ToUpper() == dt.Columns[i].ColumnName.ToUpper())
                { return true; }
            }
            return false;
        }

        private class Columns
        {
            public string Table { get; set; }
            public string Column { get; set; }
            public string DataType { get; set; }
            public string MaxLength { get; set; }
            public string Digits { get; set; }
            public string ColumnSize { get; set; }
        }

        private void Log(string s)
        {
            txtResultado.Text += s + Environment.NewLine;
            txtResultado.Refresh();
        }

        private void txtResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                txtResultado.SelectAll();
            }
        }
    }
}
