using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace DataBase.Repositories
{
    public class HouseRepository
    {
        private ConnectionClass manager;

        public HouseRepository()
        {
        }

        public HouseRepository(ConnectionClass manager)
        {
            this.manager = manager;
        }

        public House GetById(int id)
        {
            House row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT h.idhouses, v.name AS village, s.name AS street, h.lastname, h.name, h.surname," +
                " h.numb_of_house, h.totalArea, h.livingArea, h.total_of_rooms" +
                " FROM houses h " +
                " JOIN villagestreet vs ON h.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                " WHERE h.idhouses = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@id", id);
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = House.ReadOne(_reader);
            }
            _reader.Close();
            conn.closeConnection();
            return row;
        }

        public async Task<IEnumerable<House>> GetByVillageStreetIdAsync(int villageId, int streetId)
        {
            ConnectionClass conn = new ConnectionClass();
            conn.openConnection();

            var houses = await conn.getConnection().QueryAsync<House>(
                @"SELECT
            h.idhouses AS IdHouses,
            h.villagestreetId AS VillageStreetId,
            h.numb_of_house,
            h.lastname AS LastName,
            h.name AS Name,
            h.surname AS Surname,
            h.totalArea AS TotalArea,
            h.livingArea AS LivingArea,
            h.total_of_rooms AS TotalOfRooms
          FROM houses h
          INNER JOIN villagestreet vs
              ON h.villagestreetId = vs.id
          WHERE vs.villageId = @villageId
            AND vs.streetId = @streetId
          ORDER BY h.numb_of_house;",
                new { villageId, streetId });

            conn.closeConnection();

            return houses;
        }
    }
}
