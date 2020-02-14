using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lib.Database;

namespace DbConsole
{
  public partial class frmItemTipo : lib.Visual.Models.frmDialog
  {
    public frmItemTipo()
    {
      InitializeComponent();
    }

    public DbScriptType DbScriptType { get; set; }

    private void Carregar() 
    {
      txtSystemType.Text = DbScriptType.SystemType.ToString();
      txtDatabaseType.Text = DbScriptType.DatabaseType;
    }

    protected override void OnConfirm()
    {
      DbScriptType.SystemType = Type.GetType(txtSystemType.Text);
      DbScriptType.DatabaseType = txtDatabaseType.Text;
      base.OnConfirm();
    }

    private void frmItemTipo_Load(object sender, EventArgs e)
    {
      Carregar();
    }
  }
}
