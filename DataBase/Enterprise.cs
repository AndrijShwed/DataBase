using MySqlConnector;

namespace DataBase
{
    public class Enterprise
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string head {  get; set; }
        public int employeesCount { get; set; }


        public Enterprise() { }

        public static Enterprise ReadOne(MySqlDataReader reader)
        {
            return new Enterprise
            {
                id = reader.GetInt32(reader.GetOrdinal("id")),
                name = reader["name"] as string,
                village = reader["village"] as string,
                street = reader["street"] as string,
                number = reader["number"] as string,
                head = reader["head"] as string,
                employeesCount = reader.GetInt32(reader.GetOrdinal("employeesCount"))
            };
        }
    }
}
