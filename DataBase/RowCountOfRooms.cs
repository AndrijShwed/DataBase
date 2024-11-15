namespace DataBase
{
    internal class RowCountOfRooms
    {
        public object id { get; set; }
        public object year { get; set; }
        public object one_rooms { get; set; }
        public object two_rooms { get; set; }
        public object three_rooms { get; set; }
        public object four_rooms { get; set; }
        public object five_rooms { get; set; }
        public object six_rooms { get; set; }
        public object more_rooms { get; set; }
        public object total { get; set; }
       
        public RowCountOfRooms() { }

        public RowCountOfRooms(object _id, object _year, object _one_rooms, object _two_rooms,
            object _three_rooms, object _four_rooms, object _five_rooms, object _six_rooms, object _more_rooms, object _total)
        {
            id = _id;
            year = _year;
            one_rooms = _one_rooms;
            two_rooms = _two_rooms;
            three_rooms = _three_rooms;
            four_rooms = _four_rooms;
            five_rooms = _five_rooms;
            six_rooms = _six_rooms;
            more_rooms = _more_rooms;
            total = _total;
        }

        public void DataChange(object _id, object _year, object _one_rooms, object _two_rooms,
            object _three_rooms, object _four_rooms, object _five_rooms, object _six_rooms, object _more_rooms, object _total)
        {
            id = _id;
            year = _year;
            one_rooms = _one_rooms;
            two_rooms = _two_rooms;
            three_rooms = _three_rooms;
            four_rooms = _four_rooms;
            five_rooms = _five_rooms;
            six_rooms = _six_rooms;
            more_rooms = _more_rooms;
            total= _total;
        }
    }
}
