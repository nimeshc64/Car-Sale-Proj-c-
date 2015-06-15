using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Carsaleproject
{
    class dBConnection
    {
        public MySqlConnection conn;
        public  MySqlCommand cmd;

        public  dBConnection() {

            string constring = "server=localhost;password=;user id=root;database=car";
            conn = new MySqlConnection(constring);
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }

        
    }
}
