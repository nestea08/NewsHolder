using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public DateTime Date { get; set; }
        public string Link { get; set; }
        public News() { }
        public News(string name,string description,string link) {
            Name = name;
            Description = description;
         
            Link = link;
           
        }
        public override bool Equals(object n1)
        {
            if (n1 == null)
            {
                return false;
            }
            News n = n1 as News;
            if(n as News == null)
            {
                return false;
            }
            return Name == n.Name && Description == n.Description && Link == n.Link;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Description.GetHashCode() + Link.GetHashCode();
        }

    }
}
