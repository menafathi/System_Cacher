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
    public partial class Debit_All : MetroFramework.Forms.MetroForm
    {
        public Debit_All()
        {
            InitializeComponent();
        }
        Debit k = new Debit();
        private void Debit_All_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = k.select("debit_account");
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[0].Width = 30;
            metroGrid1.Columns[2].Width = 40;
            metroGrid1.Columns[1].HeaderText = "الاسم";
            metroGrid1.Columns[2].HeaderText = "رصيد";
        }

        private void metroGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Clipboard.SetText(metroGrid1.CurrentRow.Cells[0].Value.ToString());
            this.Hide();
        }
    }
}
