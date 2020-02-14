using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lib.Class;

namespace DbConsole
{
  public class GenerateReport
  {
    public GenerateReport()
    {
      this.ReportStyleList = new ReportStyleList();
    }

    #region Fields
    public lib.Entity.DbBase db { get; set; }
    public DataTable Table { get; set; }
    public string ReportFile { get; set; }
    private string LastSqlQuery { get; set; }
    public ReportStyleList ReportStyleList { get; set; }
    
    #endregion

    #region public void Prepare(Connection cnn, DataTable tb, string repFile, string LastSqlQuery)
    public void Prepare(lib.Entity.DbBase db, DataTable tb, string repFile, string LastSqlQuery)
    {
      this.db = db;
      this.Table = tb;
      this.ReportFile = repFile;
      this.LastSqlQuery = LastSqlQuery;
    }
    #endregion

    #region private string GetFieldValue(string FieldName, enmFieldType ft)
    private string GetFieldValue(string FieldName, SqlWebReport.FieldType ft)
    {
      if (ft == SqlWebReport.FieldType.Decimal) { return string.Format("$v.mov(D.{0}); $v.format(\"#,##0.00\")", FieldName); }
      else if (ft == SqlWebReport.FieldType.Date) { return string.Format("$v.mov(D.{0}); $v.format(\"dd/MM/yyyy\")", FieldName); }
      else if (ft == SqlWebReport.FieldType.DateTime) { return string.Format("$v.mov(D.{0}); $v.format(\"dd/MM/yyyy\")", FieldName); }
      else if (ft == SqlWebReport.FieldType.Time) { return string.Format("$v.mov(D.{0}); $v.format(\"HH:mm:ss\")", FieldName); }
      else { return "D." + FieldName; }
    }
    #endregion

    #region public void Execute(string ReportTitle, bool StyleDetail, int ReportStyleIndex, string[] Fields, string[] Counters)
    public void Execute(string ReportTitle, bool StyleDetail, int ReportStyleIndex, string[] Fields, string[] Counters)
    {
      bool PossuiTot = false;
      String sCols = "";
      String sColsRep = "";
      String sColsRepForm = "";
      String sColsTot = "";
      //String sLines = "";

      for (int i = 0; i < Fields.Length; i++)
      {
        String xCssS = "class='sum'";
        String xCssT = "class='tit'";
        String xCss = "";

        SqlWebReport.FieldType ft = SqlWebReport.SwrUtility.GetFieldType(Table.Columns[Fields[i]].DataType);

        #region [formata xCssT, xCss e xCssS]
        #region if (ft == enmFieldType.Int || ft == enmFieldType.Decimal)
        if (ft == SqlWebReport.FieldType.Int || ft == SqlWebReport.FieldType.Decimal)
        {
          if (StyleDetail)
          {
            xCssS = "class='sum vlr'";
            xCssT = "class='tit vlr'";
            xCss = "class='vlr'";
          }
          else
          {
            xCssS = "class='sum'";
            xCssT = "class='tit'";
            xCss = "class='vlr'";
          }
        }
        #endregion
        #region else if (ft == enmFieldType.Date || ft == enmFieldType.Time || ft == enmFieldType.DateTime || ft == enmFieldType.Bool)
        else if (ft == SqlWebReport.FieldType.Date || ft == SqlWebReport.FieldType.Time || ft == SqlWebReport.FieldType.DateTime || ft == SqlWebReport.FieldType.Bool)
        {
          if (StyleDetail)
          {
            xCssS = "class='sum cen'";
            xCssT = "class='tit cen'";
            xCss = "class='cen'";
          }
          else
          {
            xCssS = "class='sum'";
            xCssT = "class='tit'";
            xCss = "class='vlr'";
          }
        }
        #endregion
        #endregion

        #region Cria linhas dos totais
        if (Utility.ItemInList(Fields[i], Counters))
        {
          PossuiTot = true;
          sCols += "      <?$T_" + Fields[i] + ".mov(0)?>\n";
          sColsRep += "      <?$T_" + Fields[i] + ".add(D." + Fields[i] + ")?>\n";
          sColsRepForm += "      <?$T_" + Fields[i] + ".add(D." + Fields[i] + ")?>\n";
          sColsTot += "      <td " + xCssS + "><?$T_" + Fields[i] + ".format(\"#,##0.00\")?></td>\n";
        }
        else
        { sColsTot += "      <td " + xCssS + ">&nbsp;</td>\n"; }
        #endregion

        #region Cria colunas e linhas para os modelos detail e form
        sCols += string.Format("      <td {0}>{1}</td>\n", xCssT, Fields[i]);
        sColsRep += string.Format("      <td {0}><?{1}?></td>\n", xCss, GetFieldValue(Fields[i], ft));
        sColsRepForm += string.Format("    <tr><td {0}>{1}</td><td {2}><?{3}?></td></tr>\n", xCssT, Fields[i], xCss, GetFieldValue(Fields[i], ft));
        #endregion
      }

      string sql = LastSqlQuery;
      sql = sql.Replace("\n", "\n      ");
      String lnTot = "";

      if (PossuiTot)
      {
        if (StyleDetail)
        {
          lnTot =
            "  <!-- Rodapé do Relatório -->\n" +
            "    <tr><td>&nbsp;</td></tr>\n" +
            "    <tr>\n" + sColsTot +
            "    </tr>\n";
        }
        else
        {
          lnTot =
            "  <!-- Rodapé do Relatório -->\n" +
            "    <tr><td>&nbsp;</td></tr>\n" +
            "    <tr><td class='sum'>Total</td>\n" + sColsTot +
            "    </tr>\n";
        }
      }

      String lnCols = "";
      String lnColsRep = "";

      if (StyleDetail)
      { lnCols = "    <tr>\n" + sCols + "    </tr>\n"; }

      if (StyleDetail)
      { lnColsRep = "    <tr>\n" + sColsRep + "    </tr>\n"; }
      else
      { lnColsRep = "    <tr><td><br /></td></tr>\n" + sColsRepForm; }

      String strCode =
      "<?\n" +
      "  $sc = \"" + db.ConnectionString + "\";\n" +
      "  connection.add(\"Database\",\""+db.ConnectionType.ToString()+"\",$sc);\n" +
      "  D.new(\"Database\");\n" +
      "  D.sql(\n      \"" + sql + "\"\n  );\n" +
      "?>\n" +
      "<?band1?>\n" +
      "  <style type=\"text/css\" media=\"screen\">\n" +
      "    body\n" +
      "    {\n" +
      "      background-color:#aaa;\n" +
      "      padding:20px 20px 0 20px;\n" +
      "    }\n" +
      "    .page\n" +
      "    {\n" +
      "      background-color:White;\n" +
      "      border:1px solid #777;\n" +
      "      padding:60px 40px 40px 60px;\n" +
      "    }\n" +
      "  </style>\n" +
      "  <style type=\"text/css\" media=\"all\">\n" +
      ReportStyleList[ReportStyleIndex].Style +
      "  </style>\n\n" +
      "<div class='page'>\n" +
      "  <!-- Cabeçalho do Relatório -->\n" +
      "  <h1>" + ReportTitle + "</h1>\n" +
      "  <p>Emissao : <?sys.now()?></p>\n" +
      "  <table>\n" +
      lnCols +
      "  <!-- Conteúdo do Relatório -->\n" +
      "<?band2:band1?>\n" +
      "  <?band.dst(D)?>\n" +
      lnColsRep +
      "<?endband1?>\n" +
      lnTot +
      "  </table>\n" +
      "</div>";

      if (System.IO.File.Exists(ReportFile))
      { System.IO.File.Delete(ReportFile); }

      TextFile tf = new TextFile();
      tf.Open(enmOpenMode.Writing, ReportFile);
      tf.Write(strCode);
      tf.Close();

      SqlWebReport.SwrReport sr = new SqlWebReport.SwrReport();
      sr.AddConnection(new SqlWebReport.ItemConnection("Database", db));
      SwrForms.Report.ShowReport(sr, ReportFile, new List<SqlWebReport.ParamQuery>());
    }
    #endregion

    public void ExecuteFile(string FileName, string OutputFileName)
    {
      string LogFile = FileName + ".log";

      if (System.IO.File.Exists(LogFile))
      { System.IO.File.Delete(LogFile); }

      SqlWebReport.SwrReport sr = new SqlWebReport.SwrReport();
      sr.Output = OutputFileName;
      sr.AddConnection(new SqlWebReport.ItemConnection("Database", db));
      sr.Cmp.SetLogFile(LogFile);
      SwrForms.Report.ShowReport(sr, FileName, new List<SqlWebReport.ParamQuery>());
    }
  }

  #region public class ReportStyleList
  public class ReportStyleList
  {
    public ReportStyleList()
    {
      this.Items = new List<ReportStyle>();

      this.Items.Add(new ReportStyle(
        "Simples",
        "    h1{font-family:Arial, Verdana; font-size:16pt; color:#367;}\n" +
        "    p{font-family:Verdana, Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Arial, Verdana;font-size:10pt;padding:0 5px; height:30px; vertical-align:bottom}\n" +
        "    td.tit{font-weight:bold; vertical-align:middle}\n" +
        "    td.vlr{text-align:right;}\n" +
        "    td.cen{text-align:center;}\n" +
        "    td.sum{font-weight:bold;border-top:1px solid #000; vertical-align:middle}\n"
      ));

      this.Items.Add(new ReportStyle(
        "Padrão",
        "    h1{font-family:Verdana; font-size:14pt; color:#337;}\n" +
        "    p{font-family:Verdana, Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Arial, Verdana;font-size:10pt;padding:0 5px;border-bottom:1px solid #999; height:30px; vertical-align:bottom}\n" +
        "    td.tit{font-weight:bold; color:#fff; background-color:#999; border:1px solid #777; vertical-align:middle}\n" +
        "    td.vlr{text-align:right}\n" +
        "    td.cen{text-align:center}\n" +
        "    td.sum{font-weight:bold; color:#fff; background-color:#999; border:1px solid #777; vertical-align:middle}\n"
      ));

      this.Items.Add(new ReportStyle(
        "Formal",
        "    h1{font-family:Arial, Verdana; font-size:16pt; color:#632423;text-decoration:underline;font-weight:normal}\n" +
        "    p{font-family:Verdana, Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Arial, Verdana;font-size:10pt;padding:0 5px; height:30px; vertical-align:bottom}\n" +
        "    td.tit{Color:#632423; border-bottom:1px solid #632423; vertical-align:middle}\n" +
        "    td.vlr{text-align:right}\n" +
        "    td.cen{text-align:center}\n" +
        "    td.sum{Color:#632423; border-top:1px solid #632423; vertical-align:middle}\n"
      ));

      this.Items.Add(new ReportStyle(
        "Moderno",
        "    h1{font-family:Arial, Verdana; font-size:11pt; background-color:#4f81bd; display:block; color:#fff; padding:20px;}\n" +
        "    p{font-family:Verdana, Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Verdana, Arial, Verdana;font-size:10pt;padding:0 5px; height:30px; vertical-align:bottom}\n" +
        "    td.tit{font-size:11pt; Color:#000; background-color:#dbe5f1; padding:10px; vertical-align:middle}\n" +
        "    td.vlr{text-align:right}\n" +
        "    td.cen{text-align:center}\n" +
        "    td.sum{font-size:11pt; Color:#000; background-color:#dbe5f1; padding:10px; vertical-align:middle}"
      ));

      this.Items.Add(new ReportStyle(
        "Preto e Branco",
        "    h1{font-family:Arial, Verdana; font-size:14pt;}\n" +
        "    p{font-family:Verdana, Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Arial, Verdana;font-size:10pt;padding:0 5px; height:30px; vertical-align:bottom}\n" +
        "    td.tit{font-weight:bold; vertical-align:middle}\n" +
        "    td.vlr{text-align:right;}\n" +
        "    td.cen{text-align:center;}\n" +
        "    td.sum{font-weight:bold;border-top:1px solid #000; vertical-align:middle}\n"
      ));

      this.Items.Add(new ReportStyle(
        "Tradicional",
        "    h1{font-family:Arial; font-size:14pt; color:#365f91; text-decoration:underline; font-weight:normal}\n" +
        "    p{font-family:Arial; font-size:8pt}\n" +
        "    table {border-collapse:collapse;border-spacing:0;}\n" +
        "    td{font-family:Verdana, Arial;font-size:10pt;padding:0 5px; height:30px; vertical-align:bottom}\n" +
        "    td.tit{border-bottom:1px solid #365f91; color:#365f91; vertical-align:middle}\n" +
        "    td.vlr{text-align:right;}\n" +
        "    td.cen{text-align:center;}\n" +
        "    td.sum{border-top:1px solid #365f91; color:#365f91; vertical-align:middle}\n"
      ));
    }

    public List<ReportStyle> Items { get; set; }

    public ReportStyle this[int Index]
    { get { return Items[Index]; } }

    public string[] GetNames()
    {
      string[] lst = new string[Items.Count];
      for (int i = 0; i < Items.Count; i++)
      { lst[i] = Items[i].Name; }
      return lst;
    }
  }
  #endregion

  #region public class ReportStyle
  public class ReportStyle
  {
    public ReportStyle(string Name, string Style)
    {
      this.Name = Name;
      this.Style = Style;
    }
    public string Name { get; set; }
    public string Style { get; set; }
  }
  #endregion
}
