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
        private string name;
        private string description;
        private DateTime date;
        private string link;
        public News(string name,string description,DateTime date,string link) {
            this.name = name;
            this.description = description;
            this.date = date;
            this.link = link;
        }

    }
}
