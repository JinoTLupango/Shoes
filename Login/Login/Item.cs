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
    public partial class FrmItem : Form
    {
        private OleDbConnection con;
        public FrmItem()
        {
            InitializeComponent();
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"D:\\JinoRepos\\Jino Project\\Login\\Shoes.accdb\"");
            con.Open();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void loadDatagrid()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Shoes ORDER BY NumberOfShoes ASC", con);
            DataTable Shoes = new DataTable();
            adapter.Fill(Shoes);
            dataGridView1.DataSource = Shoes;
            dataGridView1.ReadOnly = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtShoes.Text = row.Cells["NumberOfShoes"].Value.ToString();
                txtBrand.Text = row.Cells["NameBrand"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Shoes (NumberOfShoes, NameBrand, Price) VALUES (@NumberOfShoes, @NameBrand, @Price)", con);
            cmd.Parameters.AddWithValue("@NumberOfShoes", txtShoes.Text);
            cmd.Parameters.AddWithValue("@NameBrand", txtBrand.Text);
            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
            cmd.ExecuteNonQuery();
            loadDatagrid();

            MessageBox.Show("Successfully Added.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to edit this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand("UPDATE Shoes SET NameBrand = @NameBrand, Price = @Price WHERE NumberOfShoes = @NumberOfShoes", con);
                cmd.Parameters.AddWithValue("@Name/Brand", txtBrand.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@NumberOfShoes", txtShoes.Text);
                cmd.ExecuteNonQuery();
                loadDatagrid();

                MessageBox.Show("Successfully Updated.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Shoes WHERE NumberOfShoes = @NumberofShoes", con);
                cmd.Parameters.AddWithValue("@NumberOfShoes", txtShoes.Text);
                cmd.ExecuteNonQuery();
                loadDatagrid();

                MessageBox.Show("Successfully Deleted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtShoes.Clear();
                txtBrand.Clear();
                txtPrice.Clear();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Shoes WHERE NumberOfShoes LIKE '%" + txtSearch.Text + "%' OR NameBrand LIKE '%" + txtSearch.Text + "%' ORDER BY NumberOfShoes ASC", con);
            DataTable Shoes = new DataTable();
            adapter.Fill(Shoes);
            dataGridView1.DataSource = Shoes;
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {

        }
    }
}
