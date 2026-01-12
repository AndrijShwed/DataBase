using MySqlConnector;
using System;
using System.Collections.Generic;

namespace DataBase.Repositories
{
    public class StreetRepository
    {
        public StreetRepository() { }

        private readonly ConnectionClass _connection;

        public StreetRepository(ConnectionClass connection)
        {
            _connection = connection; 
        }

        public List<Street> GetStreetsInVillge(int villageId)
        {
            var dataStreet = new List<Street>();

            using (var conn = _connection.getConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT s.id, s.name FROM villagestreet vs" +
                    " JOIN streets s ON s.id = vs.streetId" +
                    " WHERE vs.villageId = @villageId " +
                    "AND vs.isActive = 1 ORDER BY s.name", conn))
                {
                    cmd.Parameters.AddWithValue("@villageId", villageId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataStreet.Add(new Street
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
                                
            }
            return dataStreet;
        }

        public int GetOrCreate(string name, ConnectionClass con)
        {
            con.openConnection();

            string cmd = "SELECT id FROM streets WHERE name = @name";
            MySqlCommand command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            var result = command.ExecuteScalar();

            if (result != null) 
               return Convert.ToInt32(result);
            

            cmd = @"INSERT INTO streets (name) VALUES (@name); SELECT LAST_INSERT_ID()";
            command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@name", name);
            return Convert.ToInt32(command.ExecuteScalar());

        }
    }
}
