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
    public partial class Prodact : MetroFramework .Forms .MetroForm
    {
        public Prodact()
        {
            InitializeComponent();
        }
        Class1 i = new Class1();
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                i.insert_Type(metroTextBox3.Text);
                metroGrid1.DataSource = i.select_type();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error 1", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                i.close();
            }
        }

        private void Prodact_Load(object sender, EventArgs e)
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
                Clipboard.SetText(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                metroTextBox2.Text = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                metroGrid2.DataSource = i.view_prodact(metroTextBox2.Text);
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

        private void metroTile1_Click(object sender, EventArgs e)
        {
            try
            {
                i.send_Prodact(metroTextBox6.Text, metroTextBox1.Text, metroTextBox7.Text, metroTextBox5.Text, metroTextBox2.Text);
                metroGrid2.DataSource = i.view_prodact(metroTextBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "erroRRRRr", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }


        private void metroGrid2_DoubleClick(object sender, EventArgs e)
        {
    
        }

        private void metroGrid2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                string id = metroGrid2.CurrentRow.Cells[0].Value.ToString();
                string total = metroGrid2.CurrentRow.Cells[1].Value.ToString();
                string name = metroGrid2.CurrentRow.Cells[2].Value.ToString();
                string price = metroGrid2.CurrentRow.Cells[3].Value.ToString();
                string code = metroGrid2.CurrentRow.Cells[4].Value.ToString();
                string id_type = metroGrid2.CurrentRow.Cells[5].Value.ToString();
                i.update_Prodact(id, total, name, price, code, id_type);
                metroGrid2.DataSource = i.view_prodact(metroTextBox2.Text);
                //MessageBox.Show("تم تعديل بنجاح", "error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                i.close();
                MessageBox.Show(ex.Message, "erro 444r", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
        }
    }
}
