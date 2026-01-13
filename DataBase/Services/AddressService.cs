using DataBase.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataBase.ПочатокРоботи;

namespace DataBase.Services
{
    public class AddressService
    {
        public void AddStreetToVillage(string VillageName, string StreetName)
        {
            ConnectionClass con = new ConnectionClass();
            con.openConnection();
                
            try
            {
                var villageRepo = new VillageRepository();
                var streetRepo = new StreetRepository();
                var linkRepo = new VillageStreetRepository();

                int villageId = villageRepo.GetOrCreate(VillageName, con);
                int streetId = streetRepo.GetOrCreate(StreetName, con);

                linkRepo.AddIfNotExists(villageId, streetId, con);

            }
            catch
            {
                throw;
            }
            con.closeConnection();
        }

        public List<VillageStreetInfo> GetAllVillagesStreets()
        {
            var list = new List<VillageStreetInfo>();
            ConnectionClass con = new ConnectionClass();

            try
            {
                con.openConnection();

                using (var cmd = new MySqlCommand(
                        @"SELECT vs.id AS villagestreetId,
                                v.id AS villageId,
                                v.name AS villageName,
                                s.id AS streetId,
                                s.name AS streetName,
                                prev.oldStreetName,
                                prev.renameDate
                        FROM villagestreet vs
                        JOIN villages v ON v.id = vs.villageId
                        JOIN streets s ON s.id = vs.streetId

                        LEFT JOIN villagestreet prev
                            ON prev.Id = vs.previousvillagestreetId
                
                        WHERE vs.IsActive = 1
                        ORDER BY v.name, s.name;", con.getConnection()))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        int renameDateOrdinal = reader.GetOrdinal("renameDate");
                        int oldSAtreetNameOrdinal = reader.GetOrdinal("oldStreetName");

                        while (reader.Read())
                        {
                            DateTime? renameDate = null;
                            if (!reader.IsDBNull(renameDateOrdinal))
                                renameDate = reader.GetDateTime(renameDateOrdinal).Date;

                            list.Add(new VillageStreetInfo
                            {
                                VillagestreetId = reader.GetInt32("villagestreetId"),
                                VillageId = reader.GetInt32("villageId"),
                                VillageName = reader.GetString("villageName"),
                                StreetId = reader.GetInt32("streetId"),
                                StreetName = reader.GetString("streetName"),
                                OldStreetName = reader.IsDBNull(reader.GetOrdinal("oldStreetName"))
                                                    ? null : reader.GetString("oldStreetName"),
                                //IsActive = reader.GetBoolean("isActive"),
                                RenameDate = renameDate
                            });
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
                    MessageBoxIcon.Error);
            }
            finally
            {
                con.closeConnection();
            }

            return list;
        }
    }
}
