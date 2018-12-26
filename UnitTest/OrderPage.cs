using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class OrderPage
    {
        private IWebDriver driver;
        private const string Url = "https://www.avianca.com.br/pt/";

        By originInputForFocusing = By.CssSelector("#sp-origem");
        By inputForSearchingOrigin = By.CssSelector("input.form-control.txt-center.txt-fixo.search-field");
        By inputForCheckingOriginSearchValue = By.CssSelector("input#origemPassagem.form-control.txt-center.txt-fixo.value-field");
        By selecteOriginItem = By.CssSelector("a.fz-20.tac");
        By destinationInputForFocusing = By.CssSelector("#sp-destino");
        By inputForSearchingDestination = By.CssSelector("#dv-destino input.form-control.txt-center.txt-fixo.search-field");
        By inputForCheckingDestinationSearchValue = By.CssSelector("input#origemPassagem.form-control.txt-center.txt-fixo.value-field");
        By selecteDestinationItem = By.CssSelector("#dv-destino a.fz-20.tac");
        By adultsSelectOptionsList = By.CssSelector(".row.lista-adultos li a");
        By adultsSelectOptionsListInLi = By.CssSelector(".row.lista-adultos li");
        By adultsSelect = By.CssSelector(".current-value.fz-20.tac.cur-value-adultos");
        By childrenSelect = By.CssSelector(".current-value.fz-20.tac.cur-value-criancas");
        By childrenSelectOptionListInLi = By.CssSelector(".row.lista-criancas li");
        By childrenSelectOptionList = By.CssSelector(".row.lista-criancas li a");
        By destinationList = By.CssSelector(".row.destino-passagem li");
        By infantsSelect = By.CssSelector(".current-value.fz-20.tac.cur-value-bebes");
        By infantsSelectOptionListInLi = By.CssSelector(".row.lista-bebes li");
        By infantsSelectOptionList = By.CssSelector(".row.lista-bebes li a");
        By twoWayForm = By.CssSelector("#idaevolta + label");
        By oneWayForm = By.CssSelector("#soida + label");
        By dateInput = By.CssSelector("#dateidaPassagem");
        By dateReturnInput = By.CssSelector("#datevoltaPassagem");
        By submitButton = By.CssSelector("#btn-buscar");
        By dataRange = By.CssSelector(".daterange.col-xs-6 .row .pl");
        By dataRangeWithReturn = By.CssSelector(".daterange.col-xs-12 .row .pl");

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool isAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)
            {
                return false;
            }
        }

        public void OpenOrderPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void SelectInputForSearchingOrigin()
        {
            driver.FindElement(originInputForFocusing).Click();
        }

        public void SelectOriginItem()
        {
            driver.FindElement(selecteOriginItem).Click();
        }

        public void SelectAdults()
        {
            driver.FindElement(adultsSelect).Click();
        }

        public void SelectInfants()
        {
            driver.FindElement(infantsSelect).Click();
        }

        public void SelectChildren()
        {
            driver.FindElement(childrenSelect).Click();
        }

        public void SelectTwoWayForm()
        {
            driver.FindElement(twoWayForm).Click();
        }

        public void SelectOneWayForm()
        {
            driver.FindElement(oneWayForm).Click();
        }

        public bool CheckAdultsList()
        {
            var liA = driver.FindElements(adultsSelectOptionsList);
            for(int i=0; i<liA.Count; i++)
            {
                if (liA[i].GetAttribute("data-value").Equals("0"))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckInfantsList(int k)
        {
            var liA = driver.FindElements(infantsSelectOptionList);
            if (liA.Count == k + 1) return true;
            else return false;
        }

        public void SelectNumberOfInfants(int k)
        {
            var liA = driver.FindElements(infantsSelectOptionList);
            var li = driver.FindElements(infantsSelectOptionListInLi);
            for (int i = 0; i < liA.Count; i++)
            {
                if (liA[i].GetAttribute("data-value").Equals(k.ToString()))
                {
                    li[i].Click();
                    break;
                }
            }
        }

        public void SelectNumberOfAdults(int k)
        {
            var liA = driver.FindElements(adultsSelectOptionsList);
            var li = driver.FindElements(adultsSelectOptionsListInLi);
            for (int i = 0; i < liA.Count; i++)
            {
                if (liA[i].GetAttribute("data-value").Equals(k.ToString()))
                {
                    li[i].Click();
                    break;
                }
            }
        }

        public void SelectNumberOfChildren(int k)
        {
            var liA = driver.FindElements(childrenSelectOptionList);
            var li = driver.FindElements(childrenSelectOptionListInLi);
            for (int i = 0; i < liA.Count; i++)
            {
                if (liA[i].GetAttribute("data-value").Equals(k.ToString()))
                {
                    li[i].Click();
                    break;
                }
            }
        }

        public bool IsEmptyDestination()
        {
            var li = driver.FindElements(destinationList);
            if(li.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public IWebElement GetInputForSearchingOrigin()
        {
            return driver.FindElement(inputForSearchingOrigin);
        }

        public IWebElement GetInputForCheckingOriginSearchValue()
        {
            return driver.FindElement(inputForCheckingOriginSearchValue);
        }

        public void SelectInputForSearchingDestination()
        {
            driver.FindElement(destinationInputForFocusing).Click();
        }

        public void SelectDestinationItem()
        {
            driver.FindElement(selecteDestinationItem).Click();
        }

        public IWebElement GetInputForSearchingDestination()
        {
            return driver.FindElement(inputForSearchingDestination);
        }

        public IWebElement GetInputForCheckingDestinationSearchValue()
        {
            return driver.FindElement(inputForCheckingDestinationSearchValue);
        }

        public IWebElement GetDataRange()
        {
            return driver.FindElement(dataRange);
        }

        public IWebElement GetDataRangeWithReturn()
        {
            return driver.FindElement(dataRangeWithReturn);
        }

        public void SelectDateInput()
        {
            driver.FindElement(dateInput).Click();
        }

        public IWebElement GetDateInput()
        {
            return driver.FindElement(dateInput); 
        }

        public void ClearDateInput()
        {
            var el = GetDateInput();

            for (int i = 0; i < 5; i++)
            {
                el.SendKeys(Keys.Backspace);
                el.SendKeys(Keys.Delete);
            }
        }

        public void SetDateValues(string[] val)
        {
            var el = GetDateInput();

            for (int i=0; i<val.Length; i++)
            {
                el.SendKeys(val[i]);
            }
        }

        public void SelectDateReturnInput()
        {
            driver.FindElement(dateReturnInput).Click();
        }

        public IWebElement GetDateReturnInput()
        {
            return driver.FindElement(dateReturnInput);
        }

        public void ClearDateReturnInput()
        {
            var el = GetDateReturnInput();

            for (int i = 0; i < 5; i++)
            {
                el.SendKeys(Keys.Backspace);
                el.SendKeys(Keys.Delete);
            }
        }

        public void SetDateReturnValues(string[] val)
        {
            var el = GetDateReturnInput();

            for (int i = 0; i < val.Length; i++)
            {
                el.SendKeys(val[i]);
            }
        }

        public void SubmitForm()
        {
            driver.FindElement(submitButton).SendKeys(Keys.Enter);
        }

        public void SetValue(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public void SubmitTheData(IWebElement element)
        {
            element.SendKeys(Keys.Enter);
        }
        
    }
}
