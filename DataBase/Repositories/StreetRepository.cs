using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public List<Street> GetStreetsInVillage(int villageId)
        {
            var dataStreet = new List<Street>();
            try 
            {
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
                                    Name = reader["name"]  == DBNull.Value ? string.Empty : reader["name"].ToString()
                                });
                            }
                        }
                    }

                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
            "Помилка роботи з базою даних:\n" + ex.Message,
            "Помилка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Невідома помилка:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return dataStreet;
        }

        public int GetOrCreate(string name, ConnectionClass con)
        {
            try
            {
                con.openConnection();

                using (var tran = con.getConnection().BeginTransaction())
                {
                    using (var cmd = new MySqlCommand(
                        "SELECT id FROM streets WHERE name = @name",
                        con.getConnection(), tran))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        var result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            tran.Commit();
                            return Convert.ToInt32(result);
                        }
                    }

                    using (var cmd = new MySqlCommand(
                        @"INSERT INTO streets (name) VALUES (@name);
                         SELECT LAST_INSERT_ID();",
                        con.getConnection(), tran))
                    {
                        cmd.Parameters.AddWithValue("@name", name);

                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        tran.Commit();
                        return newId;
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Помилка роботи з БД:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Невідома помилка:\n" + ex.Message,
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                con.closeConnection();
            }
        }
    }
}
