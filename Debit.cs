using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
namespace systemCacher
{
    class Debit
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["con"]);

        public DataTable select(string table)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table,con);
            DataSet t = new DataSet();
            cmd.Fill(t, "t");
            con.Close();
            return t.Tables["t"];
            
        }

        public DataTable select_Rep(string date)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from bill where data_create=@data_create", con);
            cmd.SelectCommand.Parameters.AddWithValue("@data_create", date);
            DataSet t = new DataSet();
            cmd.Fill(t, "rr");
            con.Close();
            return t.Tables["rr"];

        }

        public DataTable select_BIll_deb(string id_user)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from bill_debit where id_user=@id_user", con);
            cmd.SelectCommand.Parameters.AddWithValue("@id_user", id_user);
            DataSet t = new DataSet();
            cmd.Fill(t, "rr");
            con.Close();
            return t.Tables["rr"];

        }

        public string insert(string name,string[] table, string[] values)
        {
            string a1 = String.Join(",",table);
            string a2 = String.Join("','", values);
            string sql = "insert into " + name + "(" + a1 + ")values('" + a2 + "')";
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "تم التسجيل بنجاح";
        }

        public string update_account(string id,string name, string acc)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update debit_account set name=@name , account=@account where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@account", acc);
            cmd.ExecuteNonQuery();
            con.Close();
            return "تمت العملية بنجاح";
        }

        public MySqlDataReader max_row()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select max(id) from bill", con);
            return cmd.ExecuteReader(); 
        }

        public MySqlDataReader calck_debit_user(string id_user)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total) from bill_debit where id_user=@id_user", con);
            cmd.Parameters.AddWithValue("@id_user", id_user);
            return cmd.ExecuteReader();
        }

        public string close()
        {
            con.Close();
            return "";
        }

        public string delete_deb_detitles(string id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete  from bill_debit where id_user=@id_user", con);
            cmd.Parameters.AddWithValue("@id_user", id);
            cmd.ExecuteNonQuery();
            con.Close();
            return "تمت العملية بنجاح";
        }

        public DataTable select_paid_accounts(string id, string year)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from paid_accounts where id_user=@id_user and year=@year", con);
            cmd.SelectCommand.Parameters.AddWithValue("@id_user", id);
            cmd.SelectCommand.Parameters.AddWithValue("@year", year);
            DataSet t = new DataSet();
            cmd.Fill(t, "rr");
            con.Close();
            return t.Tables["rr"];

        }
    }
}
