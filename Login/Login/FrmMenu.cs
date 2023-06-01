using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void itemMuneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //FrmItem fuser = new FrmItem();
            //fitem.ShowDialog();
        }




        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItem frmItem = new FrmItem();
            frmItem.ShowDialog();
        }
    }
}
