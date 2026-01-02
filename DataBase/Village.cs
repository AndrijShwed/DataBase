using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class Village
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Village(string name)
        {
            this.Name = name; 
        }
    }
}
