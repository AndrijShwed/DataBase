using MySqlConnector;

namespace DataBase
{
    public class House
    {
        public int idhouses { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string numb_of_house { get; set; }
        public double livingArea { get; set; }
        public double totalArea { get; set; }
        public int total_of_rooms { get; set; }

        public House() { }
        public static House ReadOne(MySqlDataReader reader)
        {
            return new House
            {
                idhouses = reader.GetInt32(reader.GetOrdinal("idhouses")),
                village = reader["village"] as string,
                street = reader["street"] as string,
                numb_of_house = reader["numb_of_house"] as string,
                lastname = reader["lastname"] as string,
                name = reader["name"] as string,
                surname = reader["surname"] as string,
                totalArea = reader.GetDouble(reader.GetOrdinal("totalArea")),
                livingArea = reader.GetDouble(reader.GetOrdinal("livingArea")),
                total_of_rooms = reader.GetInt32(reader.GetOrdinal("total_of_rooms"))
            };
        }

        

    }
}
