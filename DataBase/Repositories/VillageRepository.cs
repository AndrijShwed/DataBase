using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            try
            {
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
            return dataVillage;
        }

        public int GetOrCreate(string name, ConnectionClass con)
        {
            try
            {
                con.openConnection();

                using (var tran = con.getConnection().BeginTransaction())
                {
                    using (var cmd = new MySqlCommand(
                        "SELECT id FROM villages WHERE name = @name",
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
                        @"INSERT INTO villages (name) VALUES (@name);
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
