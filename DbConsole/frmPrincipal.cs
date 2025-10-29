using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lib.Class;
using lib.Database;
using lib.Database.Drivers;
using lib.Database.Query;
using lib.Visual;
using System.Runtime.InteropServices.ComTypes;

namespace DbConsole
{
    public partial class frmPrincipal : lib.Visual.Models.frmBase
    {
        #region Constructor
        public frmPrincipal()
        {
            InitializeComponent();
            Carregar();
        }
        #endregion

        #region Fields
        DbConsole DbConsole { get; set; }
        bool CancelProgress { get; set; }
        EstimatedTime EstimatedTime { get; set; }
        //int QtdeProgress { get; set; }
        List<string> TextState { get; set; }
        int LastSecoundProcess { get; set; }
        int idxFilter { get; set; }
        #endregion

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                Consultar(getInstrucaoSql(), "Sql_Query", cbLimitar.Checked);
            }

            if (e.KeyData == Keys.F6)
            {
                Executar();
            }

            base.OnKeyDown(e);
        }

        #region private void Carregar()
        private void Carregar()
        {
            TextState = new List<string>();
            EstimatedTime = new lib.Class.EstimatedTime();
            DbConsole = new DbConsole();
            DbConsole.ScriptProgress += new DbConsole.ScriptProgress_Handle(ScriptProgress);
            DbConsole.ScriptLog += new DbConsole.ScriptLog_Handle(AddLog);

            try
            {
                Utility.Config = new Config();
                // Utility.Config.FileName = lib.Visual.Functions.GetDirAppCondig() + "\\DbConsole.cfg";
                Utility.Config.Open();
            }
            catch
            { Utility.Config = new Config(); }

            cbEditarDados.Checked = Utility.Config.EditarDados;
            cbEscreverMaiusculo.Checked = Utility.Config.EscreverMaiusculo;
            cbEstiloVisual.Checked = Utility.Config.EstiloVisual;
            cbPontoVirgula.Checked = Utility.Config.ExecutarPontoVirgula;
            txtTemplatePath.Text = Utility.Config.TemplateFolder;
            txtNamespace.Text = Utility.Config.TemplateNamespace;
            cbEsquema.Checked = true; //Sempre ao abrir é true. 
                                      //Se desejar utilizar como false para operações em Sql complexas então deverá clicar no menu para remover o flag

            AtualizaInstrucoes();

            cmbReportType.SelectedIndex = 0;
            cmbReportStyle.Items.Clear();
            cmbReportStyle.Items.AddRange(DbConsole.ReportStyleList.GetNames());
            cmbReportStyle.SelectedIndex = Utility.Config.IndexEstiloRelatorio;
        }
        #endregion

        #region private void ShowTables()
        private void ShowTables(bool UpdateColumns, bool WithView)
        {
            lstTables.Items.Clear();
            grdColumns.Rows.Clear();
            //bsRegistros.DataSource = null;
            grdEsquema.DataSource = null;
            grdRegistros.DataSource = null;

            string[] tables = new string[] { };
            if (DbConsole.DbCurrent != null)
            {
                DbConsole.DbCurrent.Refresh();
                lstTables.Items.Clear();
                tables = DbConsole.GetTables(WithView);
                Array.Sort(tables);
                lstTables.Items.AddRange(tables);
            }

            txtSql.Settings.Members.Clear();
            txtSql.Settings.Members.AddRange(tables);
            txtSql.Configure();

            txtScript.Settings.Members.Clear();
            txtScript.Settings.Members.AddRange(tables);
            txtScript.Configure();

            if (DbConsole.Index != -1)
            {
                this.Text = string.Format("DbConsole [{0}] ", lib.Class.Utils.GetVersion()) + DbConsole.Alias[DbConsole.Index].Replace("\n", "").Replace("\r", "");
                lblBanco.Text = DbConsole.Alias[DbConsole.Index].Replace("\n", "").Replace("\r", "");
            }

            if (DbConsole.DbCurrent != null)
            {
                if (DbConsole.DbCurrent.dbType == enmConnection.SqlServer)
                { cbInsertIdentity.Checked = true; }

                if (UpdateColumns)
                { DbConsole.UpdateColumns(); }
                else
                { DbConsole.DbColumns = new DbColumn[] { }; }

                DbScript s = new DbScript(DbConsole.DbCurrent, cbUtilizaColchetes.Checked);
                DbDataType[] dts = s.GetDbDataTypes();

                ConfiguraEditor(dts, txtScript);
                ConfiguraEditor(dts, txtSql);
            }
        }
        #endregion

        #region private void ExibeDadosTabela()
        private void ExibeDadosTabela()
        {
            try
            {
                if (lstTables.SelectedIndex != -1)
                {
                    string TableName = lstTables.SelectedItem.ToString();
                    DataTable dt_indexColumns = DbConsole.GetSchema("IndexColumns");
                    DataTable dt_indexes = DbConsole.GetSchema("Indexes");

                    string Sql = string.Format("select * from {0}", lstTables.SelectedItem.ToString());
                    /*string Sql = "";

                    if (cbUtilizaColchetes.Checked)
                    {
                        Sql = string.Format("select * from [{0}]", lstTables.SelectedItem.ToString());
                    }
                    else
                    {
                        Sql = string.Format("select * from {0}", lstTables.SelectedItem.ToString());
                    }*/


                    if (dt_indexColumns != null && dt_indexColumns.Rows.Count != 0 &&
                        dt_indexes != null && dt_indexes.Rows.Count != 0
                        )
                    {
                        string pk_column = DbConsole.GetFirstColumnPrimary(dt_indexes, dt_indexColumns, TableName);
                        if (!string.IsNullOrEmpty(pk_column))
                        {
                            Sql = string.Format("select * from {0} order by {1} desc ", lstTables.SelectedItem.ToString(), pk_column);
                            /*if (cbUtilizaColchetes.Checked)
                            {
                                Sql = string.Format("select * from [{0}] order by [{1}] desc ", lstTables.SelectedItem.ToString(), pk_column);
                            }
                            else
                            {
                                Sql = string.Format("select * from {0} order by {1} desc ", lstTables.SelectedItem.ToString(), pk_column);
                            }*/
                        }
                    }

                    Consultar(Sql, lstTables.SelectedItem.ToString(), cbLimitar.Checked);
                }
            }
            catch (Exception ex)
            { Msg.Warning(ex.Message); }
        }
        #endregion

        #region private void AddLog(string log)    
        private void AddLog(string log)
        {
            if (!string.IsNullOrEmpty(log))
            {
                tabDados.SelectedTab = tbLog;

                txtLog.Clear();
                txtLog.Text = "Executado as : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\r\n";
                txtLog.Text += log + "\r\n";
                txtLog.Text += "Linhas afetadas:" + DbConsole.DbCurrent.ExecutedCommands;
                if (txtLog.Text.Length != 0)
                { txtLog.SelectionStart = txtLog.Text.Length; }

                txtLog.ScrollToCaret();
                ShowTables(false, cbTablesAndViews.Checked);
            }
        }
        #endregion

        #region private string getInstrucaoSql()  
        private string getInstrucaoSql()
        {
            string instrucao = txtSql.Text;

            if (txtSql.SelectionLength != 0)
            { instrucao = txtSql.Text.Substring(txtSql.SelectionStart, txtSql.SelectionLength); }

            if (!string.IsNullOrEmpty(instrucao))
            {
                Utility.Config.AddInstrucao(instrucao);
                AtualizaInstrucoes();
            }

            return instrucao;
        }
        #endregion

        #region private void AtualizaInstrucoes()
        private void AtualizaInstrucoes()
        {
            lstInstrucoes.Items.Clear();
            for (int i = Utility.Config.Instrucoes.Count - 1; i >= 0; i--)
            { lstInstrucoes.Items.Add(Utility.Config.Instrucoes[i]); }
        }
        #endregion

        #region private void Consultar(string Sql)
        /*
        private bool HasColumn(DataTable d, string ColumnName)
        {
            for (int i = 0; i < d.Columns.Count; i++)
            {
                if (d.Columns[i].ColumnName.ToUpper() == ColumnName.ToUpper())
                { return true; }
            }

            return false;
        }
        private string getColumnPrimary(DataTable dt_indexes, DataTable dt_indexColumns, string TableName)
        {
            string index_name = "";

            // Modelo utilizado pelo SQL Server e provavelmente pelo Postgree
            if (HasColumn(dt_indexes, "table_name") && HasColumn(dt_indexes, "type_desc") && HasColumn(dt_indexes, "index_name"))
            {
                for (int i = 0; i < dt_indexes.Rows.Count; i++)
                {
                    if (dt_indexes.Rows[i]["table_name"].ToString().ToUpper() == TableName.ToUpper()
                        && dt_indexes.Rows[i]["type_desc"].ToString().ToUpper() == "CLUSTERED")
                    {
                        index_name = dt_indexes.Rows[i]["index_name"].ToString();
                        //constraint_name = dt_indexes.Rows[i]["constraint_name"].ToString();
                        break;
                    }
                }
            }

            // Modelo utilizado pelo MySQL e provavelmente pelo SQLite
            if (HasColumn(dt_indexes, "table_name") && HasColumn(dt_indexes, "primary") && HasColumn(dt_indexes, "index_name"))
            {
                for (int i = 0; i < dt_indexes.Rows.Count; i++)
                {
                    if (dt_indexes.Rows[i]["table_name"].ToString().ToUpper() == TableName.ToUpper()
                        && dt_indexes.Rows[i]["primary"].ToString().ToUpper() == "TRUE")
                    {
                        index_name = dt_indexes.Rows[i]["index_name"].ToString();
                        //constraint_name = dt_indexes.Rows[i]["constraint_name"].ToString();
                        break;
                    }
                }
            }

            if (HasColumn(dt_indexColumns, "table_name") && HasColumn(dt_indexColumns, "index_name") && HasColumn(dt_indexColumns, "column_name"))
            {
                for (int i = 0; i < dt_indexColumns.Rows.Count; i++)
                {
                    if (dt_indexColumns.Rows[i]["table_name"].ToString().ToUpper() == TableName.ToUpper()
                        && dt_indexColumns.Rows[i]["index_name"].ToString().ToUpper() == index_name.ToUpper())
                    {
                        return dt_indexColumns.Rows[i]["column_name"].ToString();
                    }
                }
            }

            return null;
        }
        */

        private void Consultar(string Sql, string TableName, bool Limitar)
        {
            ArgsConsulta args = new ArgsConsulta()
            {
                Sql = Sql,
                TableName = TableName,
                Limitar = Limitar
            };

            grdRegistros.Visible = false;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ConsultarDb));
            thread.Start(args);
            //ConsultarDb(args);
        }

        private void ConsultarDb(object argsThread)
        {
            ArgsConsulta args = (ArgsConsulta)argsThread;
            lblErroGrid.Text = "";

            DataTable tb = null;
            if (args.Limitar)
            {
                tb = DbConsole.GetQuery(args.Sql, args.TableName, 200);
            }
            else
            {
                tb = DbConsole.GetQuery(args.Sql, args.TableName);
            }

            if (tb == null)
            { return; }

            this.BeginInvoke((Action)delegate ()
            {
                grdRegistros.Visible = true;
                tabDados.SelectedTab = tbSql;

                if (cbSemBinding.Checked)
                {
                    grdRegistros.DataSource = tb;
                }
                else
                {
                    bsRegistros.DataSource = tb;
                    grdRegistros.DataSource = bsRegistros;
                }

                if (cbUsaSchema.Checked)
                { DbConsole.FillSchema(tb); }

                for (int i = 0; i < grdRegistros.Columns.Count; i++)
                { grdRegistros.Columns[i].Width = DbConsole.GetSizeField(tb, i); }

                //grdColumns.Clear();
                //grdColumns.AddColumn(new FieldColumn("Campos", "Campos", enmFieldType.String, 200));
                //grdColumns.AddColumn(new FieldColumn("Tipo", "Tipo", enmFieldType.String, 200));

                lstReportExibir.Items.Clear();
                lstReportTotalizar.Items.Clear();

                grdColumns.Rows.Clear();
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    string col_name = tb.Columns[i].ColumnName;
                    string col_type = DbConsole.GetDbTypeField(tb, i);
                    //grdColumns.AddItem(new string[] { col_name, col_type }, null);
                    grdColumns.Rows.Add(new string[] { col_name, col_type });
                    lstReportExibir.Items.Add(col_name, true);
                    lstReportTotalizar.Items.Add(col_name);
                }

                txtDependencias.Clear();
                ForeignKey[] Dep = DbConsole.GetDependencies(tb.TableName);
                for (int i = 0; i < Dep.Length; i++)
                { txtDependencias.Text += string.Format("{0}.{1}\r\n", Dep[i].TableName, Dep[i].ColumnName); }

                txtScript.Text = DbConsole.GetMetadataTable(tb, cbUtilizaColchetes.Checked);
                txtAlias.Text = tb.TableName;
                txtReportName.Text = tb.TableName;

                txtCode.Text = GetCode();
            });
        }
        #endregion

        #region private void Executar()
        private void Executar()
        {
            pnlProgress.Visible = true;
            AddLog(DbConsole.ExecQuery(getInstrucaoSql(), cbPontoVirgula.Checked));
            pnlProgress.Visible = false;
        }
        #endregion

        #region private void UpdateMnConnection()
        private void UpdateMnConnection()
        {
            mnConnection.DropDownItems.Clear();
            for (int i = 0; i < DbConsole.Connections.Count; i++)
            {
                ToolStripMenuItem tsi = new ToolStripMenuItem(DbConsole.Alias[i]);
                tsi.Click += new EventHandler(tsi_Click);
                mnConnection.DropDownItems.Add(tsi);
            }
        }
        #endregion

        #region private void LoadMnConfig()
        private void LoadMnConfig()
        {
            //cbEscreverMaiusculo.Checked = (txtSql.CharacterCasing == CharacterCasing.Upper);
            cbEditarDados.Checked = grdRegistros.AllowUserToAddRows;
            cbEstiloVisual.Checked = grdRegistros.EnableHeadersVisualStyles;
        }
        #endregion

        #region private void ConfiguraEditor()
        private void ConfiguraEditor(DbDataType[] dts, lib.Visual.Components.SyntaxRichTextBox rich)
        {
            rich.Settings.Keywords.Clear();
            rich.Settings.Keywords.AddRange(Utility.GetReservedWords());

            for (int i = 0; i < dts.Length; i++)
            {
                if (rich.Settings.Keywords.IndexOf(dts[i].TypeName.ToUpper()) == -1)
                { rich.Settings.Keywords.Add(dts[i].TypeName.ToUpper()); }
            }

            //rich.BackColor = Color.Silver;

            rich.Settings.Comment = "--";
            rich.Settings.BeginComment = "/*";
            rich.Settings.EndComment = "*/";

            //rich.Settings.
            rich.Settings.KeywordColor = Color.Blue;
            rich.Settings.MemberColor = Color.Green;
            //txtSql.Settings.PunctuationColor = Color.Purple;
            rich.Settings.StringColor = Color.Red;
            rich.Settings.NumberColor = Color.Brown;
            rich.Settings.CommentColor = Color.Silver;

            rich.Settings.EnableMembers = true;
            //txtSql.Settings.EnablePunctuations = true;
            rich.Settings.EnableNumbers = true;
            rich.Settings.EnableStrings = true;
            rich.Settings.EnableComments = true;
            rich.Configure();
        }
        #endregion

        #region void tsi_Click(object sender, EventArgs e)
        void tsi_Click(object sender, EventArgs e)
        {
            DbConsole.UseConnection(((ToolStripMenuItem)sender).Text);
            ShowTables(cbUpdateColumns.Checked, cbTablesAndViews.Checked);
        }
        #endregion

        #region private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibeDadosTabela();
        }
        #endregion

        #region private void bsRegistros_PositionChanged(object sender, EventArgs e)
        private void bsRegistros_PositionChanged(object sender, EventArgs e)
        {
            DbConsole.UpdateRowToDatabase(((DataTable)((BindingSource)sender).DataSource), cbSemBinding.Checked);
        }
        #endregion

        #region private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lib.Visual.Forms.FormConnection f = new lib.Visual.Forms.FormConnection(true);
                if (f.Exec())
                {
                    //cbUsaSchema.Checked = true;//f.DbType != enmConnection.MySql;
                    cbUtilizaColchetes.Checked = f.DbType == enmConnection.SqlServer;
                    
                    if (f.DbType == enmConnection.Oracle) {
                        cbUpdateColumns.Checked = false;
                        cbTablesAndViews.Checked = false;
                    }
                    

                    Connection c = new Connection();
                    c.Connect(f.DbType, f.InfoConnection);
                    DbConsole.Add(f.Alias, c);
                    UpdateMnConnection();
                    ShowTables(cbUpdateColumns.Checked, cbTablesAndViews.Checked);
                }
            }
            catch (Exception ex)
            {
                frmExibirConexao f = new frmExibirConexao();
                f.Carregar(ex.Message);
                f.ShowDialog();
            }
        }
        #endregion

        #region private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbConsole.Clear();
            UpdateMnConnection();
            ShowTables(false, cbTablesAndViews.Checked);
        }
        #endregion

        #region private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar(getInstrucaoSql(), "Sql_Query", cbLimitar.Checked);
        }
        #endregion

        #region private void executarToolStripMenuItem_Click(object sender, EventArgs e)
        private void executarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executar();
        }
        #endregion

        #region private void cbEscreverMaiusculo_Click(object sender, EventArgs e)
        private void cbEscreverMaiusculo_Click(object sender, EventArgs e)
        {
            /*if (txtSql.CharacterCasing == CharacterCasing.Upper)
            { txtSql.CharacterCasing = CharacterCasing.Normal; }
            else
            { txtSql.CharacterCasing = CharacterCasing.Upper; }*/
            LoadMnConfig();
        }
        #endregion

        #region private void cbEstiloVisual_Click(object sender, EventArgs e)
        private void cbEstiloVisual_Click(object sender, EventArgs e)
        {
            grdRegistros.EnableHeadersVisualStyles = !grdRegistros.EnableHeadersVisualStyles;
            LoadMnConfig();
        }
        #endregion

        #region private void cbEditarDados_Click(object sender, EventArgs e)
        private void cbEditarDados_Click(object sender, EventArgs e)
        {
            if (grdRegistros.ReadOnly)
            {
                grdRegistros.ReadOnly = false;
                grdRegistros.AllowUserToAddRows = true;
                grdRegistros.DefaultCellStyle.BackColor = Color.Khaki;
                btnAdd.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                grdRegistros.ReadOnly = true;
                grdRegistros.AllowUserToAddRows = false;
                grdRegistros.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
            LoadMnConfig();
        }
        #endregion

        #region private void Principal_Load(object sender, EventArgs e)
        private void Principal_Load(object sender, EventArgs e)
        {
            LoadMnConfig();
            this.Text = string.Format("DbConsole [{0}]", lib.Class.Utils.GetVersion());
        }
        #endregion

        #region private void transformarEmMaiúsculoToolStripMenuItem_Click(object sender, EventArgs e)
        private void transformarEmMaiúsculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSql.Text = txtSql.Text.ToUpper();
        }
        #endregion

        #region private void limparToolStripMenuItem1_Click(object sender, EventArgs e)
        private void limparToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            { AddLog(DbConsole.CleanTable(lstTables.SelectedItem.ToString())); }
        }
        #endregion

        #region private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            { AddLog(DbConsole.DropTable(lstTables.SelectedItem.ToString())); }
        }
        #endregion

        #region private void txtSql_KeyPress(object sender, KeyPressEventArgs e)
        private void txtSql_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbEscreverMaiusculo.Checked)
            { e.KeyChar = char.ToUpper(e.KeyChar); }
        }
        #endregion

        #region private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Utility.Config.EditarDados = cbEditarDados.Checked;
                Utility.Config.EscreverMaiusculo = cbEscreverMaiusculo.Checked;
                Utility.Config.EstiloVisual = cbEstiloVisual.Checked;
                Utility.Config.ExecutarPontoVirgula = cbPontoVirgula.Checked;
                Utility.Config.UtilizaEsquema = cbEsquema.Checked;

                //Utility.Config.FileName = lib.Visual.Functions.GetDirAppCondig() + "\\DbConsole.cfg";
                Utility.Config.Save();
            }
            catch (Exception ex) { (new lib.Visual.Forms.FormError()).ShowError(ex); }
        }
        #endregion

        #region private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipos t = new frmTipos();
            t.Exec();
        }
        #endregion

        #region private void button1_Click(object sender, EventArgs e)
        private void button1_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "SQL|*.sql";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string script = DbConsole.GetMetadataTable(DbConsole.LastTable, cbUtilizaColchetes.Checked);
                TextFile tf = new TextFile();
                tf.Open(enmOpenMode.Writing, dlgSave.FileName);
                tf.Write(script);
                tf.Close();
            }
        }
        #endregion

        #region private void button2_Click(object sender, EventArgs e)
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dlgSave.Filter = "SQL|*.sql";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (System.IO.File.Exists(dlgSave.FileName))
                    { System.IO.File.Delete(dlgSave.FileName); }

                    DbConsole.LastTable.TableName = txtAlias.Text;
                    DbConsole.SalveScriptInsert(DbConsole.LastTable, dlgSave.FileName, cbInsertIdentity.Checked, cbUtilizaColchetes.Checked);
                }
            }
            catch
            { Msg.Warning("Não foi possível gerar o script"); }
        }
        #endregion

        #region private void ScriptProgress(string TableName, int Index, int Count, out bool Cancel)
        private void ScriptProgress(string TableName, int Index, int Count, out bool Cancel)
        {
            Cancel = this.CancelProgress;
            this.CancelProgress = false;

            if (LastSecoundProcess == DateTime.Now.Second)
            { return; }
            LastSecoundProcess = DateTime.Now.Second;

            //QtdeProgress = 0;

            lblProgress.Text = "Processando a tabela : " + TableName + " Tempo estimado:" + EstimatedTime.Get(Index, Count);
            if (pnlProgress.Visible == false)
            { pnlProgress.Visible = true; }
            Progress.Minimum = 0;
            Progress.Maximum = Count;
            Progress.Value = Index + 1;

            Application.DoEvents();
            System.Threading.Thread.Sleep(1);
        }
        #endregion

        #region private void btnCancelProgress_Click(object sender, EventArgs e)
        private void btnCancelProgress_Click(object sender, EventArgs e)
        {
            if (Msg.Question("Tem certeza que deseja cancelar?"))
            { CancelProgress = true; }
        }
        #endregion

        #region private void lstInstrucoes_SelectedIndexChanged(object sender, EventArgs e)
        private void lstInstrucoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInstrucoes.SelectedItem != null)
            { txtSql.Text = lstInstrucoes.SelectedItem.ToString(); }
        }
        #endregion

        #region private void button3_Click(object sender, EventArgs e)
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                frmAlter fa = new frmAlter();

                string[] cols = new string[DbConsole.LastTable.Columns.Count];
                for (int i = 0; i < cols.Length; i++)
                { cols[i] = DbConsole.LastTable.Columns[i].ColumnName; }

                fa.Fields = cols;
                if (fa.Exec())
                {
                    dlgSave.Filter = "SQL|*.sql";
                    if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (System.IO.File.Exists(dlgSave.FileName))
                        { System.IO.File.Delete(dlgSave.FileName); }

                        DbConsole.LastTable.TableName = txtAlias.Text;
                        DbConsole.SalveScriptUpdate(DbConsole.LastTable, dlgSave.FileName, fa.Conditions, cbUtilizaColchetes.Checked);
                    }
                }
            }
            catch { Msg.Warning("Não foi possível gerar o script"); }
        }
        #endregion

        #region private void substituirToolStripMenuItem_Click(object sender, EventArgs e)
        private void substituirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubstituir s = new frmSubstituir();
            if (s.Exec())
            {
                if (Utility.Config.SubstituirIgnorar)
                { txtSql.Text = txtSql.Text.ToUpper().Replace(s.Localizar.ToUpper(), s.Substituir.ToUpper()); }
                else
                { txtSql.Text = txtSql.Text.Replace(s.Localizar, s.Substituir); }
            }
        }
        #endregion

        #region private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Msg.Information(
              "Desenvolvedor: Ricardo Sampaio\n" +
              "Empresa: RCK Software\n" +
              "Contato: jricksam@gmail.com" +
              " \n",
              "Database Console"
              );
        }
        #endregion

        #region private void metadataToolStripMenuItem_Click(object sender, EventArgs e)
        private void metadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTables t = new frmTables();
            t.SetTables(lstTables.Items);
            if (t.Exec())
            {
                dlgSave.Filter = "SQL|*.sql";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pnlProgress.Visible = true;
                    DbConsole.ExportMetadataTables(
                      dlgSave.FileName, t.GetTablesCheckeds(), cbUtilizaColchetes.Checked);
                    pnlProgress.Visible = false;
                }
            }
        }
        #endregion

        #region private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        private void dadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTables t = new frmTables();
            t.SetTables(lstTables.Items);
            if (t.Exec())
            {
                dlgSave.Filter = "SQL|*.sql";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pnlProgress.Visible = true;
                    DbConsole.ExportDataTables(
                      dlgSave.FileName, t.GetTablesCheckeds(), cbInsertIdentity.Checked, cbUtilizaColchetes.Checked, true, t.MultiplosArquivos);
                    pnlProgress.Visible = false;
                }
            }
        }
        #endregion

        #region private void metadataComDadosToolStripMenuItem_Click(object sender, EventArgs e)
        private void metadataComDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTables t = new frmTables();
            t.SetTables(lstTables.Items);
            if (t.Exec())
            {
                dlgSave.Filter = "SQL|*.sql";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pnlProgress.Visible = true;
                    DbConsole.ExportMetadataWithDataTabelas(
                      dlgSave.FileName, t.GetTablesCheckeds(), cbInsertIdentity.Checked, t.MultiplosArquivos);
                    pnlProgress.Visible = false;
                }
            }
        }
        #endregion

        #region private void button4_Click(object sender, EventArgs e)
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Fields = new string[lstReportExibir.CheckedItems.Count];
                for (int i = 0; i < lstReportExibir.CheckedItems.Count; i++)
                { Fields[i] = lstReportExibir.CheckedItems[i].ToString(); }

                string[] Counters = new string[lstReportTotalizar.CheckedItems.Count];
                for (int i = 0; i < lstReportTotalizar.CheckedItems.Count; i++)
                { Counters[i] = lstReportTotalizar.CheckedItems[i].ToString(); }

                Utility.Config.IndexEstiloRelatorio = cmbReportStyle.SelectedIndex;

                DbConsole.DbGenerateReport(
                  txtReportName.Text,
                  cmbReportType.SelectedIndex == 0,
                  cmbReportStyle.SelectedIndex,
                  Fields,
                  Counters);
            }
            catch { Msg.Warning("Não foi possível abrir o relatório"); }
        }
        #endregion

        #region private void button5_Click(object sender, EventArgs e)
        private void button5_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Report|*.html|SWR|*.swr";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (System.IO.File.Exists(dlgSave.FileName))
                { System.IO.File.Delete(dlgSave.FileName); }

                System.IO.File.Copy(DbConsole.ReportFile, dlgSave.FileName);
            }
        }
        #endregion

        #region private void grdRegistros_DataError(object sender, DataGridViewDataErrorEventArgs e)
        private void grdRegistros_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
            { lblErroGrid.Text = "Sql Return:" + e.Exception.Message; }
        }
        #endregion

        #region private void cbEsquema_Click(object sender, EventArgs e)
        private void cbEsquema_Click(object sender, EventArgs e)
        {
            Utility.Config.UtilizaEsquema = cbEsquema.Checked;
        }
        #endregion

        #region private void executarArquivoDeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        private void executarArquivoDeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "SQL|*.sql";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnlProgress.Visible = true;
                AddLog("Arquivo Executado:\r\n" + dlgOpen.FileName + "\r\n" + DbConsole.ExecFile(dlgOpen.FileName));
                pnlProgress.Visible = false;
            }
        }
        #endregion

        #region private void organizarPorNomeToolStripMenuItem_Click(object sender, EventArgs e)
        private void organizarPorNomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] Tables = DbConsole.GetTables();
            Array.Sort(Tables);
            lstTables.Items.Clear();
            lstTables.Items.AddRange(Tables);
        }
        #endregion

        #region private void organizarPorChaveEstrangeiraToolStripMenuItem_Click(object sender, EventArgs e)
        private void organizarPorChaveEstrangeiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] Tables = DbConsole.GetTablesInOrder(cbUtilizaColchetes.Checked);
            lstTables.Items.Clear();
            lstTables.Items.AddRange(Tables);
        }
        #endregion

        #region private void organizarPorCriaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        private void organizarPorCriaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] Tables = DbConsole.GetTables();
            lstTables.Items.Clear();
            lstTables.Items.AddRange(Tables);
        }
        #endregion

        #region private void limpesaDasTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        private void limpesaDasTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "SQL|*.sql";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextFile tf = new TextFile();
                try
                {

                    if (System.IO.File.Exists(dlgSave.FileName))
                    { System.IO.File.Delete(dlgSave.FileName); }

                    tf.Open(enmOpenMode.Writing, dlgSave.FileName);

                    string[] Tables = DbConsole.GetTablesInOrder(cbUtilizaColchetes.Checked);
                    for (int i = (Tables.Length - 1); i >= 0; i--)
                    { tf.WriteLine(string.Format("DELETE FROM {0};", Tables[i])); }
                }
                catch (Exception ex)
                { AddLog(ex.Message); }
                finally
                {
                    if (tf != null)
                    { tf.Close(); }
                }
            }
        }
        #endregion

        #region private void remoçãoDasTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        private void remoçãoDasTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "SQL|*.sql";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextFile tf = new TextFile();
                try
                {

                    if (System.IO.File.Exists(dlgSave.FileName))
                    { System.IO.File.Delete(dlgSave.FileName); }

                    tf.Open(enmOpenMode.Writing, dlgSave.FileName);

                    string[] Tables = DbConsole.GetTablesInOrder(cbUtilizaColchetes.Checked);
                    for (int i = (Tables.Length - 1); i >= 0; i--)
                    { tf.WriteLine(string.Format("DROP TABLE {0};", Tables[i])); }


                }
                catch (Exception ex)
                { AddLog(ex.Message); }
                finally
                {
                    if (tf != null)
                    { tf.Close(); }
                }
            }
        }
        #endregion

        #region private void pnlProgress_VisibleChanged(object sender, EventArgs e)
        private void pnlProgress_VisibleChanged(object sender, EventArgs e)
        {
            EstimatedTime.Start();
        }
        #endregion

        #region private void btnExecutarReport_Click(object sender, EventArgs e)
        private void btnExecutarReport_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Report|*.html|SWR|*.swr";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { DbConsole.DbExecuteReport(dlgOpen.FileName, ""); }
        }
        #endregion

        private void limitarDadosDaPesquisaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbLimitar.Checked = !cbLimitar.Checked;
        }

        private void cbBinding_Click(object sender, EventArgs e)
        {
            cbSemBinding.Checked = !cbSemBinding.Checked;
        }

        private void cbUsaSchema_Click(object sender, EventArgs e)
        {
            cbUsaSchema.Checked = !cbUsaSchema.Checked;
        }

        private void txtSql_TextChanged(object sender, EventArgs e)
        {
            if (TextState.Count == 0)
            {
                TextState.Add(txtSql.Text);
            }
            else if (TextState[TextState.Count - 1] != txtSql.Text)
            {
                if (TextState.Count > 1000)
                { TextState.RemoveAt(0); }
                TextState.Add(txtSql.Text);
            }
        }

        private void txtSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Z | Keys.Control) && TextState.Count > 1)
            {
                int start = txtSql.SelectionStart;
                int sellength = txtSql.SelectionLength;

                TextState.RemoveAt(TextState.Count - 1);
                txtSql.Text = TextState[TextState.Count - 1];

                try
                {
                    txtSql.SelectionStart = start;
                    txtSql.SelectionLength = sellength;
                }
                catch { return; }
            }
        }

        private void cbInsertIdentity_Click(object sender, EventArgs e)
        {
            cbInsertIdentity.Checked = !cbInsertIdentity.Checked;
        }

        private void visualizarEsquemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tbEsquema_Enter(object sender, EventArgs e)
        {
            try
            {
                if (DbConsole.DbCurrent == null)
                { return; }

                DataTable dt = DbConsole.DbCurrent.GetSchema("");

                cmbEsquema.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                { cmbEsquema.Items.Add(dt.Rows[i][0].ToString()); }
            }
            catch { }
        }

        private void cmbEsquema_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grdEsquema.DataSource = DbConsole.DbCurrent.GetSchema(cmbEsquema.SelectedItem.ToString());
            }
            catch { }
        }

        private void exibirConexãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DbConsole.DbCurrent == null)
            {
                Msg.Warning("Conecte-se a um banco de dados");
                return;
            }

            frmExibirConexao f = new frmExibirConexao();
            f.Carregar(DbConsole.DbCurrent.ConnectionString);
            f.ShowDialog();
        }

        private void atualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DbConsole != null && DbConsole.DbCurrent != null)
            { ShowTables(false, cbTablesAndViews.Checked); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Report|*.html|SWR|*.swr";
            if (dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string FileName = dlgOpen.FileName;
                dlgSave.Filter = "Html|*.html|Excel|*.xls|Word|*.doc";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string OutputFileName = dlgSave.FileName;

                    if (System.IO.File.Exists(OutputFileName))
                    { System.IO.File.Delete(OutputFileName); }

                    DbConsole.DbExecuteReport(FileName, OutputFileName);
                }
            }
        }

        private void conexõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cpUpdateColumns_Click(object sender, EventArgs e)
        {
            cbUpdateColumns.Checked = !cbUpdateColumns.Checked;
        }

        private void cbExibeRemoverLimpar_Click(object sender, EventArgs e)
        {
            cbExibeRemoverLimpar.Checked = !cbExibeRemoverLimpar.Checked;
            btnRemoverTabela.Visible = cbExibeRemoverLimpar.Checked;
            btnLimparTabela.Visible = cbExibeRemoverLimpar.Checked;
            SeparadorRemoverLimpar.Visible = cbExibeRemoverLimpar.Checked;
        }

        private void listaDeCamposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "JSON|*.json";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnlProgress.Visible = true;
                DbConsole.ExportFieldList(dlgSave.FileName);
                pnlProgress.Visible = false;
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lib.Class.Instance.ExecProcess(Application.ExecutablePath, "", false);
        }

        private void exibirSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                string colunas = "";
                for (int i = 0; i < grdColumns.RowCount; i++)
                {
                    if (cbUtilizaColchetes.Checked)
                    {
                        colunas += (i == 0 ? "" : ", ") + "[" + grdColumns.Rows[i].Cells[0].Value + "]";
                    }
                    else
                    {
                        colunas += (i == 0 ? "" : ", ") + grdColumns.Rows[i].Cells[0].Value;
                    }
                }

                txtSql.Text += "\nselect " + colunas + " \nfrom " + lstTables.SelectedItem.ToString() + "\n";
            }
        }

        private void exibirInsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                string colunas = "";
                string values = "";
                for (int i = 0; i < grdColumns.RowCount; i++)
                {
                    if (cbUtilizaColchetes.Checked)
                    {
                        colunas += (i == 0 ? "" : ", ") + "[" + grdColumns.Rows[i].Cells[0].Value + "]";
                    }
                    else
                    {
                        colunas += (i == 0 ? "" : ", ") + grdColumns.Rows[i].Cells[0].Value;
                    }

                    values += (i == 0 ? "" : ", ") + "@" + grdColumns.Rows[i].Cells[0].Value;
                }

                txtSql.Text += "\ninsert into " + lstTables.SelectedItem.ToString() + "(" + colunas + ") \nvalues(" + values + ")" + "\n";
            }
        }

        private void exibirUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                string colunas = "";
                for (int i = 0; i < grdColumns.RowCount; i++)
                {
                    if (cbUtilizaColchetes.Checked)
                    {
                        colunas += (i == 0 ? "" : ", ") + "[" + grdColumns.Rows[i].Cells[0].Value + "]" + "=@" + grdColumns.Rows[i].Cells[0].Value;
                    }
                    else
                    {
                        colunas += (i == 0 ? "" : ", ") + grdColumns.Rows[i].Cells[0].Value + "=@" + grdColumns.Rows[i].Cells[0].Value;
                    }

                }

                txtSql.Text += "\nupdate " + lstTables.SelectedItem.ToString() + " \nset " + colunas + " \nwhere " + colunas + "\n";
            }
        }

        private void exibirDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstTables.SelectedItem != null)
            {
                string colunas = "";
                for (int i = 0; i < grdColumns.RowCount; i++)
                {
                    if (cbUtilizaColchetes.Checked)
                    {
                        colunas += (i == 0 ? "" : ", ") + "[" + grdColumns.Rows[i].Cells[0].Value + "]" + "=@" + grdColumns.Rows[i].Cells[0].Value;
                    }
                    else
                    {
                        colunas += (i == 0 ? "" : ", ") + grdColumns.Rows[i].Cells[0].Value + "=@" + grdColumns.Rows[i].Cells[0].Value;
                    }

                }

                txtSql.Text += "\ndelete from " + lstTables.SelectedItem.ToString() + " \nwhere " + colunas + "\n";
            }
        }

        private void cbUtilizaColchetes_Click(object sender, EventArgs e)
        {
            cbUtilizaColchetes.Checked = !cbUtilizaColchetes.Checked;
        }

        private void tabelasPorTamanhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTabelaTamanho f = new frmTabelaTamanho();
            f.Execute(DbConsole);
            f.ShowDialog();
        }

        PDFCreator.PDFCreator pdfCreator { get; set; }
        private string[] Grid_Fields { get; set; }
        private string[] Grid_Counters { get; set; }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Grid_Fields = new string[lstReportExibir.CheckedItems.Count];
                for (int i = 0; i < lstReportExibir.CheckedItems.Count; i++)
                { Grid_Fields[i] = lstReportExibir.CheckedItems[i].ToString(); }

                Grid_Counters = new string[lstReportTotalizar.CheckedItems.Count];
                for (int i = 0; i < lstReportTotalizar.CheckedItems.Count; i++)
                { Grid_Counters[i] = lstReportTotalizar.CheckedItems[i].ToString(); }

                DataTable dt = DbConsole.LastTable;

                pdfCreator = new PDFCreator.PDFCreator();
                pdfCreator.ConfigurePage(2, 2, 2, 2);

                pdfCreator.AddStyle("h1", "sans-serif", 16);
                pdfCreator.AddStyle("p", "sans-serif", 12);
                pdfCreator.AddStyle("th", "sans-serif", 8, true, false, false, new PDFCreator.PDFColumnBorder() { Bottom = true });
                pdfCreator.AddStyle("td", "sans-serif", 8, false, false, false, new PDFCreator.PDFColumnBorder() { Bottom = true });

                pdfCreator.Row("h1", txtReportName.Text);
                pdfCreator.Row("p", "Emissão:" + DateTime.Now.ToString("dd/MM/yy HH:mm"));

                AddColumns();
                pdfCreator.AfterAddPage += new PDFCreator.AfterAddPage_Handle(AddColumns);

                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    List<PDFCreator.PDFColumn> tdbody = new List<PDFCreator.PDFColumn>();
                    int ColNum = 1;
                    for (int c = 0; c < Grid_Fields.Length; c++)
                    {
                        if (ColNum > 12) break;
                        int colSize = 1;
                        if (dt.Columns[Grid_Fields[c]].DataType == typeof(string))
                        { colSize = 3; }
                        if (dt.Columns[Grid_Fields[c]].DataType == typeof(DateTime))
                        { colSize = 2; }

                        string dados = dt.Rows[r][Grid_Fields[c]].ToString();
                        tdbody.Add(new PDFCreator.PDFColumn() { StyleName = "td", ColumnNumber = ColNum, ColumnSize = colSize, Text = dados });
                        ColNum += colSize;
                    }
                    pdfCreator.Row(tdbody);
                }

                pdfCreator.Save(lib.Visual.Functions.GetDirAppCondig() + "teste.pdf");
                pdfCreator.Show(lib.Visual.Functions.GetDirAppCondig() + "teste.pdf");
            }
            catch (Exception ex) { lib.Visual.Msg.Warning(ex.Message); }
        }

        private void AddColumns()
        {
            DataTable dt = DbConsole.LastTable;
            List<PDFCreator.PDFColumn> thbody = new List<PDFCreator.PDFColumn>();
            int ColNum = 1;
            for (int i = 0; i < Grid_Fields.Length; i++)
            {
                if (ColNum > 12) break;
                int colSize = 1;
                if (dt.Columns[Grid_Fields[i]].DataType == typeof(string))
                { colSize = 3; }
                if (dt.Columns[Grid_Fields[i]].DataType == typeof(DateTime))
                { colSize = 2; }

                thbody.Add(new PDFCreator.PDFColumn() { StyleName = "th", ColumnNumber = ColNum, ColumnSize = colSize, Text = Grid_Fields[i] });
                ColNum += colSize;
            }
            pdfCreator.Row(thbody);
        }

        private void cbTablesAndViews_Click(object sender, EventArgs e)
        {
            cbTablesAndViews.Checked = !cbTablesAndViews.Checked;
        }

        private void truncateDasTabelasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "SQL|*.sql";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextFile tf = new TextFile();
                try
                {

                    if (System.IO.File.Exists(dlgSave.FileName))
                    { System.IO.File.Delete(dlgSave.FileName); }

                    tf.Open(enmOpenMode.Writing, dlgSave.FileName);

                    string[] Tables = DbConsole.GetTablesInOrder(cbUtilizaColchetes.Checked);
                    for (int i = (Tables.Length - 1); i >= 0; i--)
                    { tf.WriteLine(string.Format("TRUNCATE TABLE {0};", Tables[i])); }


                }
                catch (Exception ex)
                { AddLog(ex.Message); }
                finally
                {
                    if (tf != null)
                    { tf.Close(); }
                }
            }
        }


        private void removeChavesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "SQL|*.sql";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextFile tf = new TextFile();
                try
                {

                    if (System.IO.File.Exists(dlgSave.FileName))
                    { System.IO.File.Delete(dlgSave.FileName); }

                    tf.Open(enmOpenMode.Writing, dlgSave.FileName);

                    //string[] Tables = DbConsole.GetTablesInOrder(cbUtilizaColchetes.Checked);
                    //for (int i = (Tables.Length - 1); i >= 0; i--)
                    //{ tf.WriteLine(string.Format("TRUNCATE TABLE {0};", Tables[i])); }
                    ForeignKey[] keys = DbConsole.GetDependencies();
                    foreach (var item in keys)
                    {
                        tf.WriteLine(string.Format("alter table {0} drop foreign key {1};", item.TableName, item.ConstraintName));
                    }


                }
                catch (Exception ex)
                { AddLog(ex.Message); }
                finally
                {
                    if (tf != null)
                    { tf.Close(); }
                }
            }
        }

        private void compararBasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompararBases f = new frmCompararBases();
            f.Connections = DbConsole.Connections;
            f.Alias = DbConsole.Alias;
            f.ShowDialog();
        }

        private void grdRegistros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColumnName = grdRegistros.Columns[e.ColumnIndex].Name;
            string CellValue = grdRegistros.SelectedCells[0].Value.ToString();

            ForeignKey[] dependences = DbConsole.GetDependencies();

            List<string> opcoes = new List<string>();
            foreach (var item in dependences)
            {
                //string table = txtAlias.Text;
                if (item.ColumnName == ColumnName)
                {
                    string sql = string.Format("select * from {0} where {1} = '{2}'",
                        item.TableReference, item.ColumnReference, CellValue);
                    if (opcoes.IndexOf(sql) == -1)
                    {
                        opcoes.Add(sql);
                    }

                }
            }

            foreach (var item in opcoes)
            {
                txtSql.Text += Environment.NewLine + Environment.NewLine + item;
            }
            //if(e.)
        }

        private void processosAbertosSQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcess f = new frmProcess();
            f.SetDb(DbConsole);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (f.DtProcess != null)
                {
                    bool[] checkeds = f.GetTablesCheckeds();
                    for (int i = 0; i < f.DtProcess.Rows.Count; i++)
                    {
                        try
                        {
                            if (checkeds[i])
                            {
                                if (DbConsole.DbCurrent.dbType == enmConnection.SqlServer)
                                {
                                    string sql_command = "kill " + f.DtProcess.Rows[i]["spid"].ToString();
                                    DbConsole.ExecQuery(sql_command, false);
                                }

                                if (DbConsole.DbCurrent.dbType == enmConnection.PostgreSQL)
                                {
                                    string sql_command = "select pg_terminate_backend(" + f.DtProcess.Rows[i]["pid"].ToString() + "); ";
                                    DbConsole.ExecQuery(sql_command, false);
                                }
                            }
                        }
                        catch { continue; }
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            idxFilter++;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SerarchTable));
            thread.Start(idxFilter);
        }

        private void SerarchTable(object idx)
        {
            System.Threading.Thread.Sleep(800);
            if (idxFilter != (int)idx)
            { return; }

            string[] AllTables = DbConsole.GetTables();
            List<string> ListTables = new List<string>();

            if (!string.IsNullOrEmpty(txtFilterTables.Text))
            {
                string[] q_tables = txtFilterTables.Text.Split(',');
                foreach (var item in q_tables)
                {
                    string[] filtredTables = AllTables.Where(q => q.ToLower().Contains(item.ToLower())).ToArray();
                    foreach (var ft in filtredTables)
                    {
                        if (!ListTables.Contains(ft))
                        {
                            ListTables.Add(ft);
                        }
                    }
                }
            }
            else
            {
                ListTables.AddRange(AllTables);
            }
            string[] Tables = ListTables.ToArray();
            Array.Sort(Tables);
            this.BeginInvoke((Action)delegate ()
            {
                lstTables.Items.Clear();
                lstTables.Items.AddRange(Tables);
            });

        }

        private void fastCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "JSON|*.json";
            if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnlProgress.Visible = true;
                DbConsole.ExportToFastCode(dlgSave.FileName);
                pnlProgress.Visible = false;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                Utility.Config.TemplateFolder = dlgFolder.SelectedPath;
                txtTemplatePath.Text = dlgFolder.SelectedPath;
            }
        }

        private void txtTemplatePath_TextChanged(object sender, EventArgs e)
        {
            if (Utility.Config.TemplateFolder != txtTemplatePath.Text) {
                Utility.Config.TemplateFolder = txtTemplatePath.Text;
            } 
            if (System.IO.Directory.Exists(Utility.Config.TemplateFolder))
            {
                cmbTempaltes.Items.Clear();
                cmbTempaltes.Items.AddRange(System.IO.Directory.GetFiles(Utility.Config.TemplateFolder, "*.bin").Select(q => System.IO.Path.GetFileName(q)).ToArray());
            }
        }

        private string GetCode()
        {
            try
            {
                DllTemplate.Template tpl = new DllTemplate.Template();
                tpl.FileName = string.Format("{0}/{1}", txtTemplatePath.Text, cmbTempaltes.Text);
                if (!System.IO.File.Exists(tpl.FileName))
                {
                    return "";
                }
                tpl.Open();

                DllTemplate.Table tbl = new DllTemplate.Table();

                //DataTable tb = Gbl.Dados.db.GetDataTable(sql, 1, true);
                //ForeignKey[] foreignKeys = Gbl.Dados.db.GetForeignKeys();

                //tb.TableName = name;
                if (DbConsole.LastTable.TableName.Contains(".")) {
                    DbConsole.LastTable.TableName = DbConsole.LastTable.TableName.Split('.')[1].ToString().Replace("[", "").Replace("]", "");
                }
                tbl.LoadTable(DbConsole.LastTable, DbConsole.GetDependencies());

                DllTemplate.Compile cpl = new DllTemplate.Compile();
                return cpl.getCode(tpl, tbl, txtNamespace.Text);
            }
            catch { return ""; }
        }

        private void cmbTempaltes_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCode.Text = GetCode();
        }


        private void txtNamespace_TextChanged(object sender, EventArgs e)
        {
            Utility.Config.TemplateNamespace = txtNamespace.Text;
        }
    }

    public class ArgsConsulta
    {
        public string Sql { get; set; }
        public string TableName { get; set; }
        public bool Limitar { get; set; }
    }
}
