using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebConsole
{
  public class SearchCommand
  {
    public SearchCommand(String Code, char[] Separators)
    {
      this.InString = false;
      this.Index = 0;
      this.Code = Code;
      this.Separators = new string(Separators);
    }

    public int Index { get; set; }
    public String Code { get; set; }
    private String Separators { get; set; }

    private bool IsSeparators(char c)
    { return Separators.IndexOf(c) != -1; }

    private bool InString { get; set; }

    public bool HasCode { get { return Index < Code.Length; } }

    public String NextCommand()
    {
      string Ret = "";
      for (int i = Index; i < Code.Length; i++)
      {
        Index = i;
        if (Code[i] == '\'')
        { InString = !InString; }

        if (IsSeparators(Code[i]) && !InString)
        {
          Index++;
          break;
        }
        else if (i == (Code.Length - 1))
        { Index++; }

        Ret += Code[i];
      }

      return Ret.Trim();
    }

    public string[] SplitCommand()
    {
      List<string> Vars = new List<string>();
      while (this.HasCode)
      {
        string s = this.NextCommand();
        if (!string.IsNullOrEmpty(s))
        { Vars.Add(s); }
      }
      return Vars.ToArray();
    }
  }
}