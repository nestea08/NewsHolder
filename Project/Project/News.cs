using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       //public DateTime Date { get; set; }
        public string Link { get; set; }
        public News() { }
        public News(string name,string description,DateTime date,string link) {
            Name = name;
            Description = description;
            //Date = date;
            Link = link;
        }

    }
}
