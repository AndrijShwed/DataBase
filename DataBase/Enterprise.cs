using MySqlConnector;

namespace DataBase
{
    public class Enterprise
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string owner {  get; set; }
        public int employeesNumber { get; set; }


        public Enterprise() { }


        public static Enterprise ReadOne(MySqlDataReader reader)
        {
            return new Enterprise
            {
                id = reader.GetInt32(reader.GetOrdinal("id")),
                name = reader["name"] as string,
                owner = reader["owner"] as string,
                street = reader["street"] as string,
                village = reader["village"] as string,
                houseNumber = reader["housenumber"] as string,
                employeesNumber = reader.GetInt32(reader.GetOrdinal("employeesnumber"))
            };
        }
    }
}
