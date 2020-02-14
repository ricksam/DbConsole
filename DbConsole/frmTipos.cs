using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lib.Visual;

namespace DbConsole
{
  public partial class frmTipos : lib.Visual.Models.frmDialog
  {
    public frmTipos()
    {
      InitializeComponent();
    }

    #region private void Carregar()
    private void Carregar() 
    {
      btnConfirm.Visible = false;      
      txtTextoGigante.Text = Utility.Config.TipoTextoLongo;
      this.VerifyCancel = false;

      CarregarItems();
    }
    #endregion

    #region private void CarregarItems()
    private void CarregarItems()
    {
      for (int i = 0; i < Utility.Config.TypeList.Count; i++)
      { lstTipos.Items.Add(Utility.Config.TypeList[i]); }
    }
    #endregion

    #region private void AdicionarItem()
    private void AdicionarItem() 
    {
      frmItemTipo it = new frmItemTipo();
      it.DbScriptType = new lib.Database.DbScriptType();
      if (it.Exec()) 
      {
        Utility.Config.TypeList.Add(it.DbScriptType);
        lstTipos.Items.Add(it.DbScriptType);
      }
    }
    #endregion

    #region private void AlterarItem()
    private void AlterarItem()
    {
      int idx = lstTipos.SelectedIndex;
      if (idx != -1)
      {
        frmItemTipo it = new frmItemTipo();
        it.DbScriptType = Utility.Config.TypeList[idx];
        if (it.Exec())
        {
          Utility.Config.TypeList[idx] = it.DbScriptType;
          lstTipos.Items[idx] = Utility.Config.TypeList[idx];
        }
      }
    }
    #endregion

    #region private void RemoverItem()
    private void RemoverItem() 
    {
      int idx = lstTipos.SelectedIndex;
      if (idx != -1 && Msg.Question("Tem certeza que deseja remover este item ?")) 
      {
        lstTipos.Items.RemoveAt(idx);
        Utility.Config.TypeList.RemoveAt(idx);
      }

    }
    #endregion

    #region private void Tipos_Load(object sender, EventArgs e)
    private void Tipos_Load(object sender, EventArgs e)
    {
      Carregar();
    }
    #endregion

    #region protected override void OnCancel()
    protected override void OnCancel()
    {
      Utility.Config.TipoTextoLongo = txtTextoGigante.Text;
      base.OnCancel();
    }
    #endregion

    #region private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
    private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AdicionarItem();
    }
    #endregion

    #region private void removerToolStripMenuItem_Click(object sender, EventArgs e)
    private void removerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RemoverItem();
    }
    #endregion

    #region private void lstTipos_KeyDown(object sender, KeyEventArgs e)
    private void lstTipos_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Enter)
      { AlterarItem(); }
      else if (e.KeyData == Keys.Delete)
      { RemoverItem(); }
    }
    #endregion

    #region private void lstTipos_DoubleClick(object sender, EventArgs e)
    private void lstTipos_DoubleClick(object sender, EventArgs e)
    {
      AlterarItem();
    }
    #endregion
  }
}
