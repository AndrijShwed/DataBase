using MySqlConnector;
using System;

namespace DataBase.Services
{
    public class AddressIds
    {
        public int villageId {  get; set; }
        public int streetId { get; set; }

        public AddressIds GetAddressByPeopleId(int peopleId)
        {
            using (ConnectionClass conn = new ConnectionClass())
            using (MySqlCommand cmd = new MySqlCommand(@"
                SELECT vs.villageId, vs.streetId 
                FROM people p
                JOIN villagestreet vs ON p.villagestreetId = vs.id
                WHERE p.people_id = @id", conn.getConnection()))
            {
                cmd.Parameters.AddWithValue("@id", peopleId);
                conn.openConnection();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("Людину не знайдено");

                    return new AddressIds
                    {
                        villageId = reader.GetInt32("villageId"),
                        streetId = reader.GetInt32("streetId")
                    };
                }
            }
        }

        public int GetVillageStreetIdByPeopleId(int peopleId)
        {
            int villagestreetId;
            using (ConnectionClass conn = new ConnectionClass())
            using (MySqlCommand cmd = new MySqlCommand(@"
                SELECT vs.id
                FROM people p
                JOIN villagestreet vs ON p.villagestreetId = vs.id
                WHERE p.people_id = @id", conn.getConnection()))
            {
                cmd.Parameters.AddWithValue("@id", peopleId);
                conn.openConnection();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("Людину не знайдено");

                    return villagestreetId = reader.GetInt32("id");
                }
            }
        }

        public AddressIds GetAddressByIdHouse(int houseId)
        {
            using (ConnectionClass conn = new ConnectionClass())
            using (MySqlCommand cmd = new MySqlCommand(@"
                SELECT vs.villageId, vs.streetId 
                FROM houses h
                JOIN villagestreet vs ON h.villagestreetId = vs.id
                WHERE h.idhouses = @id", conn.getConnection()))
            {
                cmd.Parameters.AddWithValue("@id", houseId);
                conn.openConnection();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new Exception("Людину не знайдено");

                    return new AddressIds
                    {
                        villageId = reader.GetInt32("villageId"),
                        streetId = reader.GetInt32("streetId")
                    };
                }
            }
        }
    }


} 
