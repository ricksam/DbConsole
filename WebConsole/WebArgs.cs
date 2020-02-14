using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lib.Class;

namespace WebConsole
{
  #region private class WebDbArgs : Configuration
  /// <summary>
  /// Classe de configurações
  /// </summary>
  public class WebDbArgs : Configuration
  {
    private WebDbArgs() 
    { }

    public WebDbArgs(string FileName)
      : base(FileName)
    {
    }

    public bool WindowsAuthentication { get; set; }
    public string DbType { get; set; }
    public string Server { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
  }
  #endregion
}