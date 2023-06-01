using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Login
{
    public partial class Form1 : Form
    {
        private OleDbConnection con;
        private OleDbCommand cmd;
        public Form1()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\JinoRepos\\Jino Project\\Login\\Shoes.accdb");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            con.Open();

            string query = "SELECT * FROM [User] WHERE Username=@Username AND Password=@Password";

            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Login Success!!");

                        FrmMenu f2 = new FrmMenu();
                        this.Hide();
                        f2.ShowDialog();


                    }
                    else
                    {
                        MessageBox.Show("Invalid USername and Password!!");
                    }

                }
            }
            con.Close();
        }
    }
}
