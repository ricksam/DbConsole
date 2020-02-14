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
  public partial class frmAlter : lib.Visual.Models.frmDialog
  {
    public frmAlter()
    {
      InitializeComponent();
    }

    public string[] Fields
    {
      get
      {
        string[] res = new string[lstFields.Items.Count];
        for (int i = 0; i < lstFields.Items.Count; i++)
        { res[i] = lstFields.Items[i].ToString(); }
        return res;
      }
      set
      {
        lstFields.Items.Clear();
        lstFields.Items.AddRange(value);
      }
    }

    public string[] Conditions
    {
      get
      {
        string[] res = new string[lstConditions.Items.Count];
        for (int i = 0; i < lstConditions.Items.Count; i++)
        { res[i] = lstConditions.Items[i].ToString(); }
        return res;
      }
    }
        
    protected override void OnConfirm()
    {
      if (lstFields.Items.Count == 0)
      {
        Msg.Warning("Não é permitido selecionar todos os campos");
        return;
      }

      if (lstConditions.Items.Count == 0)
      {
        Msg.Warning("Selecione pelo menos um campo para a lista de condições");
        return;
      }

      base.OnConfirm();
    }

    private void TransmiteItem(ListBox Origem, ListBox Destino) 
    {
      int idx = Origem.SelectedIndex;
      if (idx != -1) 
      {
        Destino.Items.Add(Origem.SelectedItem);
        Origem.Items.RemoveAt(idx);
      }
    }

    private void btnGo_Click(object sender, EventArgs e)
    {
      TransmiteItem(lstFields, lstConditions);
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      TransmiteItem(lstConditions, lstFields);
    }

  }
}
