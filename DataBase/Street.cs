namespace DataBase
{
    public class Street
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public Street() { }
        public Street (string name)
        {
            this.Name = name; 
        }
    }
}
