using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class EnterpriseRepository
    {
        public Enterprise GetById(int id)
        {
            Enterprise row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string sql = "SELECT e.id, e.name, v.name AS village, s.name AS street," +
                        " e.number, e.head, e.employeesCount" +
                        " FROM enterprise e" +
                        " JOIN villagestreet vs ON p.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                        " WHERE e.id = @id";

            MySqlCommand cmd = new MySqlCommand(sql, conn.getConnection());
            cmd.Parameters.AddWithValue("@id", id);
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = Enterprise.ReadOne(_reader);
            }
            _reader.Close();
            conn.closeConnection();
            return row;

        }
    }
}
