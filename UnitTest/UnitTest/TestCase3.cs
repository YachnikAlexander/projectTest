using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase3
    {
        private OrderPage orderPage;
        private const string ValueForCheckingOriginInput = "Adis";
        private const string ValueForCheckingDestinationInput = "Bra";
        private static DateTime date = DateTime.Today;
        private string[] ValueForCheckingDate = { date.AddDays(-3).ToString().Substring(0,2), date.AddDays(-3).ToString().Substring(3, 2), "2018" };

        [TestMethod]
        public void InvalidDateTest()
        {
            OpenOrderPage();
            FilliOriginInput();
            FilliDestinationInput();
            FillDateReturnInput();
            SubmitTheForm();
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
            orderPage.SetValue(originInput, ValueForCheckingOriginInput);
            orderPage.SelectOriginItem();
        }

        private void FilliDestinationInput()
        {
            orderPage.SelectInputForSearchingDestination();
            var destinationInput = orderPage.GetInputForSearchingDestination();
            orderPage.SetValue(destinationInput, ValueForCheckingDestinationInput);
            orderPage.SelectDestinationItem();
        }

        private void FillDateReturnInput()
        {
            orderPage.SelectDateReturnInput();
            orderPage.SetDateReturnValues(ValueForCheckingDate);
        }

        private void SubmitTheForm()
        {
            orderPage.SubmitForm();
            var el = orderPage.GetDateReturnInput();
            var classNames = el.GetAttribute("className");
            Assert.AreEqual(true, classNames.Contains("error-field"));
        }
    }
}
