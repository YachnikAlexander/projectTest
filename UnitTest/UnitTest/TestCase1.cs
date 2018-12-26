using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase1
    {
        private OrderPage orderPage;
        [TestMethod]
        public void ValidNumberOfAdults()
        {
            OpenOrderPage();
            SelectAdults();
        }
        private void OpenOrderPage()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            this.orderPage = orderPage;
        }

        private void SelectAdults()
        {
            orderPage.SelectTwoWayForm();
            orderPage.SelectAdults();
            Assert.AreEqual(true, orderPage.CheckAdultsList());
        }
    }
}
