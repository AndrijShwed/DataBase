namespace DataBase
{
    internal class VillageStreet
    {
        public object id { get; set; }
        public object village { get; set; }
        public object street { get; set; }

        public VillageStreet() { }

        public VillageStreet(object _id, object _village, object _street )
        {
            id = _id;
            village = _village;
            street = _street; 
        }

        public VillageStreet(object _village)
        {
            village = _village;
        }

    }
}
