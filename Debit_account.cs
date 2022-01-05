using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace systemCacher
{
    public partial class Debit_account : MetroFramework.Forms.MetroForm
    {
        public Debit_account()
        {
            InitializeComponent();
        }
        Debit k = new Debit();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            { 
                string U = k.insert("debit_account", new string[] { "name", "account" }, new string[] { metroTextBox1.Text, metroTextBox2.Text });
                metroGrid1.DataSource = k.select("debit_account");
                MessageBox.Show(U, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
            }
        }

        private void Debit_account_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = k.select("debit_account");
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[0].Width = 30;
            metroGrid1.Columns[2].Width = 40;
            metroGrid1.Columns[1].HeaderText = "الاسم";
            metroGrid1.Columns[2].HeaderText = "رصيد";
        }

        private void metroGrid1_DoubleClick(object sender, EventArgs e)
        {
            
            metroTextBox1.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox2.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            metroTextBox7.Text = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            metroTextBox6.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox5.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();

            try
            {
                metroGrid2.DataSource = k.select_BIll_deb(metroGrid1.CurrentRow.Cells[0].Value.ToString());
                metroGrid2.Columns[0].Visible = false;
                metroGrid2.Columns[1].HeaderText = "رقم الفوتير";
                metroGrid2.Columns[1].Width = 60;
                metroGrid2.Columns[2].Width = 70;
                metroGrid2.Columns[2].HeaderText = "اجمالي فاتوره";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            metroTextBox4.Clear();
            metroTextBox3.Clear();
        }

        private void metroGrid1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

 

   

        private void metroGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
      
        }
        Seller i = new Seller();
        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                k.update_account(metroGrid1.CurrentRow.Cells[0].Value.ToString(), metroGrid1.CurrentRow.Cells[1].Value.ToString(), metroGrid1.CurrentRow.Cells[2].Value.ToString());
                metroGrid1.DataSource = k.select("debit_account");
                metroGrid1.Columns[0].HeaderText = "ID";
                metroGrid1.Columns[0].Width = 30;
                metroGrid1.Columns[2].Width = 40;
                metroGrid1.Columns[1].HeaderText = "الاسم";
                metroGrid1.Columns[2].HeaderText = "رصيد";
               // MessageBox.Show(msg, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                metroGrid1.DataSource = k.select("debit_account");
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroGrid2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                metroGrid3.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroGrid2.CurrentRow.Cells[1].Value.ToString() });
                metroGrid3.Columns[0].Visible = false;
                metroGrid3.Columns[1].Visible = false;
                metroGrid3.Columns[2].HeaderText = "اسم المنتج";
                metroGrid3.Columns[2].Width = 100;
                metroGrid3.Columns[3].HeaderText = "المجموع";
                metroGrid3.Columns[4].HeaderText = "الاجمالي";
                metroGrid3.Columns[5].Visible = false;
                metroGrid3.Columns[6].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox4.Text == "" && metroTextBox3.Text == "")
            {
                MessageBox.Show("يجب عليك حساب مجموع ماعليه", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (metroTextBox4.Text == "0" && metroTextBox3.Text == "0")
                {
                    MessageBox.Show("لايوجد ما يوسجل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    k.insert("paid_accounts", new string[] { "id_user", "total", "data_create", "year", "month", "day" }, new string[] { metroTextBox7.Text, metroTextBox4.Text, metroDateTime1.Value.ToLongDateString(), metroDateTime1.Value.Year.ToString(), metroDateTime1.Value.Month.ToString(), metroDateTime1.Value.Day.ToString() });
                    metroTextBox4.Text = "0";
                    metroTextBox3.Text = "0";
                    metroTextBox8.Text = "0";
                    k.delete_deb_detitles(metroTextBox7.Text);
                    metroGrid2.DataSource = k.select_BIll_deb(metroTextBox7.Text);
                    MessageBox.Show("تم دفع بنجاح", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
            try
            {
             
                if (metroTextBox7.Text == "")
                {
                    MessageBox.Show("يجب عليك اختيار العميل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MySqlDataReader reader = k.calck_debit_user(metroTextBox7.Text);
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string ka = reader["SUM(total)"].ToString();
                        if (ka == "")
                        {
                            metroTextBox3.Text = "0";
                            metroTextBox8.Text = "0";
                            metroTextBox4.Text = metroTextBox5.Text;
                        }
                        else
                        {
                            metroTextBox8.Text = ka;
                            metroTextBox3.Text = ka;
                            if (int.Parse(metroTextBox3.Text) < int.Parse(metroTextBox5.Text))
                            {
                                int a1 = int.Parse(metroTextBox3.Text);
                                int a2 = int.Parse(metroTextBox5.Text);
                                int total = a2 - a1;
                                metroTextBox4.Text = total.ToString();

                            }
                            else
                            {
                                int a1 = int.Parse(metroTextBox5.Text);
                                int a2 = int.Parse(metroTextBox3.Text);
                                int total = a2 - a1;
                                metroTextBox4.Text = total.ToString();
                            }
                            k.close();
                        }
 
                    }
                    

                    
                }
            

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == "")
            {
                MessageBox.Show("يجب عليك اختيار العميل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                paid_accounts l = new paid_accounts(metroTextBox7.Text);
                l.Show();
            }
        }


    }
}
