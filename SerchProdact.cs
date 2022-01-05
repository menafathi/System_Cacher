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
    public partial class SerchProdact : MetroFramework.Forms.MetroForm
    {
        public SerchProdact()
        {
            InitializeComponent();
        }
        Class1 i = new Class1();
        Seller r = new Seller();
        private void SerchProdact_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = i.select_type();
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[1].HeaderText = "الصنف";
            metroGrid1.Columns[0].Width = 50;
        }

        private void metroGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (metroGrid1.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("لاتوجد بيانات", "error 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                metroTextBox3.Text = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                metroGrid2.DataSource = i.view_prodact(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                metroGrid2.Columns[0].HeaderText = "ID";
                metroGrid2.Columns[0].Width = 30;

                metroGrid2.Columns[1].HeaderText = "مجموع";
                metroGrid2.Columns[2].HeaderText = "اسم المنتج";
                metroGrid2.Columns[2].Width = 70;
                metroGrid2.Columns[3].HeaderText = "سعر المنتج";
                metroGrid2.Columns[4].HeaderText = "QRReader";
                metroGrid2.Columns[5].Visible = false;
            }
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (metroTextBox3.Text == "")
                    {
                        MessageBox.Show("اختار الصنف", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        metroGrid2.DataSource = r.serch_prodact(metroTextBox3.Text, metroTextBox2.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Asterisk);
            }

        }

        private void metroGrid2_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(metroGrid2.CurrentRow.Cells[0].Value.ToString());
            this.Hide();
        }
    }
}
