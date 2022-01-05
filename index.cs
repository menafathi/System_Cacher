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

    public partial class index : MetroFramework.Forms .MetroForm
    {
    
        public index()
        {

            InitializeComponent();
        }
        public string id_user;
        public string Rank;
        public string username;
        Debit k = new Debit();
        Seller i = new Seller();
        private void index_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            metroLabel1.Text = DateTime.Now.ToLongTimeString();
            metroTextBox1.Text = id_user.ToString();
            metroTextBox2.Text = username.ToString();
            metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", "" });
            metroGrid1.Columns[0].HeaderText = "ID";
            metroGrid1.Columns[0].Width = 30;
            metroGrid1.Columns[1].Visible = false;
            metroGrid1.Columns[2].HeaderText = "اسم المنتج";
            metroGrid1.Columns[2].Width = 300;
            metroGrid1.Columns[3].HeaderText = "المجموع";
            metroGrid1.Columns[4].HeaderText = "الاجمالي";
            metroGrid1.Columns[5].Visible = false;
            metroGrid1.Columns[6].Visible = false;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Prodact i = new Prodact();
            i.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Debit_account i = new Debit_account();
            i.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroTextBox9.Text == "")
                {
                    MessageBox.Show("برجاء انشاء فاتوره", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    if (metroTextBox15.Text == "")
                    {
                        int aa = int.Parse(metroTextBox8.Text);
                        metroTextBox15.Text = aa.ToString();
                        i.update_bill(metroTextBox9.Text, metroTextBox15.Text);
                    }
                    else
                    {
                        int aa = int.Parse(metroTextBox8.Text);
                        int tt = int.Parse(metroTextBox15.Text);
                        int tot = aa + tt;
                        metroTextBox15.Text = tot.ToString();
                        i.update_bill(metroTextBox9.Text, metroTextBox15.Text);
                    }
                    metroTextBox5.Clear();
                    string date = metroDateTime1.Value.Year.ToString() + "/" + metroDateTime1.Value.Month.ToString() + "/" + metroDateTime1.Value.Day.ToString();
                    i.insert("bill_detitles", new string[] { "id_prodact", "name_prodact", "total", "total_price", "data_create", "id_bill" }, new string[] { metroTextBox4.Text, metroTextBox3.Text, metroTextBox6.Text, metroTextBox8.Text, date, metroTextBox9.Text });
                    metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroTextBox9.Text });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR 5", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            try
            {
           
   
                string date = metroDateTime1.Value.Year.ToString() + "/" + metroDateTime1.Value.Month.ToString() + "/" + metroDateTime1.Value.Day.ToString();
                k.insert("bill", new string[] { "data_create", "total_price", "id_user", "year", "month", "day" }, new string[] { date, "0", id_user, metroDateTime1.Value.Year.ToString(), metroDateTime1.Value.Month.ToString(), metroDateTime1.Value.Day.ToString() });
                
                MySqlDataReader y = k.max_row();
                if (y.HasRows)
                {
                    y.Read();
                    metroTextBox9.Text = y[0].ToString();
                    k.close();
                    if (metroTextBox4.Text != "")
                    {
                        metroTextBox5.Clear();
                        i.update_prodact(metroTextBox4.Text, metroTextBox11.Text);
                        if(metroTextBox15.Text == ""){
                            int aa = int.Parse(metroTextBox8.Text);
                            metroTextBox15.Text = aa.ToString();
                            i.update_bill(metroTextBox9.Text, metroTextBox15.Text);
                        }
                        else
                        {
                            int aa = int.Parse(metroTextBox8.Text);
                            int tt = int.Parse(metroTextBox15.Text);
                            int tot = aa + tt;
                            metroTextBox15.Text = tot.ToString();
                            i.update_bill(metroTextBox9.Text, metroTextBox15.Text);
                        }
                        i.insert("bill_detitles", new string[] { "id_prodact", "name_prodact", "total", "total_price", "data_create", "id_bill" }, new string[] { metroTextBox4.Text, metroTextBox3.Text, metroTextBox6.Text, metroTextBox8.Text, date, metroTextBox9.Text });
                        metroTextBox4.Clear();
                        metroTextBox3.Clear();
                        metroTextBox6.Clear();
                        metroTextBox8.Clear();
                        metroTextBox5.Clear();
                        metroTextBox11.Clear();
                        metroTextBox7.Clear();
                        metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroTextBox9.Text });


                    }
                }
                else
                {
                    metroTextBox9.Text = "0";
                }
               
            
            }
            catch (Exception ex)
            {
                k.close();
                MessageBox.Show(ex.Message, "ERROR 4", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
              
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Rep_Bill k = new Rep_Bill();
            k.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroTextBox12.Text = Clipboard.GetText();
            metroTextBox9.Text = Clipboard.GetText();
        }



        private void metroTextBox5_TextChanged(object sender, EventArgs e)
        {
    
            try
            {
             
                string date = metroDateTime1.Value.Year.ToString() + "/" + metroDateTime1.Value.Month.ToString() + "/" + metroDateTime1.Value.Day.ToString();
                metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroTextBox9.Text });

                MySqlDataReader reader = i.select_prodact(metroTextBox5.Text);

                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader["id"].ToString() == metroTextBox4.Text)
                    {
                        int a1 = int.Parse(metroTextBox6.Text);
                        int total = a1 + 1;
                        metroTextBox6.Text = total.ToString();
                        metroTextBox5.Clear();
                    }
                    else
                    {
                        if (metroTextBox4.Text == "")
                        {
                            metroTextBox4.Text = reader["id"].ToString();
                            metroTextBox3.Text = reader["name"].ToString();
                            metroTextBox11.Text = reader["total"].ToString();
                            metroTextBox7.Text = reader["price"].ToString();
                            metroTextBox6.Text = "1";
                            metroTextBox5.Clear();
                        }
                        else
                        {
                            if (metroTextBox9.Text == "")
                            {
                                MessageBox.Show("برجاء انشاء فاتوره", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                            }
                            else
                            {
                                k.close();
                                i.update_prodact(metroTextBox4.Text, metroTextBox11.Text);
                                int aa = int.Parse(metroTextBox8.Text);
                                int tt = int.Parse(metroTextBox15.Text);
                                int tot = aa + tt;
                                metroTextBox15.Text = tot.ToString();
                                i.update_bill(metroTextBox9.Text, metroTextBox15.Text); 
                                i.insert("bill_detitles", new string[] { "id_prodact", "name_prodact", "total", "total_price", "data_create", "id_bill" }, new string[] { metroTextBox4.Text, metroTextBox3.Text, metroTextBox6.Text, metroTextBox8.Text, date, metroTextBox9.Text });
                                metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroTextBox9.Text });
                                MySqlDataReader reader1 = i.select_prodact(metroTextBox5.Text);
                                reader1.Read();
                                metroTextBox4.Text = reader1["id"].ToString();
                                metroTextBox3.Text = reader1["name"].ToString();
                                metroTextBox11.Text = reader1["total"].ToString();
                                metroTextBox7.Text = reader1["price"].ToString();
                                metroTextBox6.Text = "1";
                                metroTextBox5.Clear();
                            }

                        }
                 
                    }
                    k.close();
                    
                }
                    
                else
                {
                   // MessageBox.Show("لايوجد منتج بهذا الرقم ", "ERROR 3", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    k.close();
                }
                     
            }
                     
            catch (Exception ex)
            {
                k.close();
               // MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
                      
        }

        private void metroTextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (metroTextBox6.Text == "" || metroTextBox6.Text == "0")
                {
                    metroTextBox6.Text = "0";
                }
                else
                {
                    if (int.Parse(metroTextBox11.Text) < int.Parse(metroTextBox6.Text))
                    {
                        MessageBox.Show("الكمية المكتوبة اكبر من الموجده بداخل", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                    else
                    {

                        if (metroTextBox6.Text == "")
                        {

                            int a = int.Parse(metroTextBox11.Text);
                            int t1 = a - 1;
                            metroTextBox11.Text = t1.ToString();
                            metroTextBox8.Text = metroTextBox7.Text;
                        }
                        else
                        {
                            int a1 = int.Parse(metroTextBox6.Text);
                            int a2 = int.Parse(metroTextBox7.Text);
                            int total = a1 * a2;
                            int a = int.Parse(metroTextBox11.Text);
                            int t1 = a - 1;
                            metroTextBox11.Text = t1.ToString();
                            metroTextBox8.Text = total.ToString();
                        }
                    }
                }
                    
            }
            catch (Exception ex)
            {
                k.close();
                MessageBox.Show(ex.Message, "ERROR 1", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
         

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroLabel1.Text = DateTime.Now.ToLongTimeString();
        }

        private void metroTextBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Debit_All tt = new Debit_All();
                tt.Show();
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            metroTextBox13.Text = Clipboard.GetText();
        }

        private void metroTextBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metroGrid1.DataSource = i.select_1("bill_detitles", new string[] { "id_bill", metroTextBox9.Text });
                MySqlDataReader reader = i.select_bill_total(metroTextBox9.Text);
                reader.Read();
                metroTextBox15.Text = reader["total_price"].ToString();
                i.close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox13.Text == "")
            {
                if (metroTextBox10.Text == "")
                {
                    MessageBox.Show("املاء البيانات", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MySqlDataReader reader = i.select_bill_total_debit(metroTextBox13.Text,metroTextBox10.Text);
                if (reader.HasRows)
                {
                    MessageBox.Show("هذا الفاتوره مسجلة مسبقاء", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    i.close();
                    metroTextBox13.Clear();
                    metroTextBox10.Clear();
                }
                else
                {
                    i.close();
                    i.insert("bill_debit", new string[] { "id_user", "id_bill_d","total" }, new string[] {metroTextBox13.Text,metroTextBox10.Text,metroTextBox15.Text});
                    MessageBox.Show("تم التسجيل", "info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    metroTextBox13.Clear();
                    metroTextBox10.Clear();
                }
            }
        }

        private void metroTextBox4_DoubleClick(object sender, EventArgs e)
        {
            SerchProdact o = new SerchProdact();
            o.Show();
        }

        private void metroTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            try
            {
             
                metroTextBox4.Text = Clipboard.GetText();
                MySqlDataReader reader = i.select_prodact_by_id(metroTextBox4.Text);
                if (reader.HasRows)
                {
                    reader.Read();
                    metroTextBox3.Text = reader["name"].ToString();
                    metroTextBox11.Text = reader["total"].ToString();
                    metroTextBox7.Text = reader["price"].ToString();
                    metroTextBox5.Text = reader["Code"].ToString();
                    metroTextBox6.Text = "0";
                    i.close();
                }
            
            }
            catch (Exception ex)
            {
                i.close();
                MessageBox.Show(ex.Message, "ERROR 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (Rank == "True")
            {
                prfites o = new prfites();
                o.Show();
            }
            else 
            {
                MessageBox.Show("غير مسرح لك با دخول", "ERROR 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (Rank == "True")
            {
                admin o = new admin();
                o.Show();
            }
            else
            {
                MessageBox.Show("غير مسرح لك با دخول", "ERROR 2", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }


    }
}
