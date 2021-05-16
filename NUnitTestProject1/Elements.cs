using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
   public class Elements
    {
        public IWebDriver Driver;
        public By _emailInput = By.XPath("//*[@id='username']");
        public By _passwordInput = By.XPath("//*[@id='password']");
        public By _submitButton = By.XPath("//*[@id='submit']");
        public By _uploadButton = By.XPath("//*[@id='upload']");
        public By _logoutButton = By.XPath("/html/body/app-root/app-home/app-navban/nav/div/ul/li[6]/a");
        public By _resultsButton = By.XPath("//*[@id='studenci']");
        public By _nameAPI = By.Name("name");
        public By _ageAPI = By.Name("age");
        public By _submitAPI = By.XPath("//*[@id='submit']");
        public By _rangeButton = By.XPath("/html/body/app-root/app-customers/div/div[2]/div/div/mat-slider/div/div[3]/div[2]");
        public By _sendMailButton = By.XPath("/html/body/app-root/app-contact/div/div[2]/div/div/form/div/div[4]/button");
        public By _deleteButton = By.XPath("/html/body/table/tbody/tr[4]/td[4]/a[2]");
    }
}
