using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
namespace systemCacher
{
    class Seller
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["con"]);

        public string insert(string table, string[] col, string[] val)
        {
            string __col = String.Join(",", col);
            string __val = String.Join("','", val);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string sql = "insert into " + table + "(" + __col + ")values('" + __val + "')";
            MySqlCommand cmd = new MySqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }

        public string close()
        {
            con.Close();
            return "";
        }

        public DataTable select_1(string table, string[] val)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from "+table+" where "+val[0]+"=@val", con);
            cmd.SelectCommand.Parameters.AddWithValue("@val", val[1]);
            DataSet o = new DataSet();
            cmd.Fill(o, "k");
            con.Close();
            return o.Tables["k"];
        }

        public DataTable select(string table)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table, con);
            DataSet o = new DataSet();
            cmd.Fill(o, "k");
            con.Close();
            return o.Tables["k"];
        }


        public MySqlDataReader select_prodact(string val)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from prodact where Code=@val", con);
            cmd.Parameters.AddWithValue("@val", val);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader select_prodact_by_id(string val)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from prodact where id=@id", con);
            cmd.Parameters.AddWithValue("@id", val);
            return cmd.ExecuteReader();
        }

        public DataTable serch_prodact(string val, string serch)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from prodact where id_type=@id_type and name like @name ", con);
            cmd.SelectCommand.Parameters.AddWithValue("@id_type", val);
            cmd.SelectCommand.Parameters.AddWithValue("@name", "%" + serch + "%");
            DataSet o = new DataSet();
            cmd.Fill(o, "k");
            con.Close();
            return o.Tables["k"];
        }

        public MySqlDataReader select_bill_total(string val)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from bill where id=@id", con);
            cmd.Parameters.AddWithValue("@id", val);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader select_bill_total_debit(string val,string val1)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from bill_debit where id_user=@id_user and id_bill_d=@id_bill_d", con);
            cmd.Parameters.AddWithValue("@id_user", val);
            cmd.Parameters.AddWithValue("@id_bill_d", val1);
            return cmd.ExecuteReader();
        }

        public string update_prodact(string id, string de)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update prodact set total=@total  where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@total", de);
            cmd.ExecuteNonQuery();
            con.Close();
            return "تمت العملية بنجاح";
        }

        public string update_users(string username, string password, string Rank,string id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update users set username=@username , password=@password , Rank=@Rank where id=@id", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@Rank", Rank);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Close();
            return "تمت العملية بنجاح";
        }

        public string update_bill(string id, string total_price)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update bill set total_price=@total_price where id=@id", con);
            cmd.Parameters.AddWithValue("@total_price", total_price);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            return "تمت العملية بنجاح";
        }

        public DataTable select_DataTable_3_item(string table, string[] columns, string[] value)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table + " where " + columns[0] + "=@column0 and " + columns[1] + "=@column1 and " + columns[2] + "=@column2", con);
            cmd.SelectCommand.Parameters.AddWithValue("@column0", value[0]);
            cmd.SelectCommand.Parameters.AddWithValue("@column1", value[1]);
            cmd.SelectCommand.Parameters.AddWithValue("@column2", value[2]);
            DataSet k = new DataSet();
            cmd.Fill(k, "a");
            con.Close();
            return k.Tables["a"];
        }
        public DataTable select_DataTable_2_item(string table, string[] columns, string[] value)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table + " where " + columns[0] + "=@column0 and " + columns[1] + "=@column1", con);
            cmd.SelectCommand.Parameters.AddWithValue("@column0", value[0]);
            cmd.SelectCommand.Parameters.AddWithValue("@column1", value[1]);
            DataSet k = new DataSet();
            cmd.Fill(k, "a");
            con.Close();
            return k.Tables["a"];
        }

        public MySqlDataReader max_row()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(id) from bill", con);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader calck_bill()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total) from bill_debit", con);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader calck_paid_accounts()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total) from paid_accounts", con);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader select_1_items(string table, string[] columns)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total_price) from " + table + " where " + columns[0] + "=@column1", con);
            cmd.Parameters.AddWithValue("@column1", columns[1]);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader select_3_items(string table, string[] columns)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total_price) from " + table + " where " + columns[0] + "=@column1 and " + columns[2] + "=@column2 and " + columns[4] + "=@column3", con);
            cmd.Parameters.AddWithValue("@column1", columns[1]);
            cmd.Parameters.AddWithValue("@column2", columns[3]);
            cmd.Parameters.AddWithValue("@column3", columns[5]);
            return cmd.ExecuteReader();
        }

        public MySqlDataReader select_2_items(string table, string[] columns)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select sum(total_price) from " + table + " where " + columns[0] + "=@column1 and " + columns[2] + "=@column2", con);
            cmd.Parameters.AddWithValue("@column1", columns[1]);
            cmd.Parameters.AddWithValue("@column2", columns[3]);
            return cmd.ExecuteReader();
        }



        public DataTable select_DataTable_1_item(string table, string[] columns, string[] value)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table + " where " + columns[0] + "=@column0", con);
            cmd.SelectCommand.Parameters.AddWithValue("@column0", value[0]);
            DataSet k = new DataSet();
            cmd.Fill(k, "a");
            con.Close();
            return k.Tables["a"];
        }


       
    }
}
