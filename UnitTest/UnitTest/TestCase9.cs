using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class TestCase9
    {
        private OrderPage orderPage;
        private const string ValueForCheckingOriginInput = "Adis";
        private const string ValueForCheckingDestinationInput = "Bra";
        private static DateTime date = DateTime.Today;
        private string[] ValueForCheckingDate = { date.AddDays(3).ToString().Substring(0, 2), date.AddDays(3).ToString().Substring(3, 2), "2018" };

        [TestMethod]
        public void GroupTest()
        {
            OpenOrderPage();
            FilliOriginInput();
            FilliDestinationInput();
            FillDateReturnInput();
            FillAdultsNumber();
            FillChildrenNmber();
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

        private void FillAdultsNumber()
        {
            int num = 6;
            orderPage.SelectAdults();
            orderPage.SelectNumberOfAdults(num);
        }

        private void FillChildrenNmber()
        {
            int num = 4;
            orderPage.SelectChildren();
            orderPage.SelectNumberOfChildren(num);
        }

        private void SubmitTheForm()
        {
            orderPage.SubmitForm();
            Assert.AreEqual(true, orderPage.isAlertPresent());
        }

        
    }
}
