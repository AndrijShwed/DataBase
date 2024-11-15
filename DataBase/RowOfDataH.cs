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

    }
}
