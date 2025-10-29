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
    public partial class frmTabelaTamanho : lib.Visual.Models.frmBase
    {
        public frmTabelaTamanho()
        {
            InitializeComponent();
        }

        lib.Class.Conversion cnv = new lib.Class.Conversion();

        public void Execute(DbConsole console) 
        {
            txtTabelas.Text = "";
            List<ItemCountTabela> list = new List<ItemCountTabela>();

            List<string> sqls = new List<string>();
            foreach (var item in console.GetTables(false))
            {
                sqls.Add(string.Format("select '{0}', count(*) from {0}" , item));
            }

            string sql = String.Join(" union all ", sqls);

            try
            {
                // Modo prático
                DataTable dt = console.GetQuery(sql, "sql");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(new ItemCountTabela() { Tabela = dt.Rows[i][0].ToString(), Count = cnv.ToInt(dt.Rows[i][1]) });
                }
            }
            catch
            {
                // Modo seguro porém demorado
                foreach (var item in console.GetTables(false))
                {

                    int count = CountRows(console, item);
                    console.AddLog(item + ":" + count);
                    list.Add(new ItemCountTabela() { Tabela = item, Count = count });
                }
            }
            
            txtTabelas.Text += String.Join("\r\n", list.OrderByDescending(q=>q.Count).ToList());
        }

        public int CountRows(DbConsole console, string Table)
        {
            try
            {
                DataTable dt = console.GetQuery("select count(*) from " + Table, Table);
                if (dt.Rows.Count != 0)
                {
                    return cnv.ToInt(dt.Rows[0][0]);
                }

                return 0;
            }
            catch { return 0; }
        }
    }

    public class ItemCountTabela 
    {
        public string Tabela { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Tabela, Count);
        }
    }
}
