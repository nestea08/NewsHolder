using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Project;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            BD bd = new BD();
            foreach(News n in bd.GetNews())
            {
                Console.WriteLine(n.Name);
            }
           
            
        }
    }
}
