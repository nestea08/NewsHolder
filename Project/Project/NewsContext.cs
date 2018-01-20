using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BD
{
    public class NewsContext:DbContext
    {
        public NewsContext() : base("NewsContainer") { }
        public DbSet<News> NewsSet { get; set; }
    }
}
