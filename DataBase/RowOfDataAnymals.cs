namespace DataBase
{
    class RowOfDataAnymals
    {
        public object anymalsId { get; set; }
        public object lastname { get; set; }
        public object name { get; set; }
        public object surname { get; set; }
        public object village { get; set; }
        public object anymals { get; set; }
        public object covs { get; set; }
        public object pigs { get; set; }
        public object sheeps { get; set; }
        public object goats { get; set; }
        public object horses { get; set; }
        public object birds { get; set; }
        public object rabbits { get; set; }
        public object beeses { get; set; }
     

        public RowOfDataAnymals() { }

        public RowOfDataAnymals(object _anymalsId, object _Прізвище, object _Ім_я, object _Побатькові,
            object _Село, object _ВРХ, object _Корови, object _Свині,
            object _Вівці, object _Кози, object _Коні, object _Птиця, object _Кролі, object _Бджоли)
        {
            anymalsId = _anymalsId;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            village = _Село;
            anymals = _ВРХ;
            covs = _Корови;
            pigs = _Свині;
            sheeps = _Вівці;
            goats = _Кози;
            horses = _Коні;
            birds = _Птиця;
            rabbits = _Кролі;
            beeses = _Бджоли;
            
        }

        public void DataChange(object _anymalsId, object _Прізвище, object _Ім_я, object _Побатькові,
            object _Село, object _ВРХ, object _Корови, object _Свині,
            object _Вівці, object _Кози, object _Коні, object _Птиця, object _Кролі, object _Бджоли)
        {
            anymalsId = _anymalsId;
            lastname = _Прізвище;
            name = _Ім_я;
            surname = _Побатькові;
            village = _Село;
            anymals = _ВРХ;
            covs = _Корови;
            pigs = _Свині;
            sheeps = _Вівці;
            goats = _Кози;
            horses = _Коні;
            birds = _Птиця;
            rabbits = _Кролі;
            beeses = _Бджоли;
            
        }

    }
}
