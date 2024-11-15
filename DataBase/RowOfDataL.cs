namespace DataBase
{
    internal class RowOfDataL
    {
       
        public object lastname { get; set; }
        public object name { get; set; }
        public object surname { get; set; }
       
        public RowOfDataL() { }

        public RowOfDataL(object _Прізвище, object _Ім_я, object _Побатькові)
        { 
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
        }

        public void DataChange(object _Прізвище, object _Ім_я, object _Побатькові)
        {
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
        }

    }
}
