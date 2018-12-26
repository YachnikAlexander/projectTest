using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase7
    {
        private OrderPage orderPage;

        [TestMethod]
        public void FormTest()
        {
            OpenOrderPage();
            SubmitForm();
        }
        private void OpenOrderPage()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            this.orderPage = orderPage;
        }
        private void SubmitForm()
        {
            orderPage.SelectTwoWayForm();
            orderPage.SubmitForm();
            var el = orderPage.GetInputForCheckingOriginSearchValue();
            var classNames = el.GetAttribute("className");
            Assert.AreEqual(true, classNames.Contains("error-field"));
        }
    }
}
