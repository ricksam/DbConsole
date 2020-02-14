using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DbConsole
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      //if (!lib.Class.Instance.RunningInstance())
      //{
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        //if (args.Length == 0)
        //{ 
          Application.Run(new frmPrincipal()); 
        //}
        //else
        //{ Application.Run(new frmSimples()); }
      //}
    }
  }
}
