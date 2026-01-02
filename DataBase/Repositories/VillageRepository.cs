using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class VillageRepository
    {
        public int GetOrCreate(string name, ConnectionClass con)
        {
            con.openConnection();

            string cmd = "SELECT id FROM villages WHERE name = @name";
            MySqlCommand command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            var result = command.ExecuteScalar();

            if (result != null)
                return Convert.ToInt32(result);


            cmd = @"INSERT INTO villages (name) VALUES (@name); SELECT LAST_INSERT_ID()";
            command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(command.ExecuteScalar());

            con.closeConnection();
        }
    }
}
