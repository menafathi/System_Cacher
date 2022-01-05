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
    public partial class Rep_Bill : MetroFramework.Forms.MetroForm
    {
        public Rep_Bill()
        {
            InitializeComponent();
        }
        Debit i = new Debit();
        private void Rep_Bill_Load(object sender, EventArgs e)
        {
            string date = metroDateTime1.Value.Year.ToString() + "/" + metroDateTime1.Value.Month.ToString() + "/" + metroDateTime1.Value.Day.ToString();
            metroGrid1.DataSource = i.select_Rep(date);
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[2].HeaderText = "مجموع الفاتوره";
            metroGrid1.Columns[1].HeaderText = "التاريخ";
            metroGrid1.Columns[3].Visible = false;
            metroGrid1.Columns[4].Visible = false;
            metroGrid1.Columns[5].Visible = false;
            metroGrid1.Columns[6].Visible = false;

       
        }

        private void metroGrid1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            this.Hide();
        }

        private void metroDateTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string date = metroDateTime1.Value.Year.ToString() + "/" + metroDateTime1.Value.Month.ToString() + "/" + metroDateTime1.Value.Day.ToString();
                metroGrid1.DataSource = i.select_Rep(date);
            }
        }
    }
}
