using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace Project
{
    public class BD
    {
        public void AddNews(News n)
        {
            using (NewsContext nc = new NewsContext())
            {
                nc.NewsSet.Add(n);
                nc.SaveChanges();
            }
        }
        public List<News> GetNews()
        {
            using (NewsContext nc=new NewsContext())
            {
                return nc.NewsSet.ToList();
            }
        }
    }
   
}
