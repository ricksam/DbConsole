using System;
using System.Collections.Generic;
using System.Text;
using lib.Class;
using lib.Database;

namespace DbConsole
{
  [Serializable]
  public class Config : Configuration
  {
    public Config()
      : base(SerializeFormat.Bin, lib.Visual.Functions.GetDirAppCondig() + "\\DbConsole.cfg")
    {
      this.IndexEstiloRelatorio = 0;
      this.EscreverMaiusculo = false;
      this.EditarDados = false;
      this.ExecutarPontoVirgula = true;
      this.EstiloVisual = false;
      this.SubstituirIgnorar = true;
      this.UtilizaEsquema = true;
      this.Instrucoes = new List<string>();
      this.TipoTextoLongo = "TEXT";
    }

    public int IndexEstiloRelatorio { get; set; }
    public bool EscreverMaiusculo { get; set; }
    public bool EditarDados { get; set; }
    public bool ExecutarPontoVirgula { get; set; }
    public bool EstiloVisual { get; set; }
    public bool SubstituirIgnorar { get; set; }
    public bool UtilizaEsquema { get; set; }
    public bool UpdateColumns { get; set; }
    public List<DbScriptType> TypeList { get; set; }
    public string TipoTextoLongo { get; set; }
    public List<string> Instrucoes { get; set; }

    public override bool Open()
    {
      bool b = base.Open();
      if (this.TypeList == null || (this.TypeList != null && this.TypeList.Count == 0))
      { this.TypeList = DbScriptTypeList.CreateItems(); }
      return b;
    }

    public void AddInstrucao(string s)
    {
      if (Instrucoes.Count != 0 && s.ToUpper() == Instrucoes[Instrucoes.Count - 1].ToUpper())
      { return; }

      Instrucoes.Add(s);

      while (Instrucoes.Count > 100)
      { Instrucoes.RemoveAt(0); }
    }
  }
}
