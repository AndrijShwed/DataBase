namespace DataBase
{
    class RowOfTableКористувачі
    {
        public object Користувачі_id { get; set; }
        public object Ім_я { get; set; }
        public object Прізвище { get; set; }
        public object Логін { get; set; }
        public object Пароль { get; set; }



        public RowOfTableКористувачі() { }

        public RowOfTableКористувачі(object id, object ім_я, object прізвище, object логін, object пароль)
        {
            Користувачі_id = id;
            Ім_я = ім_я;
            Прізвище = прізвище;
            Логін = логін;
            Пароль = пароль;
        }
        public void DataChange(object _id, object _ім_я, object _прізвище, object _логін, object _пароль)
        {
            Користувачі_id = _id;
            Ім_я = _ім_я;
            Прізвище = _прізвище;
            Логін = _логін;
            Пароль = _пароль;
        }
    }
        

}
