using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PNDTextFileBank
{
    static class Program
    {
        public static ListBox KeepList;
        public static string xDatabase;
        public static string xConnMssql;
        public static void xConnToMssql()
        {
            xConnMssql = "Data Source=190.7.10.7;Initial Catalog=" + xDatabase +
                         ";Persist Security Info=True;User ID=sa;Password=tns2007;";
        }

        public static DataTable xExecuteMssqlQuery(string xSql)
        {
            SqlDataAdapter xDataAdapter = default(SqlDataAdapter);
            SqlConnection xConnection = new SqlConnection();
            DataTable xDataTable = new DataTable();

            try
            {
                xConnection.ConnectionString = xConnMssql;
                xConnection.Open();
                xDataAdapter = new SqlDataAdapter(xSql, xConnection);
                xDataAdapter.Fill(xDataTable);
                xConnection.Close();
                xConnection = null;
                return xDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Message");
                xDataTable = null;
            }
            return xDataTable;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
