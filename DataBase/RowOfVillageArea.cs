namespace DataBase
{
    internal class RowOfVillageArea
    {
        public object id { get; set; }
        public object village { get; set; }
        public object total { get; set; }
        public object living { get; set; }
       

        public RowOfVillageArea() { }

        public RowOfVillageArea(object _id, object _village, object _total, object _living)
        {
            id = _id;
            village = _village;
            total = _total;
            living = _living;
           
        }

    }
}
