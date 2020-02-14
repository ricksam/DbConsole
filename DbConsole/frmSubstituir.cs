using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DbConsole
{
  public partial class frmSubstituir : lib.Visual.Models.frmDialog
  {
    public frmSubstituir()
    {
      InitializeComponent();
    }

    public string Localizar { get { return txtLocalizar.Text; } }
    public string Substituir { get { return txtSubstituir.Text; } }

    private void frmSubstituir_Load(object sender, EventArgs e)
    {
      cbIgnorar.Checked = true;

    }

    private void frmSubstituir_FormClosed(object sender, FormClosedEventArgs e)
    {

    }
  }
}
