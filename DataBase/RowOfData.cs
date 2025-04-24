using MySqlConnector;

namespace DataBase
{
    class RowOfData
    {
        public object people_id { get; set; }
        public object lastname { get; set; }
        public object name { get; set; }
        public object surname { get; set; }
        public object sex { get; set; }
        public object date_of_birth { get; set; }
        public object village { get; set; }
        public object street { get; set; }
        public object numb_of_house { get; set; }
        public object passport { get; set; }
        public object id_kod { get; set; }
        public object phone_numb { get; set; }
        public object status { get; set; }
        public object registr { get; set; }
        public object M_Year { get; set; }
        
      

        public RowOfData() { }

        public RowOfData(object _people_id, object _Прізвище, object _Ім_я, object _Побатькові,
            object _Стать, object _Дата_народження, object _Село, object _Вулиця, object _Номер_будинку,
            object _Паспорт, object _Ідент_код, object _Номер_телефону, object _Статус, object _Реєстрація, object year)
        {
            people_id = _people_id;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            sex = _Стать;
            date_of_birth = _Дата_народження;
            village = _Село;
            street = _Вулиця;
            numb_of_house = _Номер_будинку;
            passport = _Паспорт;
            id_kod = _Ідент_код;
            phone_numb = _Номер_телефону;
            status = _Статус;
            registr = _Реєстрація;
            M_Year = year;
            
           
        }

        public void DataChange(object _people_id, object _Прізвище, object _Ім_я, object _Побатькові,
            object _Стать, object _Дата_народження, object _Село, object _Вулиця, object _Номер_будинку,
            object _Паспорт, object _Ідент_код, object _Номер_телефону, object _Статус, object _Реєстрація, object year)
        {
            people_id = _people_id;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            sex = _Стать;
            date_of_birth = _Дата_народження;
            village = _Село;
            street = _Вулиця;
            numb_of_house = _Номер_будинку;
            passport = _Паспорт;
            id_kod = _Ідент_код;
            phone_numb = _Номер_телефону;
            status = _Статус;
            registr = _Реєстрація;
            M_Year = year;
            
        }

        public RowOfData GetValueFromDB(int id)
        {
            RowOfData row = null;
            ConnectionClass conn = new ConnectionClass();
            MySqlDataReader _reader;
            conn.openConnection();
            string query = "SELECT * FROM people WHERE people_id = " + id;

            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            _reader = cmd.ExecuteReader();

            if (_reader.Read()) ;
            {
                row = new RowOfData(_reader["people_id"], _reader["lastname"], _reader["name"],
                       _reader["surname"], _reader["sex"], _reader["date_of_birth"], _reader["village"],
                       _reader["street"], _reader["numb_of_house"], _reader["passport"], _reader["id_kod"],
                       _reader["phone_numb"], _reader["status"], _reader["registr"], _reader["m_date"]);
            }
            return row;
        }

    }
}
