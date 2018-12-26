using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase5
    {
        private OrderPage orderPage;

        [TestMethod]
        public void TwoWayFormTest()
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
            orderPage.SelectTwoWayForm();
            var el = orderPage.GetDataRangeWithReturn();
            var attr = el.GetCssValue("display");
            Assert.AreEqual(true, attr.Equals("block"));
        }
    }
}
