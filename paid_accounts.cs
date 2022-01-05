using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace systemCacher
{
    public partial class paid_accounts : MetroFramework.Forms.MetroForm
    {
        public paid_accounts(string id_user)
        {
            InitializeComponent();
            metroTextBox1.Text = id_user;
            

        }
        Debit i = new Debit();
        private void paid_accounts_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = i.select_paid_accounts(metroTextBox1.Text,metroDateTime1.Value.Year.ToString());
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[1].HeaderText = "المبلغ";
            metroGrid1.Columns[2].HeaderText = "التاريخ";
            metroGrid1.Columns[3].Visible = false;
            metroGrid1.Columns[4].Visible = false;
            metroGrid1.Columns[5].Visible = false;
        }

        private void metroDateTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(e.KeyChar))
            {
                metroGrid1.DataSource = i.select_paid_accounts(metroTextBox1.Text, metroDateTime1.Value.Year.ToString());
            }
        }
    }
}
