namespace DataBase
{
    internal class RowOfVillage
    {
        public object id { get; set; }
        public object year { get; set; }
        public object  village { get; set; }
        public object count { get; set; }
       
       
        public RowOfVillage() { }

        public RowOfVillage(object _id, object _year, object _village, object _count)
        {
            id = _id;
            year = _year;
            village = _village;
            count = _count;
          
        }

    }
}
