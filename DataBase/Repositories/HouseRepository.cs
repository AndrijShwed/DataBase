using MySqlConnector;

namespace DataBase.Repositories
{
    public class HouseRepository
    {
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
    }
}
