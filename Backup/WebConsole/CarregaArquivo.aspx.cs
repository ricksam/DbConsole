using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConsole
{
  public partial class CarregaArquivo : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      cnv = new lib.Class.Conversion();
      if (!Page.IsPostBack)
      { CarregaConfig(); }
    }

    lib.Class.Conversion cnv { get; set; }

    private void CarregaConfig()
    {
      
      WebDbArgs args = new WebDbArgs(Server.MapPath(Utility.ArqConfigXml));
      args.Open();
      lblDadosConn.Text = "Server:" + args.Server + "; Database:" + args.Database + "; Type:" + args.DbType + "; User:" + args.User + "; Senha:******;";
    }
    
    public static byte[] StreamToByteArray(System.IO.Stream input)
    {
      byte[] buffer = new byte[16 * 1024];
      using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
      {
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
          ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
      }
    }

    protected void btnExecutarArquivo_Click(object sender, EventArgs e)
    {
      lib.Database.Connection cnn = Utility.getNewConnection(Server.MapPath(Utility.ArqConfigXml));

      lib.Class.Download d = new lib.Class.Download(64);
      string arq = d.ToString();
      byte[] bytes = StreamToByteArray(d.ToStream(txtLinkDownload.Text));

      char[] chars = new char[bytes.Length];
      for (int i = 0; i < bytes.Length; i++)
      { chars[i] = (char)bytes[i]; }

      SearchCommand sc = new SearchCommand(new string(chars), new char[] { ';' });
      cnn.BeginTransaction();
      while (sc.HasCode)
      {
        string instrucao = sc.NextCommand().Trim();

        if (instrucao.IndexOf("/*COMMIT*/") != -1) 
        {
          cnn.CommitTransaction();
          cnn.BeginTransaction();

          instrucao = instrucao.Replace("/*COMMIT*/", "");
        }

        if (!string.IsNullOrEmpty(instrucao))
        { cnn.Exec(instrucao); }
      }
      lblResult.Text = "Concluido " + DateTime.Now.ToString("dd/MM/yy HH:mm:ss");

    }
  }
}