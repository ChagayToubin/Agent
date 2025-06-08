using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

using MySql.Data.MySqlClient;

namespace agegent.DB
{
   
        public class MYdb
        {
        static string connectionString = "Server=localhost;Database=eagleEyeDB;User=root;Password=;Port=3306;";


        public MySqlConnection connection;
            public void Connect()
            {
                var conn = new MySqlConnection(connectionString);
                connection = conn;
                try
                {
                    conn.Open();
                    Console.WriteLine("connection is done");
               
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("eror");
                }
            }
           

        }
    }

