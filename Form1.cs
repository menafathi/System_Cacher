using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
namespace systemCacher
{
    public partial class Form1 : MetroFramework .Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortTimeString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Class1 o = new Class1();
            try
            {
                MySqlDataReader a = o.select_data(metroTextBox2.Text, metroTextBox1.Text);
                if (a.HasRows)
                {
                    index l = new index();
                    while (a.Read())
                    {
                        l.id_user = a["id"].ToString();
                        l.Rank = a["Rank"].ToString();
                        l.username = a["username"].ToString();
                    }
                    o.close();
                    l.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("خطاي في البيانات", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
                o.close();
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
            }

        }
    }
}
