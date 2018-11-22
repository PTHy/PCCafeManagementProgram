using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DatabaseManager
    {
        private MySqlConnection scon = null;
        private MySqlCommand scom = null;
        private MySqlDataAdapter adpt = null;

        const string databaseConfig = "server=localhost;user id=root;password=password;persistsecurityinfo=True;port=3306;database=restaurant;SslMode=none;CharSet=utf8";

        private bool DatabaseConnecting()
        {
            try
            {
                scon = new MySqlConnection(databaseConfig);
                scon.Open();
                scom = new MySqlCommand();
                scom.Connection = scon;
                return true;
            }
            catch (Exception error)
            {
                return false;
            }

            return false;
        }

        private bool ConnectionCheck()
        {
            if (scom == null)
              return DatabaseConnecting();

            return true;
        }

        public long Insert(String query)
        {
            if (ConnectionCheck())
            {
                try
                {
                    scom.CommandText = query;
                    scom.ExecuteNonQuery();

                    return scom.LastInsertedId;

                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return -1;
        }

        public DataSet Select(String query)
        {
            DataSet ds = new DataSet();

            if (ConnectionCheck())
            {
                try
                {
                    adpt = new MySqlDataAdapter(query, scon);
                    adpt.Fill(ds);

                    return ds;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return null;
        } 
    }
}
