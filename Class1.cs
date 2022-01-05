using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace systemCacher
{
    class Class1
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["con"]);

        public MySqlDataReader  select_data(string user, string pass) 
        {
            con.Open();
            MySqlCommand  cmd = new MySqlCommand("select * from users where username=@username and password=@password ", con);
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            return cmd.ExecuteReader();
        }

        public string close()
        {
            con.Close();
            return "";
        }

        public string insert_Type(string name_type)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into type(type)values(@type)", con);
            cmd.Parameters.AddWithValue("@type", name_type);
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }

        public DataTable select_type(){
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from type ", con);
            DataSet o = new DataSet();
            cmd.Fill(o, "t");
            con.Close();
            return o.Tables["t"];
        }

        public string send_Prodact(string total, string name, string price, string code, string id_type)
        {
            if (total == "" || name == "" || price == "" || code == "" || id_type == "")
            {
                return "املاء البيانات المنتج";
            }
            else 
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into prodact(total,name,price,Code,id_type)values(@total,@name,@price,@Code,@id_type)", con);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@id_type", id_type);
                cmd.ExecuteNonQuery();
                con.Close();
                return "";
            }
        }

        public DataTable view_prodact(string id)
        {
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from prodact where id_type=@id_type ", con);
            cmd.SelectCommand.Parameters.AddWithValue("@id_type", id);
            DataSet o = new DataSet();
            cmd.Fill(o, "WW");
            con.Close();
            return o.Tables["WW"];
        }

        public string update_Prodact(string id,string total, string name, string price, string code, string id_type)
        {
            if (total == "" || name == "" || price == "" || code == "" || id_type == "")
            {
                return "املاء البيانات المنتج";
            }
            else
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update prodact set total=@total , name=@name , price=@price , code=@code , id_type=@id_type where id=@id ", con);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@Code", code);
                cmd.Parameters.AddWithValue("@id_type", id_type);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                return "";
            }
        }
    }
}
