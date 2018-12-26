using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase4
    {
        private OrderPage orderPage;

        [TestMethod]
        public void OneWayFormTest()
        {
            OpenOrderPage();
            CheckForm();
        }

        private void OpenOrderPage()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            this.orderPage = orderPage;
        }

        private void CheckForm()
        {
            orderPage.SelectOneWayForm();
            var el = orderPage.GetDataRange();
            var attr = el.GetAttribute("style");
            Assert.AreEqual(true, attr.Equals("display: none;"));
        }
    }
}