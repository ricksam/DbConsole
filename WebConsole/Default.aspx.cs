using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lib.Class;
using lib.Database;

namespace WebConsole
{
  public partial class _Default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      cnv = new Conversion();
      if (!Page.IsPostBack)
      { CarregaConfig(); }
    }

    #region private void CarregaConfig()
    private void CarregaConfig() 
    {
      dvCfgConnection.Visible = false;
      dvTable.Visible = false;
      WebDbArgs args = new WebDbArgs(Server.MapPath(Utility.ArqConfigXml));
      args.Open();
      txtDbType.Text = args.DbType;
      txtServer.Text = args.Server;
      chkWindowsAut.Checked = args.WindowsAuthentication;
      txtDatabase.Text = args.Database;
      txtUser.Text = args.User;
      txtPassword.Text = args.Password;
      ExibeInfoConnection(args);
    }
    #endregion

    Conversion cnv { get; set; }

    #region protected void smPrincipal_Navigate(object sender, HistoryEventArgs e)
    protected void smDb_Navigate(object sender, HistoryEventArgs e)
    {
      try
      {
        if (cnv != null)
        {
          txtSql.Text = e.State["sql"].ToString();
          lblResult.Text = "";
        }
      }
      catch { }
    }
    #endregion

    private void IncrementBrowserHistory()
    {
      if (smDb.IsInAsyncPostBack && !smDb.IsNavigating)
      {
        //lblConsultas.Text = (cnv.ToInt(lblConsultas.Text) + 1).ToString();
        smDb.AddHistoryPoint("sql", txtSql.Text); 
      }
    }

    #region private void SalvaConfig()
    private void SalvaConfig() 
    {
      try
      {
        WebDbArgs args = new WebDbArgs(Server.MapPath(Utility.ArqConfigXml));
        args.DbType = txtDbType.Text;
        args.Server = txtServer.Text;
        args.WindowsAuthentication = chkWindowsAut.Checked;
        args.Database = txtDatabase.Text;
        args.User = txtUser.Text;
        args.Password = txtPassword.Text;
        if (args.Save())
        {
          ExibeInfoConnection(args);
          lib.Database.Connection cnn = Utility.getNewConnection(Server.MapPath(Utility.ArqConfigXml));
          if (cnn != null)
          { lblResult.Text = "Configuração gravada com sucesso"; }
          else
          { lblResult.Text = "O arquivo foi gravado mas com erro"; }
        }
        else
        { lblResult.Text = "Não foi possível gravar o arquivo de configuração."; }
      }
      catch (Exception ex)
      { ExibeErro(ex); }
    }
    #endregion
    
    #region public void ExibeInfoConnection(WebDbArgs args)
    public void ExibeInfoConnection(WebDbArgs args) 
    {
      lblDadosConn.Text = "Server:" + args.Server + "; Database:" + args.Database + "; Type:" + args.DbType + "; User:" + args.User + "; Senha:******;";
      ExibeTabelas();
    }
    #endregion

    #region private void ExibeTabelas()
    private void ExibeTabelas()
    {
      try
      {
        Connection cnn = Utility.getNewConnection(Server.MapPath(Utility.ArqConfigXml));
        if (cnn != null)
        {
          StringBuilder sb = new StringBuilder();
          string[] lst = cnn.GetTables();
          
          for (int i = 0; i < lst.Length; i++)
          {
            sb.Append("<div class=\"item\">");
            sb.Append(lst[i]);
            sb.Append("</div>");
          }
          
          lblTables.Text = sb.ToString();
        }
      }
      catch (Exception ex)
      { ExibeErro(ex); }
    }
    #endregion

    #region private void Executar()
    private void Executar()
    {
      try
      {
        IncrementBrowserHistory();
        StringBuilder sb = new StringBuilder();
        sb.Append("<p>");
        Connection cnn = Utility.getNewConnection(Server.MapPath(Utility.ArqConfigXml));
        if (cnn != null)
        {
          string[] sqls = txtSql.Text.Split(new char[] { ';' });
          for (int i = 0; i < sqls.Length; i++)
          {
            string sql = sqls[i].Trim();
            if (!string.IsNullOrEmpty(sql))
            {
              if (cnn.Exec(sql))
              { sb.Append("Executado com sucesso!<br />"); }
              else
              { sb.Append("Erro em sql:" + sql + "<br />"); }              
            }
          }

          if (sqls.Length == 0 && !string.IsNullOrEmpty(txtSql.Text.Trim()))
          {
            if (cnn.Exec(txtSql.Text))
            { sb.Append("Executado com sucesso!<br />"); }
            else
            { sb.Append("Erro em sql:" + txtSql.Text + "<br />"); }
          }
        }

        sb.Append("</p>");
        lblResult.Text = sb.ToString();
      }
      catch (Exception ex)
      { ExibeErro(ex); }
    }
    #endregion

    #region private void Consultar()
    private void Consultar()
    {
      try
      {        
        Connection cnn = Utility.getNewConnection(Server.MapPath(Utility.ArqConfigXml));
        if (cnn != null)
        {
          DataTable dt = cnn.GetDataTable(txtSql.Text);
          ExibeReturn(dt);
          IncrementBrowserHistory();
        }
      }
      catch (Exception ex)
      { ExibeErro(ex); }
    }
    #endregion

    #region public void ExibeErro(List<MsgError> lst)
    public void ExibeErro(Exception ex) 
    {
      lblResult.Text = 
        ex.Message + "<br />" +
        (ex.InnerException != null ? ex.InnerException.Message + "<br />" : "") +
        ex.StackTrace;
    }
    #endregion

    #region public void ExibeReturn(DataTable dt)
    public void ExibeReturn(DataTable dt) 
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("<table>");

      #region PreencheColunas
      sb.Append("<tr>");
      for (int i = 0; i < dt.Columns.Count; i++)
      {
        sb.Append("<th>");
        sb.Append(dt.Columns[i].ColumnName);
        sb.Append("</th>");
      }
      sb.Append("</tr>");
      #endregion

      #region PreencheLinhas
      for (int a = 0; a < dt.Rows.Count && a < 200; a++)
      {
        sb.Append("<tr>");
        object[] ita = dt.Rows[a].ItemArray;
        for (int b = 0; b < ita.Length; b++)
        {
          sb.Append("<td>");
          sb.Append(ita[b].ToString());
          sb.Append("</td>");
        }
        sb.Append("</tr>");
      }
      #endregion

      if (dt.Rows.Count > 200) 
      {
        sb.Append("<tr>");
        sb.Append("<td colspan=" + dt.Rows[0].ItemArray.Length + ">");
        sb.Append("O Resultado ultrapassa 200 linhas!");
        sb.Append("</td>");
        sb.Append("</tr>");
      }

      sb.Append("</table>");
      lblResult.Text = sb.ToString();
    }
    #endregion

    #region protected void btnExpRec_Click(object sender, EventArgs e)
    protected void btnExpRec_Click(object sender, EventArgs e)
    {
      if (btnExpRec.Text == "-")
      { 
        dvCfgConnection.Visible = false;
        btnExpRec.Text = "+";
      }
      else
      {
        dvCfgConnection.Visible = true;
        btnExpRec.Text = "-";
      }
    }
    #endregion

    #region protected void btnExpTable_Click(object sender, EventArgs e)
    protected void btnExpTable_Click(object sender, EventArgs e)
    {
      if (btnExpTable.Text == "-")
      {
        dvTable.Visible = false;
        btnExpTable.Text = "+";
      }
      else
      {
        dvTable.Visible = true;
        btnExpTable.Text = "-";
      }
    }
    #endregion
    
    #region protected void btnExecutar_Click(object sender, EventArgs e)
    protected void btnExecutar_Click(object sender, EventArgs e)
    {
      Executar();
    }
    #endregion

    #region protected void btnConsultar_Click(object sender, EventArgs e)
    protected void btnConsultar_Click(object sender, EventArgs e)
    {
      Consultar();
    }
    #endregion

    #region protected void btnSalvar_Click(object sender, EventArgs e)
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
      SalvaConfig();
    }
    #endregion

    #region protected void btnAtualizar_Click(object sender, EventArgs e)
    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
      ExibeTabelas();
    }
    #endregion
  }
}