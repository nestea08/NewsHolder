using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace BD
{
    public class DataBase
    {
        public List<News> News { get; private set; }
        public DataBase() {}
        public static DataBase GetDB()
        {
            return new DataBase { News = GetNews() };
        }
        public void AddNews(News n)
        {
            using (NewsContext nc = new NewsContext())
            {
                if (!nc.NewsSet.Contains(n))
                {
                    nc.NewsSet.Add(n);

                    nc.SaveChanges();
                }

            }
            News.Add(n);
        }
        
        private static List<News> GetNews()
        {
            using (NewsContext nc=new NewsContext())
            {
                return nc.NewsSet.ToList();
            }
        }
        public void DeleteNews(News n)
        {
            using (NewsContext nc = new NewsContext())
            {
                nc.NewsSet.Remove(n);

                nc.SaveChanges();
            }
            News.Remove(n);
        }
        public void ClearNews()
        {
            using (NewsContext nc = new NewsContext())
            {
                foreach(News n in nc.NewsSet)
                {
                    nc.NewsSet.Remove(n);
                }

                nc.SaveChanges();
            }
            News.Clear();
        }
    }
   
}
