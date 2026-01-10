using DataBase.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            con.openConnection();

            MySqlCommand cmd = new MySqlCommand(@"
            SELECT vs.id AS villagestreetId,
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
            ORDER BY v.name, s.name;", con.getConnection());

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime? renameDate = null;

                int renameDateOrdinal = reader.GetOrdinal("renameDate");
                if (!reader.IsDBNull(renameDateOrdinal))
                {
                    renameDate = reader.GetDateTime(renameDateOrdinal).Date; // беремо тільки дату
                }

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

            con.closeConnection();

            return list;

        }
    }
}
