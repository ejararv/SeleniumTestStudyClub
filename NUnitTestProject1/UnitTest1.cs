using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using NUnitTestProject1;
using System.Threading;
//using AutoItX3Lib;
using AutoIt;
using System.Windows;
using AutoItX3Lib;
using OpenQA.Selenium.Interactions;

namespace Testowanie.Tests
{

    [TestFixture]
    public class PrzykladTests : Elements     
    {
        //POM(Page Object Model) Без методов (Только обьекты. Не такой сложный проект чтобы создавать методы)
        public IWebDriver Driver = new ChromeDriver();
        AutoItX3 autoit = new AutoItX3();
       
            

        [OneTimeTearDown]
        public void zakonc()

        {
            Driver.Close();
        }

        [Test]
        public void AngularLogin()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/login");                           
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);        // ImplicitWait
            IWebElement emailInput = Driver.FindElement(_emailInput);
            IWebElement passwordInput = Driver.FindElement(_passwordInput);
            IWebElement submitButton = Driver.FindElement(_submitButton);
            emailInput.SendKeys("ejararv@gmail.com");
            passwordInput.SendKeys("6077832Gt");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            submitButton.Click();
            Thread.Sleep(1000);
            Assert.That(Driver.Url, Is.EqualTo("http://localhost:4200/"));                //Asert (проверяет соответствует ли урл после выполнения теста заданному)
        }
        [Test]
        public void AngularLoginEror()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/login");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement emailInput = Driver.FindElement(_emailInput);
            IWebElement passwordInput = Driver.FindElement(_passwordInput);
            IWebElement submitButton = Driver.FindElement(_submitButton);
            emailInput.SendKeys("ejararv.com");
            passwordInput.SendKeys("6077832Gt");
            submitButton.Click();
            Thread.Sleep(1000);
            Assert.That(Driver.Url, Is.EqualTo("http://localhost:4200/login"));
        }

        [Test]
        public void AngularUpload()      //AutoItX
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/upload");
            IWebElement uploadButton = Driver.FindElement(_uploadButton);
           
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            uploadButton.SendKeys(@"E:\ФЛЕШКА\java");
            uploadButton.Click();
            Thread.Sleep(2000);

            autoit.WinActivate("Открытие");                                                                                  //AutoIT, WinActivate,AutoIT.Send
            Thread.Sleep(2000);
            autoit.Send(@"E:\ФЛЕШКА\java");
            autoit.Send("{ENTER}");
            Thread.Sleep(2000);
            Assert.That(Driver.Url, Is.EqualTo("http://localhost:4200/upload"));
        }

        [Test]
        public void DragAndDropTest()                                                                                        // DragAndDrop , DragAndDropByOffset, ClickAnd Hold,  MoveByOffset
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/results");
            IWebElement rangeButton = Driver.FindElement(_rangeButton);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions action = new Actions(Driver);
            
            action.DragAndDropToOffset(rangeButton, 100, 0).Build().Perform();
            action.Release().Build().Perform();
            Thread.Sleep(2000);
            action.ClickAndHold(rangeButton).MoveByOffset(-50, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, 20, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, -70, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, 100, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, -90, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, 10, 0).Build().Perform();
            Thread.Sleep(2000);
            action.DragAndDropToOffset(rangeButton, 50, 0).Build().Perform();
            Thread.Sleep(2000);
        }
        [Test]
        public void ExecuteJsScriptTest()                                                  // JavaScript Executor
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/contact");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("document.getElementById('user_name').value='Executor'");
            js.ExecuteScript("document.getElementById('user_email').value='Testemail.gmail.com'");
            js.ExecuteScript("document.getElementById('message').value='SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS'");

            Thread.Sleep(3000);
            IWebElement sendMailButton = Driver.FindElement(_sendMailButton);
            sendMailButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

       

        [Test]
        public void AngularLogoutUserProbaPrzejscDoDodawaniaOcen()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/login");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement emailInput = Driver.FindElement(_emailInput);
            IWebElement passwordInput = Driver.FindElement(_passwordInput);
            IWebElement submitButton = Driver.FindElement(_submitButton);           
            emailInput.SendKeys("ejararv@gmail.com");
            passwordInput.SendKeys("6077832Gt");
            submitButton.Click();
            Thread.Sleep(1000);
            IWebElement logoutButton = Driver.FindElement(_logoutButton);
            logoutButton.Click();
            Driver.Navigate().GoToUrl("http://localhost:4200/students");
            Assert.That(Driver.Url, Is.EqualTo("http://localhost:4200/login"));
        }

        [Test]                                                            // Далее тесты для сервера. Ничего интересного
        public void CzyUdaSieDodacUzytkownika()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            Thread.Sleep(2000);
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            nameAPI.SendKeys("Putin");
            ageAPI.SendKeys("60");
            submitAPI.Click();
            Thread.Sleep(2000);
        }

       

        [Test]
        public void CzyUdaSieUsunacUzytkownika()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement deleteButton = Driver.FindElement(_deleteButton);
            deleteButton.Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void CzyZmienicUzytkownika()
        {


            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("/html/body/table/tbody/tr[4]/td[4]/a[1]")).Click();
            Thread.Sleep(2000);
            nameAPI.Clear();
            ageAPI.Clear();
            Thread.Sleep(1000);
            nameAPI.SendKeys("Trump");
            ageAPI.SendKeys("55");
            Thread.Sleep(1000);
            submitAPI.Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void CzyUdaSieDodacUzytkownikaZBłendnymWiekiem()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            Thread.Sleep(5000);
            Driver.FindElement(By.Name("name")).SendKeys("Putin");
            Driver.FindElement(By.Name("age")).SendKeys("60.3");
            Driver.FindElement(By.XPath("//*[@id='submit']")).Click();
            Thread.Sleep(5000);
        }


        [Test]
        public void CzyUdaSieDodacUzytkownikaZPolskimImiem()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            Thread.Sleep(5000);
            nameAPI.SendKeys("Miłosz");
            ageAPI.SendKeys("20");
            submitAPI.Click();
            Thread.Sleep(5000);
        }
        [Test]
        public void CzyUdaSieDodacUzytkownikaZRosyjskimImiem()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            Thread.Sleep(5000);
            nameAPI.SendKeys("Эдуард");
            ageAPI.SendKeys("24");
            submitAPI.Click();
            Thread.Sleep(5000);
        }
        [Test]
        public void CzyUdaSieDodacUzytkownikaBezImie()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            Thread.Sleep(5000);
            nameAPI.SendKeys("");
            ageAPI.SendKeys("60");
            submitAPI.Click();
            Thread.Sleep(5000);
        }
        [Test]
        public void CzyUdaSieDodacUzytkownikaBezWieku()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            Thread.Sleep(5000);
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            IWebElement deleteButton = Driver.FindElement(_deleteButton);
            nameAPI.SendKeys("Patryk");
            ageAPI.SendKeys("");
            submitAPI.Click();
            deleteButton.Click();
            Thread.Sleep(5000);
        }
        [Test]
        public void CzyUdaSieDodacUzytkownika200lat()
        {
            Driver.Navigate().GoToUrl("https://localhost:44356/users.html");
            Thread.Sleep(5000);
            IWebElement nameAPI = Driver.FindElement(_nameAPI);
            IWebElement ageAPI = Driver.FindElement(_ageAPI);
            IWebElement submitAPI = Driver.FindElement(_submitAPI);
            IWebElement deleteButton = Driver.FindElement(_deleteButton);
            nameAPI.SendKeys("Stefan");
            ageAPI.SendKeys("200");
            submitAPI.Click();
            deleteButton.Click();
            Thread.Sleep(5000);
        }

    }
}