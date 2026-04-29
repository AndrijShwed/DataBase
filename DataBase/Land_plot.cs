
using MySqlConnector;

namespace DataBase
{
    public class Land_plot
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string village { get; set; }
        public string street { get; set; }
        public string houseNummb { get; set; }
        public string fieldNumber { get; set; }
        public string plotType { get; set; }
        public string plotNumber { get; set; }
        public decimal plotArea { get; set; }
        public string cadastr { get; set; }
        public string tenant { get; set; }
        public string url { get; set; }

        public Land_plot() { }

        public static Land_plot ReadOne(MySqlDataReader reader)
        {
            return new Land_plot
            {
                id = reader.GetInt32(reader.GetOrdinal("id")),
                fullName = reader["fullname"] as string,
                village = reader["village"] as string,
                street = reader["street"] as string,
                houseNummb = reader["housenumb"] as string,
                fieldNumber = reader["fieldnumber"] as string,
                plotType = reader["plottype"] as string,
                plotNumber = reader["plotnumber"] as string,
                plotArea = reader.GetDecimal(reader.GetOrdinal("plotarea")),
                cadastr = reader["cadastr"] as string,
                tenant = reader["tenant"] as string,
                url = reader["url"] as string
            };
        }

    }
}
