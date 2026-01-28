using MySqlConnector;

namespace DataBase
{
    internal class RowOfDataH
    {
        public object idhouses { get; set; }
        public object lastname { get; set; }
        public object name { get; set; }
        public object surname { get; set; }
        public object village { get; set; }
        public object street { get; set; }
        public object numb_of_house { get; set; }
        public object livingArea { get; set; }
        public object totalArea { get; set; }
        public object total_of_rooms { get; set; }

        public RowOfDataH() { }
        public RowOfDataH(object _idhouses, object _НаселенийПункт, object _Вулиця, object _НомерБудинку, object _Прізвище, object _Ім_я, object _Побатькові,
            object _ЗагальнаПлоща, object _ЖитловаПлоща, object _КількістьКімнат)
        {
            idhouses = _idhouses;
            village = _НаселенийПункт;
            street = _Вулиця;
            numb_of_house = _НомерБудинку;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            totalArea = _ЗагальнаПлоща;
            livingArea = _ЖитловаПлоща;
            total_of_rooms = _КількістьКімнат;
        }

        public void DataChange(object _idhouses, object _НаселенийПункт, object _Вулиця, object _НомерБудинку, object _Прізвище, object _Ім_я, object _Побатькові,
            object _ЗагальнаПлоща, object _ЖитловаПлоща, object _КількістьКімнат)
        {
            idhouses = _idhouses;
            village = _НаселенийПункт;
            street = _Вулиця;
            numb_of_house = _НомерБудинку;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            totalArea = _ЗагальнаПлоща;
            livingArea = _ЖитловаПлоща;
            total_of_rooms = _КількістьКімнат;
        }

        public RowOfDataH GetValueFromDBHouse(int id)
        {
            RowOfDataH row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT h.idhouses, v.name AS village, s.name AS street, h.lastname, h.name, h.surname," +
                " h.numb_of_house, h.totalArea, h.livingArea, h.total_of_rooms" +
                " FROM houses h " +
                " JOIN villagestreet vs ON h.villagestreetId = vs.id" +
                        " JOIN villages v ON vs.villageId = v.id" +
                        " JOIN streets s ON vs.streetId = s.id" +
                " WHERE h.idhouses = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@id", id);
            _reader = cmd.ExecuteReader();

            if (_reader.Read())
            {
                row = new RowOfDataH(_reader["idhouses"], _reader["village"], _reader["street"],
                       _reader["numb_of_house"], _reader["lastname"], _reader["name"], _reader["surname"],
                       _reader["totalArea"], _reader["livingArea"], _reader["total_of_rooms"]);
            }
            return row;
        }

    }
}
