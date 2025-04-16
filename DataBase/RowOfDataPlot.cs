
namespace DataBase
{
    class RowOfDataPlot
    {
        public object id { get; set; }
        public object fullName { get; set; }
        public object village { get; set; }
        public object street { get; set; }
        public object houseNummb { get; set; }
        public object fieldNumber { get; set; }
        public object plotType { get; set; }
        public object plotNumber { get; set; }
        public object plotArea { get; set; }
        public object cadastr { get; set; }
        public object tenant { get; set; }
        public object url { get; set; }

        public RowOfDataPlot() { }

        public RowOfDataPlot(object _Id, object _ПІП, object _Село, object _street, object _houseNummb,
            object _НомерПоля, object _ТипДілянки, object _НомерДілянки, object _Площа, object _КадастровийНомер,
            object _Орендар, object _url)
        {
            id = _Id;
            fullName = _ПІП;
            village = _Село;
            street = _street;
            houseNummb = _houseNummb;
            fieldNumber = _НомерПоля;
            plotType = _ТипДілянки;
            plotNumber = _НомерДілянки;
            plotArea = _Площа;
            cadastr = _КадастровийНомер;
            tenant = _Орендар;
            url = _url;
        }

    }
}
