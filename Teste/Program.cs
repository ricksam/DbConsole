using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Teste
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string ConnectionString =
                  string.Format(
                    "Server={0};Database={1};Uid={2};Pwd={3};",
                    new object[]
                    {
                      "191.252.61.100",
                      "wiinc",
                      "user",
                      "Bkbk@2016"
                    }
                  );
            MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
            cnn.Open();
            cnn.Close();

            //Application.Run(new Form1());
        }
    }
}
