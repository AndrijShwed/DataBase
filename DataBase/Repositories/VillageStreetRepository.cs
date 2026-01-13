using MySqlConnector;
using System;
using System.Windows.Forms;

namespace DataBase.Repositories
{
    public class VillageStreetRepository
    {
        public void AddIfNotExists(int villageId, int streetId, ConnectionClass con)
        {
            try
            {
                con.openConnection();

                string cmd = @"SELECT COUNT(*) FROM villagestreet WHERE 
                            villageId = @villageId AND streetId = @streetId AND IsActive = 1";
                using (MySqlCommand command = new MySqlCommand(cmd, con.getConnection()))
                {
                    command.Parameters.AddWithValue("@villageId", villageId);
                    command.Parameters.AddWithValue("@streetId", streetId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                        return;
                }

                cmd = @"INSERT INTO villagestreet (villageId, streetId, isActive, renameDate) VALUES (@villageId, @streetId, 1, NULL)";
                using (MySqlCommand command = new MySqlCommand(cmd, con.getConnection()))
                {
                    command.Parameters.AddWithValue("@villageId", villageId);
                    command.Parameters.AddWithValue("@streetId", streetId);
                    command.ExecuteNonQuery();
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
            finally
            {
                con.closeConnection(); // ⚠️ ЗАВЖДИ закриється
            }
        }
    }
}
