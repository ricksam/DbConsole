using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using lib.Class;
using lib.Database;
using lib.Database.Drivers;
using lib.Visual;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace DbConsole
{


    public class DbConsole
    {
        public DbConsole()
        {
            Index = -1;
            Connections = new List<Connection>();
            Alias = new List<string>();
            GenerateReport = new GenerateReport();
        }

        public ScriptLog_Handle ScriptLog { get; set; }


        #region Types
        public delegate void ScriptLog_Handle(string log);
        public delegate void ScriptProgress_Handle(string TableName, int Index, int Count, out bool Cancel);
        #endregion

        #region Fields
        public DbColumn[] DbColumns { get; set; }
        //public ForeignKey[] ForeignKeys { get; set; }
        //public DbColumn[] DbColumns = new DbColumn[] { };
        public Connection DbCurrent
        {
            get
            {
                if (Index != -1)
                { return Connections[Index]; }
                else
                { return null; }
            }
        }
        private System.Data.Common.DbDataAdapter Adapter { get; set; }
        private GenerateReport GenerateReport { get; set; }
        public ReportStyleList ReportStyleList { get { return GenerateReport.ReportStyleList; } }
        public int Index { get; set; }
        public List<Connection> Connections { get; set; }
        public SqlBuild sb { get; set; }
        public List<string> Alias { get; set; }
        public DataTable LastTable { get; set; }
        public string LastSqlQuery { get; set; }
        public string ReportFile { get { return lib.Visual.Functions.GetDirAppCondig() + "\\Report.html"; } }
        public ScriptProgress_Handle ScriptProgress { get; set; }
        #endregion

        #region public void Add(Connection c)
        public void Add(string AliasName, Connection c)
        {
            this.Alias.Add(AliasName);
            Connections.Add(c);
            Index = Connections.Count - 1;
        }
        #endregion

        public void AddLog(string log)
        {
            if (ScriptLog != null)
            {
                ScriptLog(log);
            }
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

        public void UpdateColumns()
        {
            try
            {
                /*if (DbCurrent.GetSchema("DataTypes") == null)
                {
                  DbColumns = new DbColumn[] { };
                  return;
                }*/

                Conversion cnv = new Conversion();
                DataTable dt = DbCurrent.GetSchema("Columns");

                string ColumnDataType = "";
                string ColumnDecimalDigits = "";
                string ColumnSize = "";
                bool NumericPrecisionExists = false;

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

                NumericPrecisionExists = ColumnExists(dt, "NUMERIC_PRECISION");

                //DbColumn[] cols = new DbColumn[dt.Rows.Count];
                List<DbColumn> cols = new List<DbColumn>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    /*cols[i] = new DbColumn();
                    cols[i].TABLE_NAME = dt.Rows[i]["TABLE_NAME"].ToString();
                    cols[i].COLUMN_NAME = dt.Rows[i]["COLUMN_NAME"].ToString();
                    cols[i].DATA_TYPE = dt.Rows[i][ColumnDataType].ToString();
                    cols[i].DECIMAL_DIGITS = cnv.ToInt(dt.Rows[i][ColumnDecimalDigits]);

                    if (NumericPrecisionExists)
                    { cols[i].COLUMN_SIZE = cnv.ToInt(dt.Rows[i]["NUMERIC_PRECISION"]) == 0 ? cnv.ToInt(dt.Rows[i][ColumnSize]) : cnv.ToInt(dt.Rows[i]["NUMERIC_PRECISION"]); }
                    else
                    { cols[i].COLUMN_SIZE = cnv.ToInt(dt.Rows[i][ColumnSize]); }
                    */

                    DbColumn column = new DbColumn();
                    column.TABLE_NAME = dt.Rows[i]["TABLE_NAME"].ToString();
                    column.COLUMN_NAME = dt.Rows[i]["COLUMN_NAME"].ToString();
                    column.DATA_TYPE = dt.Rows[i][ColumnDataType].ToString();
                    column.DECIMAL_DIGITS = cnv.ToInt(dt.Rows[i][ColumnDecimalDigits]);

                    if (NumericPrecisionExists)
                    { column.COLUMN_SIZE = cnv.ToInt(dt.Rows[i]["NUMERIC_PRECISION"]) == 0 ? cnv.ToInt(dt.Rows[i][ColumnSize]) : cnv.ToInt(dt.Rows[i]["NUMERIC_PRECISION"]); }
                    else
                    { column.COLUMN_SIZE = cnv.ToInt(dt.Rows[i][ColumnSize]); }

                    cols.Add(column);
                }

                DbColumns = cols.ToArray();
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("Erro ao pesquisar as colunas.\n" + ex.Message); }
        }

        #region public void Clear()
        public void Clear()
        {
            for (int i = 0; i < Connections.Count; i++)
            {
                Connections[i].DbConnection.Dispose();
                Connections[i].DbConnection = null;
            }
            Alias.Clear();
            Connections.Clear();
            Index = -1;
        }
        #endregion

        #region public DataTable GetQuery(string Sql, string TableName)
        public DataTable GetQuery(string Sql, string TableName)
        {
            return GetQuery(Sql, TableName, 0);
        }

        public DataTable GetQuery(string Sql, string TableName, int MaxRows, bool ShowErrors = true)
        {
            try
            {
                if (!string.IsNullOrEmpty(Sql))
                {
                    if (MaxRows != 0)
                    { Sql = DbCurrent.GetLimitLines(Sql, MaxRows); }

                    LastSqlQuery = Sql;

                    DbCurrent.DbConnection.Open();

                    if (Adapter != null)
                    {
                        Adapter.Dispose();
                        Adapter = null;
                    }

                    Adapter = DbCurrent.GetDataAdapter(Sql);
                    LastTable = new DataTable(TableName);
                    Adapter.Fill(LastTable);
                }
                return LastTable;
            }
            catch (Exception ex)
            {
                if (ShowErrors)
                { Msg.Warning(ex.Message); }

                return null;
            }
            finally
            {
                if (DbCurrent != null)
                {
                    if (DbCurrent.DbConnection != null && this.DbCurrent.DbConnection.State == ConnectionState.Open)
                    { DbCurrent.DbConnection.Close(); }
                }
            }
        }
        #endregion


        #region public void FillSchema(DataTable tb)
        public void FillSchema(DataTable tb)
        {
            try
            {
                if (Utility.Config.UtilizaEsquema)
                {
                    Adapter.FillSchema(tb, SchemaType.Source);
                    //Adapter.FillSchema(tb, SchemaType.Mapped);
                }
            }
            catch (Exception ex)
            { Msg.Warning(ex.Message); }
        }
        #endregion

        #region private DbScript CreateDbScript()
        public DbScript CreateDbScript(bool UseSquareBrackets)
        {
            DbScript s = new DbScript(DbCurrent, UseSquareBrackets);
            s.DefaultBigText = Utility.Config.TipoTextoLongo;
            s.DbScriptTypeList.Clear();
            s.DbScriptTypeList.AddRange(Utility.Config.TypeList);
            return s;
        }
        #endregion

        #region public int GetSizeField(DataTable tb, int ColumnIndex)
        public int GetSizeField(DataTable tb, int ColumnIndex)
        {
            int max = tb.Columns[ColumnIndex].MaxLength * 8;

            if (max < 60)
            { max = 60; }
            if (max > 400)
            { max = 400; }

            if (tb.Columns[ColumnIndex].DataType == typeof(int))
            { return 90; }
            if (tb.Columns[ColumnIndex].DataType == typeof(decimal))
            { return 90; }
            if (tb.Columns[ColumnIndex].DataType == typeof(DateTime))
            { return 120; }

            return max;
        }
        #endregion

        private bool HasColumn(DataTable d, string ColumnName)
        {
            for (int i = 0; i < d.Columns.Count; i++)
            {
                if (d.Columns[i].ColumnName.ToUpper() == ColumnName.ToUpper())
                { return true; }
            }

            return false;
        }

        public string[] GetIndexesPrimary(DataTable dt_indexes, string TableName) {
            List<string> indexes_names = new List<string>();

            // Modelo utilizado pelo SQL Server e provavelmente pelo Postgree
            if (HasColumn(dt_indexes, "table_name") && HasColumn(dt_indexes, "type_desc") && HasColumn(dt_indexes, "index_name"))
            {
                for (int i = 0; i < dt_indexes.Rows.Count; i++)
                {
                    string schema = dt_indexes.Rows[i]["table_schema"].ToString();
                    string table = dt_indexes.Rows[i]["table_name"].ToString();
                    if ($"[{schema}].[{table}]".ToUpper() == TableName.ToUpper()
                        && dt_indexes.Rows[i]["type_desc"].ToString().ToUpper() == "CLUSTERED")
                    {
                        indexes_names.Add(dt_indexes.Rows[i]["index_name"].ToString());
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
                        indexes_names.Add(dt_indexes.Rows[i]["index_name"].ToString());
                    }
                }
            }

            return indexes_names.ToArray();
        }

        public string[] GetColumnsPrimaries(DataTable dt_indexes, DataTable dt_indexColumns, string TableName) {
            string[] indexes_names = GetIndexesPrimary(dt_indexes, TableName);
            List<string> primaries = new List<string>();
            if (HasColumn(dt_indexColumns, "table_name") && HasColumn(dt_indexColumns, "index_name") && HasColumn(dt_indexColumns, "column_name"))
            {
                for (int i = 0; i < dt_indexColumns.Rows.Count; i++)
                {
                    foreach (var index_name in indexes_names)
                    {
                        string schema = dt_indexColumns.Rows[i]["table_schema"].ToString();
                        string table = dt_indexColumns.Rows[i]["table_name"].ToString();
                        if ($"[{schema}].[{table}]".ToUpper() == TableName.ToUpper()
                        && dt_indexColumns.Rows[i]["index_name"].ToString().ToUpper() == index_name.ToUpper())
                        {
                            primaries.Add(dt_indexColumns.Rows[i]["column_name"].ToString());
                        }
                    }
                    
                }
            }
            return primaries.ToArray();
        }

        public string GetFirstColumnPrimary(DataTable dt_indexes, DataTable dt_indexColumns, string TableName)
        {
            string[] primaries = GetColumnsPrimaries(dt_indexes, dt_indexColumns, TableName);
            return primaries.Length != 0 ? primaries[0]:"";
        }


        #region public string GetDbTypeField(DataTable tb, int ColumnIndex)
        public string GetDbTypeField(DataTable tb, int ColumnIndex)
        {
            string type = tb.Columns[ColumnIndex].DataType.ToString();

            if (tb.Columns[ColumnIndex].DataType == typeof(string))
            { type += string.Format("({0})", tb.Columns[ColumnIndex].MaxLength); }

            if (tb.Columns[ColumnIndex].AutoIncrement)
            { type = "AUTO, " + type; }

            type = type + ", " + (tb.Columns[ColumnIndex].AllowDBNull ? "null" : "not null");
            return type;
        }
        #endregion

        private string GetFastCodeType(DataTable tb, int ColumnIndex, ForeignKey[] foreignKeys, out string role, DataColumn[] PrimaryKeys)
        {
            role = "";

            if (PrimaryKeys.FirstOrDefault(q => q.ColumnName == tb.Columns[ColumnIndex].ColumnName) != null)
            {
                return "pk";
            }

            ForeignKey fk = foreignKeys.FirstOrDefault(q => q.TableName == tb.TableName && q.ColumnName == tb.Columns[ColumnIndex].ColumnName);

            if (fk!=null) {
                role = fk.ColumnReference;
                if (fk.TableReference.Contains("."))
                {
                    return fk.TableReference.Split('.')[1].Replace("[", "").Replace("]", "");
                }
                else
                {
                    return fk.TableReference;
                }
                
            }

            if (tb.Columns[ColumnIndex].DataType == typeof(int))
            {
                return "number";
            }
            else if (tb.Columns[ColumnIndex].DataType == typeof(decimal))
            {
                return "value";
            }
            else if (tb.Columns[ColumnIndex].DataType == typeof(bool))
            {
                return "bool";
            }
            else if (tb.Columns[ColumnIndex].DataType == typeof(DateTime))
            {
                return "date";
            }
            else
            {
                return "text";
            }
        }

        #region private string GetSqlError(Exception ex)
        private string GetSqlError(Exception ex)
        {
            string s_erro = "";
            do
            {
                s_erro += ex.Message + "\r\n";
                ex = ex.InnerException;
            } while (ex != null);
            return s_erro;
        }
        #endregion

        #region public void ExecQuery()
        public string ExecQuery(string Sql, bool AutoExec)
        {
            //Connection cnnExec = new Connection();
            //cnnExec.Connect(DbCurrent.dbType, DbCurrent.Info);

            if (!AutoExec)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Sql))
                    {
                        DbCurrent.Exec(Sql);
                        return "Executado com sucesso!\r\n";
                    }
                    else
                    { return "Nr de instruções : 0 \r\n"; }
                }
                catch (Exception ex)
                { return GetSqlError(ex); }
            }
            else
            {
                SearchCommand sc = new SearchCommand(Sql, new char[] { ';' });

                string s_log = "";
                int Count = 0;

                while (sc.HasCode)
                {
                    if (ScriptProgress != null)
                    {
                        bool Cancel = false;
                        if ((Count % 25) == 0)
                        {
                            ScriptProgress("SQL executado:" + Count, sc.Index, sc.Code.Length, out Cancel);
                        }

                        if (Cancel)
                        { break; }
                    }

                    string instrucao = sc.NextCommand().Trim();
                    if (!string.IsNullOrEmpty(instrucao))
                    {
                        Count++;
                        try
                        {
                            DbCurrent.Exec(instrucao);
                            s_log += "Executado com sucesso!\r\n";
                        }
                        catch (Exception ex)
                        {
                            s_log += GetSqlError(ex);
                            break;
                        }
                    }
                }

                return string.Format("Nr de instruções : {0} \r\n", Count) + s_log;
            }
        }
        #endregion

        #region public string ExecFile(string FileName)
        public string ExecFile(string FileName)
        {
            TextFile tf = new TextFile();
            tf.Open(enmOpenMode.Reading, FileName);

            string buffer = "";
            int CountInstrucoes = 0;
            bool Cancel = false;
            long bytes = 0;
            long total_bytes = tf.GetSize();
            string line = "";

            List<string> identity_tables = DbCurrent.GetIdentityTables();
            DbCurrent.BeginTransaction();

            while ((line = tf.ReadLine()) != null)
            {
                if (Cancel)
                { break; }

                bytes += line.Length;

                if (line.Trim() == DbScript.COMMIT_COMMAND || line.Trim() == "GO")
                {
                    DbCurrent.CommitTransaction();
                    DbCurrent.BeginTransaction();
                    continue;
                }

                if (line.Contains("SET IDENTITY_INSERT"))
                {

                    int idx_start = line.IndexOf("SET IDENTITY_INSERT");
                    int idx_end = line.IndexOf(" ON ");

                    string sub_string = line.Substring(idx_start, idx_end + 4).ToUpper();
                    string table_script = sub_string.Replace("SET IDENTITY_INSERT ", "").Replace(" ON ", "").Replace("[", "").Replace("]", "");

                    if (DbCurrent.dbType == enmConnection.SqlServer)
                    {
                        string tabela_localizada = identity_tables.FirstOrDefault(q => q.ToUpper() == table_script);
                        if (string.IsNullOrEmpty(tabela_localizada))
                        {
                            line = line.Replace(sub_string, "");
                        }
                    }
                    else
                    {
                        line = line.Replace(sub_string, "");
                    }
                    /*
                    PrimaryKey[] primaryKey = primarykeys.Where(q => q.Table.ToUpper() == table_script).ToArray();

                    if (primaryKey.Length != 1) {
                        line = line.Replace(sub_string, "");
                    }    
                    */
                }

                //buffer += " " + line;

                bool PodeExecutar = line.IndexOf(";") != -1;

                if (string.IsNullOrEmpty(buffer))
                {
                    if (PodeExecutar && line.Count(q => q == '\'') % 2 == 1)
                    {
                        PodeExecutar = false;
                    }
                }
                else
                {
                    if (PodeExecutar && (buffer + line).Count(q => q == '\'') % 2 == 1)
                    {
                        PodeExecutar = false;
                    }
                }

                if (PodeExecutar)
                {
                    buffer += " " + (line.Trim() == "GO" ? "" : line);

                    string comando = "";
                    try
                    {
                        string prefix = "";
                        if (DbCurrent.dbType == enmConnection.SqlServer)
                        { prefix = "set dateformat ymd"; }

                        comando = prefix + buffer;

                        DbCurrent.Exec(comando);

                        buffer = "";
                        CountInstrucoes++;
                        ScriptProgress("SQL executado:" + CountInstrucoes, (int)(bytes * 1000 / total_bytes), 1000, out Cancel);
                    }
                    catch (Exception ex)
                    {
                        return GetSqlError(ex);
                    }
                }
                else
                { buffer += " " + line; }

                if (Cancel)
                { break; }
            }

            DbCurrent.CommitTransaction();
            tf.Close();

            return string.Format("Nr de instruções executadas : {0} \r\n", CountInstrucoes);
        }
        #endregion

        #region public string[] GetTables()
        public DataTable GetSchema(string CollectionName)
        { return DbCurrent.GetSchema(CollectionName); }

        public string[] GetTables(bool WithViews = true, bool WithSchema = true)
        {
            if (Index != -1)
            { return DbCurrent.GetTables(WithViews, WithSchema); }
            else
            { return new string[] { }; }
        }
        #endregion

        #region public string[] GetDependencies(string TableName)
        public ForeignKey[] GetDependencies()
        {

            return DbCurrent.GetForeignKeys();
        }

        public ForeignKey[] GetDependencies(string TableName)
        {
            ForeignKey[] fKeys = GetDependencies();
            List<ForeignKey> Dep = new List<ForeignKey>();
            for (int i = 0; i < fKeys.Length; i++)
            {
                if (fKeys[i].TableReference.ToUpper() == TableName.ToUpper())
                { Dep.Add(fKeys[i]); }
            }
            return Dep.ToArray();
        }
        #endregion

        #region public string[] GetTablesInOrder()
        public string[] GetTablesInOrder(bool UseSquareBrackets, bool WithSchema = true)
        {
            try
            {
                DbScript dbs = CreateDbScript(UseSquareBrackets);// new DbScript(DbCurrent);
                return dbs.GetTablesInOrder(1000, WithSchema);
            }
            catch (Exception ex)
            { Msg.Warning(ex.Message); }
            return new string[] { };
        }
        #endregion

        #region public void UseConnection(string Name)
        public void UseConnection(string Name)
        {
            for (int i = 0; i < Alias.Count; i++)
            {
                if (Alias[i] == Name)
                { Index = i; }
            }
        }
        #endregion

        #region public void UpdateRowToDatabase(DataTable tb)
        public string UpdateRowToDatabase(DataTable tb, bool WithoutBinding)
        {
            if (WithoutBinding)
            { return ""; }

            try
            {
                System.Data.Common.DbCommandBuilder cmdbldr = DbCurrent.GetCommandBuilder(Adapter);
                Adapter.Update(tb);
                return "";
            }
            catch (Exception ex)
            { return ex.Message; }
        }
        #endregion

        #region public string CleanTable(string TableName)
        public string CleanTable(string TableName)
        {
            if (Msg.Question("Tem certeza que deseja limpar a tabela " + TableName))
            { return ExecQuery("delete from " + TableName, false); }
            return "";
        }
        #endregion

        #region public string DropTable(string TableName)
        public string DropTable(string TableName)
        {
            if (Msg.Question("Tem certeza que deseja apagar a tabela " + TableName))
            { return ExecQuery("drop table " + TableName, false); }
            return "";
        }
        #endregion

        #region public string GetMetadataTable(DataTable tb)
        public string GetMetadataTable(DataTable tb, bool UseSquareBrackets)
        {
            if (tb == null)
            { return ""; }

            DbScript s = CreateDbScript(UseSquareBrackets);
            return s.GetMetadataTable(DbColumns, tb, UseSquareBrackets) + ";";
        }
        #endregion

        #region public void SalveScriptInsert(DataTable tb, string FileName)
        public void SalveScriptInsert(DataTable tb, string FileName, bool UseInsertIdentity, bool UseSquareBrackets)
        {
            DbScript s = CreateDbScript(UseSquareBrackets);//;new DbScript(DbCurrent);
            s.SalveScriptInsert(tb, FileName, UseInsertIdentity, UseSquareBrackets);
        }
        #endregion

        #region public void SalveScriptUpdate(DataTable tb, string FileName)
        public void SalveScriptUpdate(DataTable tb, string FileName, string[] ColumnsConditions, bool UseSquareBrackets)
        {
            DbScript s = CreateDbScript(UseSquareBrackets);//new DbScript(DbCurrent);
            s.SalveScriptUpdate(tb, FileName, ColumnsConditions);
        }
        #endregion

        #region public void ExportMetadataTables(string FileName)
        public void ExportMetadataTables(string FileName, string[] TablesSelected, bool UseSquareBrackets)
        {
            if (System.IO.File.Exists(FileName))
            { System.IO.File.Delete(FileName); }

            TextFile tf = new TextFile();
            tf.Open(enmOpenMode.Writing, FileName);

            string[] Tables = GetTablesInOrder(UseSquareBrackets);
            for (int i = 0; i < Tables.Length; i++)
            {
                if (!Utility.ItemInList(Tables[i], TablesSelected))
                { continue; }

                if (ScriptProgress != null)
                {
                    bool Cancel;
                    ScriptProgress(Tables[i], i, Tables.Length, out Cancel);
                    if (Cancel)
                    {
                        tf.Close();
                        break;
                    }
                }

                string table = Tables[i];
                if (UseSquareBrackets && !table.Contains("["))
                { table = string.Format("[{0}]", table); }

                DataTable dt = GetQuery("select * from " + table, Tables[i], 1);
                if (dt == null)
                { continue; }

                FillSchema(dt);
                tf.WriteLine(GetMetadataTable(dt, UseSquareBrackets));
                tf.WriteLine(" ");
            }

            tf.WriteLine(DbScript.COMMIT_COMMAND);
            tf.Close();
        }
        #endregion

        public string Indent(string s)
        {
            string r = "";
            int l = 0;
            bool cancel = false;
            for (int i = 0; i < s.Length; i++)
            {
                ScriptProgress("COLUMNS", i, s.Length, out cancel);

                if (cancel)
                { break; }

                if (s[i] == ',')
                { r += s[i] + "\n".PadRight(l); }
                else if (s[i] == '{' || s[i] == '[')
                {
                    l += 2;
                    r += s[i] + "\n".PadRight(l);
                }
                else if (s[i] == '}' || s[i] == ']')
                {
                    l -= 2;
                    r += "\n".PadRight(l) + s[i];
                }
                else
                { r += s[i].ToString(); }
            }

            return r;
        }

        public void ExportFieldList(string FileName)
        {
            if (System.IO.File.Exists(FileName))
            { System.IO.File.Delete(FileName); }

            lib.Class.TextFile tf = new TextFile();
            tf.Open(enmOpenMode.Writing, FileName);
            tf.Write(Indent((new JSON()).Serialize(this.DbColumns)));
            tf.Close();
        }

        public void ExportToFastCode(string FileName)
        {
            if (System.IO.File.Exists(FileName))
            { System.IO.File.Delete(FileName); }

            lib.Class.TextFile tf = new TextFile();
            tf.Open(enmOpenMode.Writing, FileName);


            string[] tablesWithSchema = GetTables(false, true); // GetTablesInOrder(false, false);
            string[] tables = GetTables(false, false);

            ForeignKey[] foreignKeysWithSchema = DbCurrent.GetForeignKeys();

            var entities = new List<object>();

            bool cancel = false;
            for (int it = 0; it < tables.Length; it++)
            {
                var table = tables[it];
                ScriptProgress(table, it, tables.Length, out cancel);

                if (cancel) {
                    break;
                }

                try
                {
                    string sql =  "select * from " + tablesWithSchema[it] + " where 1=0";
                    DataTable tb = GetQuery(sql, tablesWithSchema[it]);
                    FillSchema(tb);

                    if (tb == null || tb.Columns == null) {
                        continue;
                    }

                    var fields = new List<object>();
                    var primaryKeys = tb.PrimaryKey;

                    if (primaryKeys.Length != 1)
                    {
                        continue;
                    }

                    for (int i = 0; i < tb.Columns.Count; i++)
                    {
                        string role;
                        string col_name = tb.Columns[i].ColumnName;
                        string col_type = GetFastCodeType(tb, i, foreignKeysWithSchema, out role, tb.PrimaryKey);
                        int size = tb.Columns[i].MaxLength / 5;

                        if (size < 4) { size = 4; }

                        if (size > 12) { size = 12; }

                        fields.Add(new
                        {
                            title = col_name,
                            name = col_name,
                            placeholder = col_name,
                            type = col_type,
                            size,
                            role
                        });
                    }

                    entities.Add(new
                    {
                        title = table,
                        name = table,
                        fields
                    });
                }
                catch
                {
                    continue;
                }
            }

            //tf.Write(Indent((new JSON()).Serialize(new { entities })));
            tf.Write((new JSON()).Serialize(new { name = "WebApplication1", entities }));

            tf.Close();
        }

        #region public void ExportDadosTables(string FileName)
        public void ExportDataTables(string FileName, string[] TablesSelected, bool UseInsertIdentity, bool UseSquareBrackets, bool RewriteFile, bool MultipleFiles)
        {
            if (RewriteFile)
            {
                if (System.IO.File.Exists(FileName))
                { System.IO.File.Delete(FileName); }
            }

            string[] Tables = GetTablesInOrder(UseSquareBrackets);
            for (int i = 0; i < Tables.Length; i++)
            {
                if (!Utility.ItemInList(Tables[i], TablesSelected))
                { continue; }

                if (ScriptProgress != null)
                {
                    bool Cancel;
                    ScriptProgress(Tables[i], i, Tables.Length, out Cancel);
                    if (Cancel) { break; }
                }

                string table = Tables[i];
                if (UseSquareBrackets && !Tables[i].Contains("["))
                {
                    table = string.Format("[{0}]", Tables[i]);
                }
                DataTable dt = GetQuery("select * from " + table, Tables[i]);
                if (dt == null)
                { continue; }

                FillSchema(dt);

                string Arquivo = FileName;
                if (MultipleFiles)
                {
                    string dir = System.IO.Path.GetDirectoryName(FileName);
                    string file = System.IO.Path.GetFileName(FileName);
                    Arquivo = dir + "\\" + "F" + (i + 1).ToString("000000") + "_" + Tables[i] + "_" + file;
                }

                SalveScriptInsert(dt, Arquivo, UseInsertIdentity, UseSquareBrackets);
            }
        }
        #endregion

        #region public void ExportMetadataWithDataTabelas(string FileName)
        public void ExportMetadataWithDataTabelas(string FileName, string[] TablesSelected, bool UseInsertIdentity, bool MultipleFiles)
        {
            ExportMetadataTables(FileName, TablesSelected, UseInsertIdentity);
            ExportDataTables(FileName, TablesSelected, UseInsertIdentity, UseInsertIdentity, false, MultipleFiles);

            /*if (System.IO.File.Exists(FileName))
            { System.IO.File.Delete(FileName); }

            string[] Tables = GetTablesInOrder();
            for (int i = 0; i < Tables.Length; i++)
            {
              if (!Utility.ItemInList(Tables[i], TablesSelected))
              { continue; }

              if (ScriptProgress != null)
              {
                bool Cancel;
                ScriptProgress(Tables[i], i, Tables.Length, out Cancel);
                if (Cancel) { break; }
              }

              DataTable dt = GetQuery("select * from " + Tables[i], Tables[i]);
              if (dt == null) 
              { continue; }

              FillSchema(dt);

              TextFile tf = new TextFile();
              tf.Open(enmOpenMode.Writing, FileName);
              if (i != 0)
              { tf.WriteLine(" "); }
              tf.WriteLine(GetMetadataTable(dt));
              tf.WriteLine(" ");
              tf.Close();

              tf.WriteLine(DbScript.COMMIT_COMMAND);
              SalveScriptInsert(dt, FileName,UseInsertIdentity);
            }*/
        }
        #endregion

        private lib.Entity.ConnectionType getSwrDbType(lib.Database.Drivers.enmConnection type)
        {
            switch (type)
            {
                case enmConnection.NoDatabase: return lib.Entity.ConnectionType.None;
                case enmConnection.Access: return lib.Entity.ConnectionType.Access;
                case enmConnection.Firebird: return lib.Entity.ConnectionType.Firebird;
                case enmConnection.Interbase: return lib.Entity.ConnectionType.Firebird;
                case enmConnection.MySql: return lib.Entity.ConnectionType.MySql;
                case enmConnection.Odbc: return lib.Entity.ConnectionType.Odbc;
                case enmConnection.OleDb: return lib.Entity.ConnectionType.OleDb;
                case enmConnection.Oracle: return lib.Entity.ConnectionType.Oracle;
                case enmConnection.SQLite: return lib.Entity.ConnectionType.SQLite;
                case enmConnection.SqlServer: return lib.Entity.ConnectionType.SqlServer;
                case enmConnection.PostgreSQL: return lib.Entity.ConnectionType.PostgreSQL;
                default: return lib.Entity.ConnectionType.None;
            }
        }

        public void DbGenerateReport(string ReportTitle, bool StyleDetail, int ReportStyleIndex, string[] Fields, string[] Counters)
        {
            lib.Entity.DbBase db = lib.Entity.CreateConnection.Create(getSwrDbType(DbCurrent.dbType), DbCurrent.ConnectionString);
            GenerateReport.Prepare(db, LastTable, ReportFile, LastSqlQuery);
            GenerateReport.Execute(ReportTitle, StyleDetail, ReportStyleIndex, Fields, Counters);
        }

        public void DbExecuteReport(string FileName, string OutputFileName)
        {
            lib.Entity.DbBase db = lib.Entity.CreateConnection.Create(getSwrDbType(DbCurrent.dbType), DbCurrent.ConnectionString);
            GenerateReport.Prepare(db, LastTable, ReportFile, LastSqlQuery);
            GenerateReport.ExecuteFile(FileName, OutputFileName);
        }
    }
}
