using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lib.Class;
using lib.Database;
using lib.Database.Drivers;

namespace WebConsole
{
  public static class Utility
  {
    public const string ArqConfigXml = "~/Config.xml";

    #region private Connection getNewConnection()
    /// <summary>
    /// Retorna um novo objeto de connexão
    /// </summary>
    /// <param name="ArqCfg"></param>
    /// <returns></returns>
    public static Connection getNewConnection(string CfgXml)
    {
      Connection cnn = new Connection();
      WebDbArgs w = getWebDbArgs(CfgXml);

      if (cnn.Connect(
        Connection.GetDbType(w.DbType),
        new InfoConnection(w.WindowsAuthentication, w.Server, w.Database, w.User, w.Password)
      ))
      { return cnn; }
      else
      { return null; }
    }
    #endregion

    #region public static WebDbArgs getWebDbArgs(string CfgXml)
    /// <summary>
    /// Retorna um objeto de configurações
    /// </summary>
    /// <param name="ArqCfg"></param>
    /// <returns></returns>
    private static WebDbArgs getWebDbArgs(string CfgXml)
    {
      WebDbArgs w = new WebDbArgs(CfgXml);
      if (System.IO.File.Exists(w.FileName))
      {
        w.Open();
        return w;
      }
      else
      { return null; }
    }
    #endregion
  }
}