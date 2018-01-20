using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Parsers;
using BD;

namespace Project.Tests
{
    [TestClass()]
    public class Tests
    {
        DataBase bd;
        
        [TestInitialize()]
        public void Initialize()
        {
            bd = new DataBase();
          
        }
        [TestMethod()]
        public void AddNewsTest()
        {
            
            bd.AddNews(new News("Проверка", "Проверка", "Проверка"));
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void ParseItemTest()
        {
            ParsingEvents.ParseEvent("events/10969");
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void GetNews()
        {
            bd = DataBase.GetDB();
            foreach(News n in bd.News)
            {
                Console.WriteLine(n.Name);
            }
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void ClearNews()
        {
            bd = DataBase.GetDB();
            bd.ClearNews();
            GetNews();
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void ParseEventsTest()
        {
          
            ParsingEvents.FindNews();
            Assert.AreEqual(1, 1);
        }
        [TestMethod()]
        public void StringEqualsTest()
        {
            string s1 = "1111";
            string s2 = s1;
            s1 = "abcd";
            Assert.AreEqual(s1, s2);
            
        }
    }
}