using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ruilwinkel;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Categorie categorie = new Categorie("Laptops", 15);
            Assert.AreEqual("Laptops", categorie.categorienaam);
            Assert.AreEqual(15, categorie.punten);
        }
    }
}
