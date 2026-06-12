namespace DataBase
{
    public class Village
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Village() { }
        public Village(string name)
        {
            this.Name = name; 
        }
    }
}
