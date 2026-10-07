using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PNDTextFileBank
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboDatabase.Text))
            {
                MessageBox.Show("Please select your database.", "Message");
                return;
            }
            else
            {
                Program.xDatabase = "ChequeDirect_" + ComboDatabase.Text;
               // Console.WriteLine(ComboDatabase.Text);
                FormData fmData = new FormData();
                fmData.Show();
                this.Hide();
            }
        }

        private void ComboDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnConnect_Click(sender, e);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            ComboDatabase.Text = "BBL_CW_AC";
        }
    }
}
