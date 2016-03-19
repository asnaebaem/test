﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
namespace Selenium
{
    [TestFixture]
    public class UnitTest1
    {
        private IWebDriver _driver;
        private static string _url = "http:/www.google.com/";
        public string[] imie = { "Paweł", "Michał", "Marcin", "Piotrek", "Radek" };
        public string[] nazwisko = { "Kowalski", "Nowak", "Szczygieł", "Jurkowski", "Kolano", "Dudek" };
        public Random rnd = new Random();
        public int tmp;
        public string str_tmp, mix;

        public static IWebDriver ConfigureDriver(IWebDriver driver, string pathToDriver)
        {
            driver = new ChromeDriver(pathToDriver);
            driver.Manage().Window.Maximize();
            return driver;
        }

        [SetUp]
        public void BeforeTests()
        {
            DesiredCapabilities firefoxCap = DesiredCapabilities.Firefox();
            /*_driver = new RemoteWebDriver(new Uri("http://10.168.0.86:4444/wd/hub"), chromeCap);*/
            _driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), firefoxCap);
            //_js = (IJavaScriptExecutor)_driver;
        }

        [Test]
        public void TestSelenium()
        {

            //generowanie zapytania
            mix = "{Witam|Dzień dobry|Cześć}. Chciałem pożyczyć {800|1000|1200|2000} {zł|pln|ojro|usd} na {25|35|42|52|62} {tygodni|tygodnie}. Jest taka opcja?";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.blackpress.pl/mieszarka-synonimow");
            _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[1]/div[2]/table/tbody/tr[1]/td/div/textarea")).SendKeys(mix);
            _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[1]/div[2]/table/tbody/tr[2]/td[2]/div/a")).Click();
            string zapytanie = _driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div/div[1]/div[2]/table/tbody/tr[3]/td/div/textarea")).GetAttribute("value");

            _driver.Navigate().GoToUrl(_url);
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _driver.FindElement(By.Id("lst-ib")).SendKeys("Bocian pozyczki");
            _driver.FindElement(By.XPath("/html/body/div/div[3]/form/div[2]/div[2]/div[1]/div[1]/div[2]/div/div/div/button/span")).Click();
            _driver.FindElement(By.LinkText("Bocian Pożyczki - Strona główna")).Click(); //case sensitive, trzeba podać cały tekst chujowe
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[1]/a")).Click();
            _driver.FindElement(By.XPath("/html/body/form/div[7]/div/div[5]/div/span[2]/input")).Click();

            //wybieranie tematu
            tmp = rnd.Next(0, 2);
            SelectElement dropdown = new SelectElement(_driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[1]/td[2]/div/select")));
            dropdown.SelectByIndex(tmp);

            //generowanie imienia
            tmp = rnd.Next(0, imie.Length);
            str_tmp += (imie[tmp].Substring(0, 1) + ".");
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[2]/td[2]/div/input")).SendKeys(imie[tmp]);

            //generowanie nazwiska
            tmp = rnd.Next(0, nazwisko.Length);
            str_tmp += (nazwisko[tmp] + "@gmail.com");
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[3]/td[2]/div/input")).SendKeys(nazwisko[tmp]);

            //generowanie numeru telefonu
            tmp = rnd.Next(600000000, 888888888);
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[4]/td[2]/div/input")).SendKeys(tmp.ToString());

            //generowanie adresu e-mail
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[5]/td[2]/div/input")).SendKeys(str_tmp);

            //wpisywanie treści    
            _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[6]/td[2]/div/textarea")).SendKeys(zapytanie);

            //checkboxy
            if (_driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[7]/td[2]/div[1]/span")).Displayed)
                _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[7]/td[2]/div[1]/span")).Click();

            if (_driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[8]/td[2]/div[1]/span")).Displayed)
                _driver.FindElement(By.XPath("/html/body/form/div[6]/div[2]/div[3]/div/div[2]/div[2]/table/tbody/tr[8]/td[2]/div[1]/span")).Click();
            //_driver.FindElement(By.Id("ddsadasda")).Click();

            //_driver.Quit();
        }
        [Test]
        public void TestSelenium2()
        {
            _driver.Navigate().GoToUrl("http://www.wp.pl");
            _driver.Quit();
        }

    }
}