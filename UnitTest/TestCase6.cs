using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase6
    {
        private OrderPage orderPage;
        private const string ValueForTestingSearchingOriginInput = "Belarus";

        [TestMethod]
        public void SearchingOriginTest()
        {
            OpenOrderPageAndSelectSearchingOriginInput();
            EnterValueInSearchingOriginInput();
        }

        private void OpenOrderPageAndSelectSearchingOriginInput()
        {
            var orderPage = new OrderPage(new ChromeDriver());
            orderPage.OpenOrderPage();
            orderPage.SelectInputForSearchingOrigin();
            this.orderPage = orderPage;
        }

        private void EnterValueInSearchingOriginInput()
        {
            var searchingInput = this.orderPage.GetInputForSearchingOrigin();
            this.orderPage.SetValue(searchingInput, ValueForTestingSearchingOriginInput);
            this.orderPage.SubmitTheData(searchingInput);
            var chackingInputValue = this.orderPage.GetInputForCheckingOriginSearchValue().GetAttribute("value");
            Assert.AreEqual(true, String.IsNullOrEmpty(chackingInputValue));
        }
    }
}
