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
    public partial class admin : MetroFramework.Forms.MetroForm
    {
        public admin()
        {
            InitializeComponent();
        }

        private void metroGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            i.update_users(metroGrid1.CurrentRow.Cells[1].Value.ToString(), metroGrid1.CurrentRow.Cells[2].Value.ToString() ,metroGrid1.CurrentRow.Cells[3].Value.ToString(),metroGrid1.CurrentRow.Cells[0].Value.ToString() );
        }
        Seller i = new Seller();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                if (metroTextBox1.Text == "" && metroTextBox2.Text == "")
                {
                    MessageBox.Show("املاء البيانات", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
                else
                {
                    i.insert("users", new string[] { "username", "password", "Rank" }, new string[] { metroTextBox1.Text, metroTextBox2.Text, "True" });
                    metroGrid1.DataSource = i.select("users");
                    
                }
            }
            else
            {
                if (metroTextBox1.Text == "" && metroTextBox2.Text == "")
                {
                    MessageBox.Show("املاء البيانات", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
                else
                {
                    i.insert("users", new string[] { "username", "password", "Rank" }, new string[] { metroTextBox1.Text, metroTextBox2.Text, "False" });
                    metroGrid1.DataSource = i.select("users");
                }
            }
        }

        private void admin_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = i.select("users");
            metroGrid1.Columns[0].Width = 30;
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[1].HeaderText = "اسم المستخدم";
            metroGrid1.Columns[2].HeaderText = "كلمة المرور";
            metroGrid1.Columns[3].HeaderText = "صلاحيات الدخول";
        }
    }
}
