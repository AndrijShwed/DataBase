using MySqlConnector;

namespace DataBase.Repositories
{
    public class PersonRepository
    {
        public Person GetById(int id)
        {
            Person row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string sql = "SELECT p.people_id, p.lastname, p.name, p.surname, p.sex, p.date_of_birth, v.name AS village, s.name AS street," +
                        " p.numb_of_house, p.passport, p.id_kod, p.phone_numb, p.status, p.registr, p.m_date, p.mil_ID, p.description" +
                        " FROM people p" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE p.people_id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.getConnection());
            cmd.Parameters.AddWithValue("@id", id);
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = Person.ReadOne(_reader);
            }
            _reader.Close();
            conn.closeConnection();
            return row;

        }
    }
}
