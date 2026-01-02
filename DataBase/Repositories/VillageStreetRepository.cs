using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class VillageStreetRepository
    {
        public void AddIfNotExists(int villageId, int streetId, ConnectionClass con)
        {
            con.openConnection();

            string cmd = @"SELECT COUNT(*) FROM villagestreet WHERE villageId = @villageId AND streetId = @streetId";
            MySqlCommand command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@villageId", villageId);
            command.Parameters.AddWithValue("@streetId", streetId);

            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count > 0) 
                return;


            cmd = @"INSERT INTO villagestreet (villageId, streetId, isActive, renameDate) VALUES (@villageId, @streetId, 1, NULL)";
            command = new MySqlCommand(cmd, con.getConnection());

            command.Parameters.AddWithValue("@villageId", villageId);
            command.Parameters.AddWithValue("@streetId", streetId);
            command.ExecuteNonQuery();
            
            con.closeConnection();
        }
    }
}
