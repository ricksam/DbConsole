using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbConsole
{
    public partial class frmProcess : lib.Visual.Models.frmDialog
    {
        public frmProcess()
        {
            InitializeComponent();
        }

        DbConsole DbConsole { get; set; }
        public DataTable DtProcess { get; set; }

        public void SetDb(DbConsole db)
        {
            this.DbConsole = db;
        }

        public bool[] GetTablesCheckeds()
        {
            /*string[] list = new string[lstProcess.CheckedItems.Count];
            for (int i = 0; i < lstProcess.CheckedItems.Count; i++)
            { list[i] = lstProcess.CheckedItems[i].ToString(); }
            return list;*/

            List<bool> list = new List<bool>();  
            for (int i = 0; i < lstProcess.Items.Count; i++)
            {
                bool add = false;
                for (int j = 0; j < lstProcess.CheckedItems.Count; j++)
                {
                    if (lstProcess.Items[i] == lstProcess.CheckedItems[j]) {
                        list.Add(true);
                        add = true;
                        break;
                    }
                }
                if (!add) {
                    list.Add(false);
                }
            }

            return list.ToArray();
        }


        private void frmProcess_Load(object sender, EventArgs e)
        {
            if (DbConsole.DbCurrent.dbType == lib.Database.Drivers.enmConnection.SqlServer) {
                cmbDriver.DataSource = DbConsole.GetQuery("select program_name FROM sys.sysprocesses group by program_name", "driver");
                cmbDriver.DisplayMember = "program_name";

                cmbStatus.DataSource = DbConsole.GetQuery("select status FROM sys.sysprocesses group by status", "status");
                cmbStatus.DisplayMember = "status";
            }

            if (DbConsole.DbCurrent.dbType == lib.Database.Drivers.enmConnection.PostgreSQL) {
                cmbDriver.DataSource = DbConsole.GetQuery("select datname from pg_stat_activity group by datname", "driver");
                cmbDriver.DisplayMember = "datname";

                cmbStatus.DataSource = DbConsole.GetQuery("select state FROM pg_stat_activity group by state", "status");
                cmbStatus.DisplayMember = "state";
            }
            
        }

        private void PesquisaProcess()
        {
            if (DbConsole.DbCurrent.dbType == lib.Database.Drivers.enmConnection.SqlServer) {
                //'dbcc inputbuffer(',spid,')'
                string sql = string.Format(@"select spid FROM sys.sysprocesses 
                where program_name = '{0}' and status = '{1}'", cmbDriver.Text, cmbStatus.Text);
                DtProcess = DbConsole.GetQuery(sql, "process");

                lstProcess.Items.Clear();
                if (DtProcess != null)
                {
                    for (int i = 0; i < DtProcess.Rows.Count; i++)
                    {
                        DataTable dtSpId = DbConsole.GetQuery("dbcc inputbuffer(" + DtProcess.Rows[i]["spid"].ToString() + ")", "spid");
                        if (dtSpId != null && dtSpId.Rows.Count == 1)
                        {
                            lstProcess.Items.Add(DtProcess.Rows[i]["spid"].ToString() + " - " + dtSpId.Rows[0]["EventInfo"].ToString(), true);
                        }
                    }
                }
            }

            if (DbConsole.DbCurrent.dbType == lib.Database.Drivers.enmConnection.PostgreSQL) {
                string sql = string.Format(@"select pid, query  from pg_stat_activity where datname='{0}' and state='{1}'", cmbDriver.Text, cmbStatus.Text);
                DtProcess = DbConsole.GetQuery(sql, "process");
                lstProcess.Items.Clear();
                if (DtProcess != null)
                {
                    for (int i = 0; i < DtProcess.Rows.Count; i++)
                    {
                        lstProcess.Items.Add(DtProcess.Rows[i]["pid"].ToString() + " - " + DtProcess.Rows[i]["query"].ToString(), true);
                    }
                }
            }
            

        }

        private void cmbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            PesquisaProcess();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            PesquisaProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstProcess.Items.Count; i++)
            { lstProcess.SetItemChecked(i, true); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstProcess.Items.Count; i++)
            { lstProcess.SetItemChecked(i, false); }
        }

        private void lstProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstProcess.SelectedIndex != -1) {
                string line = lstProcess.Items[lstProcess.SelectedIndex].ToString();
                string id = line.Substring(0, line.IndexOf(" - "));
                DataTable dtSpId = DbConsole.GetQuery("dbcc inputbuffer(" + id + ")", "spid");
                if (dtSpId != null && dtSpId.Rows.Count == 1)
                {
                    textBox1.Text = dtSpId.Rows[0]["EventInfo"].ToString();
                }
            }
        }
    }
}
