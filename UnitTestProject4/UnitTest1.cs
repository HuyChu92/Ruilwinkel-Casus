using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ruilwinkel;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace UnitTestProject4
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
        [TestMethod]
        public void TestMethod2()
        {
            var dropdownlist = new DropDownList();
            dropdownlist.SelectedValue = "Beschikbaar";
            Assert.AreEqual(string.Empty, dropdownlist.SelectedValue);
            dropdownlist.Items.Add("Beschikbaar");
            Assert.AreEqual("Beschikbaar", dropdownlist.SelectedValue);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var item = new CheckBox();
            item.Checked = true;
            Assert.AreEqual(true, item.Checked);
        }
        [TestMethod]
        public void TestMethod4()
        {
            var checkboxlist = new CheckBoxList();
            checkboxlist.Items.Add("Schoenen");
            checkboxlist.Items[0].Selected = true;
            Assert.AreEqual(true, checkboxlist.Items[0].Selected);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Article article = new Article(1, "Product", "Image.jpg");
            Assert.AreEqual(1, article.productID);
            Assert.AreEqual("Product", article.commantary);
            Assert.AreEqual("Image.jpg", article.image);
        }
        [TestMethod]
        public void TestMethod6()
        {
            AvailableArticles available = new AvailableArticles("ProductX", "New product", "Schoenen", 1, 5, "Image.jpg");
            Assert.AreEqual("ProductX", available.productname);
            Assert.AreEqual("New product", available.description);
            Assert.AreEqual("Schoenen", available.categoryname);
            Assert.AreEqual(1, available.articleID);
            Assert.AreEqual(5, available.points);
            Assert.AreEqual("Image.jpg", available.image);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Product product = new Product(1, "Product", "Product1");
            Assert.AreEqual(1, product.CategorieID);
            Assert.AreEqual("Product", product.ProductName);
            Assert.AreEqual("Product1", product.Description);
        }
        [TestMethod]
        public void TestMethod8()
        {
            List<int> ID = new List<int>();
            ID.Add(1);
            ID.Add(2);
            SortedArticles sorted = new SortedArticles(ID);
            Assert.AreEqual(ID, sorted.articles);
        }
        [TestMethod]
        public void TestMethod9()
        {
            CategoryInfo category = new CategoryInfo(1, "Categorie", 4);
            Assert.AreEqual(1, category.categoryID);
            Assert.AreEqual("Categorie", category.categorienaam);
            Assert.AreEqual(4, category.punten);
        }
        [TestMethod]
        public void TestMethod10()
        {
            ProductInfo productInfo = new ProductInfo(1, 2, "ProductInfo", "Info");
            Assert.AreEqual(1, productInfo.ID);
            Assert.AreEqual(2, productInfo.CategorieID);
            Assert.AreEqual("ProductInfo", productInfo.ProductName);
            Assert.AreEqual("Info", productInfo.Description);
        }
    }
}
