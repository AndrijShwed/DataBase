
namespace DataBase
{
    class RowOfDataPlot
    {
        public object id { get; set; }
        public object fullName { get; set; }
        public object village { get; set; }
        public object plotNumber { get; set; }
        public object tenant { get; set; }
        public object plowedLandNumber { get; set; }
        public object plowedLandArea { get; set; }
        public object hayField1Number { get; set; }
        public object hayField1Area { get; set; }
        public object hayField2Number { get; set; }
        public object hayField2Area { get; set; }


        public RowOfDataPlot() { }

        public RowOfDataPlot(object _Id, object _ПІП, object _Село, object _НомерПоля,
            object _Орендар, object _НомерРіллі, object _ПлощаРіллі, object _Сінокіс1Номер,
            object _Сінокіс1Площа, object _Сінокіс2Номер, object _Сінокіс2Площа)
        {
            id = _Id;
            fullName = _ПІП;
            village = _Село;
            plotNumber = _НомерПоля;
            tenant = _Орендар;
            plowedLandNumber = _НомерРіллі;
            plowedLandArea = _ПлощаРіллі;
            hayField1Number = _Сінокіс1Номер;
            hayField1Area = _Сінокіс1Площа;
            hayField2Number = _Сінокіс2Номер;
            hayField2Area = _Сінокіс2Площа;

        }

    }
}
