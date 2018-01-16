using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project.Tests
{
    [TestClass()]
    public class ParsingTests
    {
        BD bd;
        [TestInitialize()]
        public void Test_initialize()
        {
            bd = new BD();
        }
        [TestMethod()]
        public void Parse_firstTest()
        {
            bd.AddNews(new News("Проверка", "Проверка",DateTime.Now, "Проверка"));
            Assert.AreEqual(1, 1);
        }
    }
}