using MySqlConnector;
using System;
using System.Collections.Generic;

namespace DataBase.Repositories
{
    public class VillageRepository
    {
        public VillageRepository() { }

        private readonly ConnectionClass _connection;

        public VillageRepository(ConnectionClass connection)
        {
            _connection = connection;
        }
        public  List<Village>GetAllVillages()
        {
            var dataVillage = new List<Village>();

            using (var conn = _connection.getConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT id, name FROM villages ORDER BY name", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataVillage.Add(new Village
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
            }
            
            return dataVillage;
        }

        public int GetOrCreate(string name, ConnectionClass con)
        {

            var cmd = "SELECT id FROM villages WHERE name = @name";
            MySqlCommand command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            var result = command.ExecuteScalar();

            if (result != null)
                return Convert.ToInt32(result);


            cmd = @"INSERT INTO villages (name) VALUES (@name); SELECT LAST_INSERT_ID()";
            command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(command.ExecuteScalar());

        }

        
    }
}
