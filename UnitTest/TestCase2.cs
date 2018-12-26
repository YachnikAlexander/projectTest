using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase2
    {
        private OrderPage orderPage;
        private const string ValueForCheckingOriginInput = "Adis";
        private const string ValueForCheckingDestinationInput = "Bra";
        private string[] ValueForCheckingDate = { "22", "10", "2018" };

        [TestMethod]
        public void InvalidDateTest()
        {
            OpenOrderPage();
            FilliOriginInput();
            FilliDestinationInput();
            FillDateInput();
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

        private void FillDateInput()
        {
            orderPage.SelectDateInput();
            orderPage.ClearDateInput();
            orderPage.SetDateValues(ValueForCheckingDate);
        }

        private void SubmitTheForm()
        {
            orderPage.SubmitForm();
            var el = orderPage.GetDateInput();
            var classNames = el.GetAttribute("className");
            Assert.AreEqual(true, classNames.Contains("error-field"));
        }

    }
}
