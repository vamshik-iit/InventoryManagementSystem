using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace InventoryManagementDB
{
    public class DBClass
    {

        


        public Boolean InsertData(string query)
        {
            try
            {
                MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=@2023;database=InventoryManagementDB;");
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable FetchData(string query)
        {
            DataTable dt = new DataTable();
            try
            {

               
                MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=@2023;database=InventoryManagementDB;");
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();
                dt.Rows.Clear();
                dt.Columns.Clear();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
              
               
                return dt;

            }
            catch (Exception ex)
            {

            }
            return dt;
        }



        public int GetMaxIDCount(string table, string col)
        {
            try
            {
                string fdata = "select max(" + col + ") + 1 as MaxVal  from " + table + " ";
                int res = 1;
                MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=@2023;database=InventoryManagementDB;");
                MySqlCommand cmd = new MySqlCommand(fdata, con);

                con.Open();
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                dt.Columns.Clear();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                con.Close();
                res = Int32.Parse(dt.Rows[0]["MaxVal"].ToString());
                return res;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }





   
    }
}