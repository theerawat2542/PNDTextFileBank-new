using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PNDTextFileBank
{
    public partial class FormData : Form
    {
        public FormData()
        {
            InitializeComponent();
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            Program.xConnToMssql();

            TextDatabase.Text = Program.xDatabase;
            ComboType.Text = "PND3";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            FormLogin fmLogin = new FormLogin();
            fmLogin.Close();

            Application.Exit();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboType.Text))
            {
                MessageBox.Show("Please select type of document.", "Warning");
                return;
            }

            string db = Program.xDatabase;
            string ToType = ComboType.Text;

            if (ComboType.Text == "PND3")
            {
                string sql = "SELECT ROW_NUMBER() OVER(ORDER BY [" + db + "].[dbo].[WHT_Amt].[DocumentNo] ASC) AS RUN_NO,"
                    + "[" + db + "].[dbo].[Vendor].[Tax ID] AS TAX_ID,"
                    + "REPLACE(CASE WHEN CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) > 1 THEN SUBSTRING([" + db + "].[dbo].[Vendor].[Name],1,CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) - 1) ELSE '' END, '@', '') AS TITLE_TEXT,"
                    + "REPLACE(CASE WHEN CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1) - (CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1) > 1 THEN SUBSTRING([" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1,CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1) - (CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1)) ELSE [" + db + "].[dbo].[Vendor].[Name] END, '@', '') AS NAME_TEXT,"
                    + "REPLACE(CASE WHEN CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1) + 1 > 1 THEN SUBSTRING([" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],CHARINDEX(' ',[" + db + "].[dbo].[Vendor].[Name],1) + 1) + 1,LEN([" + db + "].[dbo].[Vendor].[Name])) ELSE '' END, '@', '') AS LASTNAME_TEXT,"
                    + "[" + db + "].[dbo].[Vendor].[Address] AS ADDRESS_NAME,"
                    + "SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],9,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],6,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],1,4) AS PAY_DATE,"
                    + "[" + db + "].[dbo].[tbTaxType].[TaxDesc] AS INCOME_NAME,[" + db + "].[dbo].[tbTaxType].[TaxRate] AS VAT_RATE,"
                    + "[" + db + "].[dbo].[WHT_Amt].[Wtaxbat] AS PAY_PRICE,[" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] AS PAY_TAX,"
                    + "1 AS TYPE_TAX FROM [" + db + "].[dbo].[WHT_Amt] "
                    + "LEFT JOIN [" + db + "].[dbo].[tbTaxType] ON [" + db + "].[dbo].[WHT_Amt].[Withhldtaxtype] = [" + db + "].[dbo].[tbTaxType].[TaxType] "
                    + "LEFT JOIN [" + db + "].[dbo].[Vendor] ON [" + db + "].[dbo].[WHT_Amt].[VCaccnt] = [" + db + "].[dbo].[Vendor].[VendorCode ] "
                    + "WHERE [" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] <> '0' AND [" + db + "].[dbo].[Vendor].[PND] IN('04','03')";

                DataTable xResult = Program.xExecuteMssqlQuery(sql);
                int xNumResult = xResult.Rows.Count;
                if (xNumResult == 0)
                {
                    MessageBox.Show("No data found.", "Message");
                    return;
                }
                else
                {
                    DGV.DataSource = null;
                    ListBox SaveListBox = new ListBox();
                    for (int i = 0; i < xNumResult; i++)
                    {
                        SaveListBox.Items.Add(xResult.Rows[i]["RUN_NO"] + "|" + xResult.Rows[i]["TAX_ID"] + "|" + xResult.Rows[i]["TITLE_TEXT"] + "|" + xResult.Rows[i]["NAME_TEXT"] + "|" + xResult.Rows[i]["LASTNAME_TEXT"] + "|" + xResult.Rows[i]["ADDRESS_NAME"] + "|" + xResult.Rows[i]["PAY_DATE"] + "|" + xResult.Rows[i]["INCOME_NAME"] + "|" + xResult.Rows[i]["VAT_RATE"] + "|" + xResult.Rows[i]["PAY_PRICE"] + "|" + xResult.Rows[i]["PAY_TAX"] + "|" + xResult.Rows[i]["TYPE_TAX"]);
                    }
                    Program.KeepList = SaveListBox;

                    DGV.DataSource = xResult;
                    DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            } // PND3

            if (ComboType.Text == "PND53")
            {
                string sql2 = "SELECT "
                + "ROW_NUMBER() OVER(ORDER BY [" + db + "].[dbo].[WHT_Amt].[DocumentNo] ASC) AS RUN_NO,"
                + "[" + db + "].[dbo].[Vendor].[Tax ID] AS TAX_ID,"
                + "REPLACE([" + db + "].[dbo].[Vendor].[Name], '@', '') AS NAME_TEXT,"
                + "REPLACE([" + db + "].[dbo].[Vendor].[Address], '@', '') AS ADDRESS_NAME,"
                + "SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],9,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],6,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],1,4) AS PAY_DATE,"
                + "[" + db + "].[dbo].[tbTaxType].[TaxDesc] AS INCOME_NAME,"
                + "[" + db + "].[dbo].[tbTaxType].[TaxRate] AS VAT_RATE,"
                + "[" + db + "].[dbo].[WHT_Amt].[Wtaxbat] AS PAY_PRICE,"
                + "[" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] AS PAY_TAX,"
                + "1 AS TYPE_TAX "
                + "FROM [" + db + "].[dbo].[WHT_Amt] "
                + "LEFT JOIN [" + db + "].[dbo].[tbTaxType] ON [" + db + "].[dbo].[WHT_Amt].[Withhldtaxtype] = [" + db + "].[dbo].[tbTaxType].[TaxType] "
                + "LEFT JOIN [" + db + "].[dbo].[Vendor] ON [" + db + "].[dbo].[WHT_Amt].[VCaccnt] = [" + db + "].[dbo].[Vendor].[VendorCode ] "
                + "WHERE [" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] <> '0' "
                + "AND [" + db + "].[dbo].[Vendor].[PND] IN ('07','53')"
                + "AND ([" + db + "].[dbo].[Vendor].[TaxIDVendor1] IS NULL OR [" + db + "].[dbo].[Vendor].[TaxIDVendor1] = '')";

                string sql3 = "SELECT "
                + "ROW_NUMBER() OVER(ORDER BY [" + db + "].[dbo].[WHT_Amt].[DocumentNo] ASC) AS RUN_NO,"
                + "[" + db + "].[dbo].[Vendor].[Tax ID] AS TAX_ID,"
                + "REPLACE([" + db + "].[dbo].[Vendor].[Name], '@', '') AS NAME_TEXT,"
                + "REPLACE([" + db + "].[dbo].[Vendor].[Address], '@', '') AS ADDRESS_NAME,"
                + "SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],9,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],6,2) + '/' + SUBSTRING([" + db + "].[dbo].[WHT_Amt].[Clearing],1,4) AS PAY_DATE,"
                + "[" + db + "].[dbo].[tbTaxType].[TaxDesc] AS INCOME_NAME,"
                + "[" + db + "].[dbo].[tbTaxType].[TaxRate] AS VAT_RATE,"
                + "[" + db + "].[dbo].[WHT_Amt].[Wtaxbat] AS PAY_PRICE,"
                + "[" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] AS PAY_TAX,"
                + "1 AS TYPE_TAX "
                + "FROM [" + db + "].[dbo].[WHT_Amt] "
                + "LEFT JOIN [" + db + "].[dbo].[tbTaxType] ON [" + db + "].[dbo].[WHT_Amt].[Withhldtaxtype] = [" + db + "].[dbo].[tbTaxType].[TaxType] "
                + "LEFT JOIN [" + db + "].[dbo].[Vendor] ON [" + db + "].[dbo].[WHT_Amt].[VCaccnt] + '-1' = [" + db + "].[dbo].[Vendor].[VendorCode ] "
                + "WHERE [" + db + "].[dbo].[WHT_Amt].[Withholdingtaxamnt] <> '0' "
                + "AND [" + db + "].[dbo].[Vendor].[PND] IN ('07','53')";

                DataTable xResult2 = Program.xExecuteMssqlQuery(sql2);
                int xNumResult2 = xResult2.Rows.Count;

                DataTable xResult3 = Program.xExecuteMssqlQuery(sql3);
                int xNumResult3 = xResult3.Rows.Count;
                if (xNumResult2 == 0 && xNumResult3 == 0)
                {
                    MessageBox.Show("No data found.", "Message");
                    return;
                }
                else
                {
                    DGV.DataSource = null;
                    ListBox SaveListBox = new ListBox();

                    if (xNumResult2 > 0)
                    {
                        for (int i = 0; i < xNumResult2; i++)
                        {
                            SaveListBox.Items.Add(xResult2.Rows[i]["RUN_NO"] + "|" + xResult2.Rows[i]["TAX_ID"] + "|" + xResult2.Rows[i]["NAME_TEXT"] + "|" + xResult2.Rows[i]["ADDRESS_NAME"] + "|" + xResult2.Rows[i]["PAY_DATE"] + "|" + xResult2.Rows[i]["INCOME_NAME"] + "|" + xResult2.Rows[i]["VAT_RATE"] + "|" + xResult2.Rows[i]["PAY_PRICE"] + "|" + xResult2.Rows[i]["PAY_TAX"] + "|" + xResult2.Rows[i]["TYPE_TAX"]);
                        }
                    } // - False - TaxIDVendor1
                    if (xNumResult3 > 0)
                    {
                        for (int i = 0; i < xNumResult3; i++)
                        {
                            int xRunNo = xNumResult2 + Convert.ToInt32(xResult3.Rows[i]["RUN_NO"].ToString());
                            SaveListBox.Items.Add(xRunNo + "|" + xResult3.Rows[i]["TAX_ID"] + "|" + xResult3.Rows[i]["NAME_TEXT"] + "|" + xResult3.Rows[i]["ADDRESS_NAME"] + "|" + xResult3.Rows[i]["PAY_DATE"] + "|" + xResult3.Rows[i]["INCOME_NAME"] + "|" + xResult3.Rows[i]["VAT_RATE"] + "|" + xResult3.Rows[i]["PAY_PRICE"] + "|" + xResult3.Rows[i]["PAY_TAX"] + "|" + xResult3.Rows[i]["TYPE_TAX"]);

                            DataRow row = xResult2.NewRow();

                            row["RUN_NO"] = xRunNo;
                            row["TAX_ID"] = xResult3.Rows[i]["TAX_ID"];
                            row["NAME_TEXT"] = xResult3.Rows[i]["NAME_TEXT"];
                            row["ADDRESS_NAME"] = xResult3.Rows[i]["ADDRESS_NAME"];
                            row["PAY_DATE"] = xResult3.Rows[i]["PAY_DATE"];
                            row["INCOME_NAME"] = xResult3.Rows[i]["INCOME_NAME"];
                            row["VAT_RATE"] = xResult3.Rows[i]["VAT_RATE"];
                            row["PAY_PRICE"] = xResult3.Rows[i]["PAY_PRICE"];
                            row["PAY_TAX"] = xResult3.Rows[i]["PAY_TAX"];
                            row["TYPE_TAX"] = xResult3.Rows[i]["TYPE_TAX"];

                            xResult2.Rows.Add(row);
                        }
                    } // - True - TaxIDVendor1
                    Program.KeepList = SaveListBox;

                    DGV.DataSource = xResult2;
                    DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            } // PND53

            double iTotalPrice = 0;
            double iTotalTax = 0;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                iTotalPrice = iTotalPrice + Convert.ToDouble(row.Cells["PAY_PRICE"].Value);
                iTotalTax = iTotalTax + Convert.ToDouble(row.Cells["PAY_TAX"].Value);
            }

            TextPrice.Text = Convert.ToDouble(iTotalPrice).ToString("##,##0.00");
            TextTax.Text = Convert.ToDouble(iTotalTax).ToString("##,##0.00");
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ListBox xListBox = Program.KeepList;
            int xNumList = xListBox.Items.Count;
            if (xNumList < 1)
            {
                MessageBox.Show("Please execute data before.", "Warning");
                return;
            }

            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.FileName = ComboType.Text + "_TEXT.txt";
            SaveFile.Filter = "Text File | *.txt";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(SaveFile.OpenFile());
                for (int i = 0; i < xNumList; i++)
                {
                    sw.WriteLine(xListBox.Items[i]);
                }

                sw.Dispose();
                sw.Close();
            }
        }

        private void BtnChangeDb_Click(object sender, EventArgs e)
        {
            FormLogin fmLogin = new FormLogin();
            fmLogin.Show();

            Program.xDatabase = null;
            this.Close();
        }
    }
}
