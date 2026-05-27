using MySqlConnector;

namespace DataBase.Repositories
{
    public class EnterpriseRepository
    {
        public static Enterprise GetValueFromDB(int id)
        {
            Enterprise row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string sql = "SELECT e.id, e.name, e.owner, e.employeesnumber, e.housenumber, " +
                        "v.name AS village, s.name AS street" +
                        " FROM enterprises e" +
                        " JOIN villagestreet vs ON e.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE e.id = " + id;

            MySqlCommand cmd = new MySqlCommand(sql, conn.getConnection());
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = Enterprise.ReadOne(_reader);
            }
            return row;
        }
    }
}
