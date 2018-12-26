using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase10
    {
        private OrderPage orderPage;
        private const string ValueForCheckingInput = "Adis";
        [TestMethod]
        public void OriginAndDestinationTest()
        {
            OpenOrderPage();
            FilliOriginInput();
            FilliDestinationInput();
        }
        private void OpenOrderPage()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            this.orderPage = orderPage;
        }
        private void FilliOriginInput()
        {
            orderPage.SelectInputForSearchingOrigin();
            var originInput = orderPage.GetInputForSearchingOrigin();
            orderPage.SetValue(originInput, ValueForCheckingInput);
            orderPage.SelectOriginItem();
        }

        private void FilliDestinationInput()
        {
            orderPage.SelectInputForSearchingDestination();
            var destinationInput = orderPage.GetInputForSearchingDestination();
            orderPage.SetValue(destinationInput, ValueForCheckingInput);
            Assert.AreEqual(true, orderPage.IsEmptyDestination());
        }
    }
}
