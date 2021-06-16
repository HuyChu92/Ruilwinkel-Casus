using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ruilwinkel;
using System;
using System.Web.UI.WebControls;

namespace UnitTestProject5
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
    }
}
