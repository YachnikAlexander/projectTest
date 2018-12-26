using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase8
    {
        private OrderPage orderPage;

        [TestMethod]
        public void InfantsTest()
        {
            OpenOrderPage();
            CheckInfants();
        }
        private void OpenOrderPage()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            this.orderPage = orderPage;
        }
        private void CheckInfants()
        {
            orderPage.SelectTwoWayForm();
            int num = 5;
            orderPage.SelectAdults();
            orderPage.SelectNumberOfAdults(num);
            orderPage.SelectInfants();
            Assert.AreEqual(true, orderPage.CheckInfantsList(num));
        }
    }
}
