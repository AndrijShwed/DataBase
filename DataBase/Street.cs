using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Street
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public Street (string name)
        {
            this.Name = name; 
        }
    }
}
