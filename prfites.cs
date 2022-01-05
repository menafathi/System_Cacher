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
    public partial class prfites : MetroFramework.Forms.MetroForm
    {
        public prfites()
        {
            InitializeComponent();
        }
        Seller i = new Seller();
        private void prfites_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = i.select("paid_accounts");
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.Columns[1].HeaderText = "المبلغ";
            metroGrid1.Columns[2].HeaderText = "التاريخ";
            metroGrid1.Columns[3].Visible = false;
            metroGrid1.Columns[4].Visible = false;
            metroGrid1.Columns[5].Visible = false;
            metroGrid2.DataSource = i.select("bill_debit");
            metroGrid2.Columns[0].Visible = false;
            metroGrid2.Columns[1].HeaderText = "رقم الفوتير";
            metroGrid2.Columns[1].Width = 60;
            metroGrid2.Columns[2].Width = 70;
            metroGrid2.Columns[2].HeaderText = "اجمالي فاتوره";
            metroGrid3.DataSource = i.select_DataTable_3_item("bill", new string[] { "year", "month", "day" }, new string[] { metroDateTime1.Value.Year.ToString(), metroDateTime1.Value.Month.ToString(), metroDateTime1.Value.Day.ToString() });
            metroGrid3.Columns[0].Visible = false;
            metroGrid3.Columns[1].HeaderText = "التاريخ";
            metroGrid3.Columns[2].HeaderText = "مبلغ";
            metroGrid3.Columns[3].Visible = false;
            metroGrid3.Columns[4].Visible = false;
            metroGrid3.Columns[5].Visible = false;
            metroGrid3.Columns[6].Visible = false;

        }

        private void metroDateTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                MySqlDataReader reader1 = i.calck_bill();
                reader1.Read();
                metroTextBox5.Text = reader1["sum(total)"].ToString();
                i.close();

                MySqlDataReader reader2 = i.calck_paid_accounts();
                reader2.Read();
                metroTextBox1.Text = reader2["sum(total)"].ToString();
                i.close();

                if (metroTextBox4.Text == "")
                {
                    metroTextBox4.Text = "0";
                    metroTextBox6.Text = "0";
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {

                    if (radioButton1.Checked)
                    {
                        MySqlDataReader reader3 = i.select_1_items("bill", new string[] { "year" , metroDateTime1.Value.Year.ToString() });
                        reader3.Read();
                        metroTextBox6.Text = reader3["sum(total_price)"].ToString();
                        i.close(); 

                        metroGrid3.DataSource = i.select_DataTable_1_item("bill", new string[] { "year" }, new string[] { metroDateTime1.Value.Year.ToString() });
                    }
                    else if (radioButton2.Checked)
                    {
                        MySqlDataReader reader4 = i.select_1_items("bill", new string[] { "year", metroDateTime1.Value.Year.ToString() , "month" ,metroDateTime1.Value.Month.ToString() });
                        reader4.Read();
                        metroTextBox6.Text = reader4["sum(total_price)"].ToString();
                        i.close(); 

                        metroGrid3.DataSource = i.select_DataTable_2_item("bill", new string[] { "year", "month" }, new string[] { metroDateTime1.Value.Year.ToString(), metroDateTime1.Value.Month.ToString() });
                    }
                    else if (radioButton3.Checked)
                    {
                        MySqlDataReader reader5 = i.select_1_items("bill", new string[] { "year", metroDateTime1.Value.Year.ToString() ,"month" , metroDateTime1.Value.Month.ToString() , "day" , metroDateTime1.Value.Day.ToString()});
                        reader5.Read();
                        metroTextBox6.Text = reader5["sum(total_price)"].ToString();
                        i.close(); 

                        metroGrid3.DataSource = i.select_DataTable_3_item("bill", new string[] { "year", "month", "day" }, new string[] { metroDateTime1.Value.Year.ToString(), metroDateTime1.Value.Month.ToString(), metroDateTime1.Value.Day.ToString() });
                    }
                    else
                    {
                        MessageBox.Show("اختر الشهر او اليوم او السنة", "تنيه", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                    }
               
                    int a1, a2, a3, t;
                    a1 = int.Parse(metroTextBox1.Text);
                    a2 = int.Parse(metroTextBox5.Text);
                    a3 = int.Parse(metroTextBox6.Text);
                    t = a1 + a3 - a2;
                    metroTextBox4.Text = t.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
