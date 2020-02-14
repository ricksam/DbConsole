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
  public partial class frmExibirConexao : lib.Visual.Models.frmBase
  {
    public frmExibirConexao()
    {
      InitializeComponent();
    }

    public void Carregar(string connection)
    {
      txtConnection.Text = connection;
    }
  }
}
