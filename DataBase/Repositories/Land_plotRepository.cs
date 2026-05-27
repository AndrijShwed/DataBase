using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class Land_plotRepository
    {
        public static Land_plot GetValueFromDB(int id)
        {
            Land_plot row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT * FROM plot WHERE id = " + id;

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = Land_plot.ReadOne(_reader);
            }
            return row;
        }
    }
}
