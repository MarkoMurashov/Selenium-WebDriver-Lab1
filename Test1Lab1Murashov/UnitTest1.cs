using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Test1Lab1Murashov
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By[] menuComponents = {
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/tv']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/premiere/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/films/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/mult/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/series/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/show/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/sport/main']"),
            By.XPath("//nav[@class='menu']//a[@href='https://megogo.net/ru/cybersport']")
        };


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestMenu()
        {
            driver.Navigate().GoToUrl("https://megogo.net/ru");

            foreach (var component in menuComponents)
            {
                var menuButton = driver.FindElement(component);
                menuButton.Click();
                Thread.Sleep(2000);
            }          
        }

        [Test]
        public void TestPastebin()
        {
            driver.Navigate().GoToUrl("https://pastebin.com");

            var textBox = driver.FindElement(By.XPath("//textarea"));
            textBox.SendKeys("Privet :)");

            var textBoxTitle = driver.FindElement(By.XPath("//input[@id='postform-name']"));
            textBoxTitle.SendKeys("TITLE !!!");

            var exposure = driver.FindElement(By.XPath("(//span[@class='select2-selection select2-selection--single'])[2]"));
            exposure.Click();

            var exposure10M = driver.FindElement(By.XPath("//li[contains(.,'10 Minutes')]"));
            exposure10M.Click();

            var submitButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            submitButton.Click();

            Thread.Sleep(2000);

            var assert = driver.FindElement(By.XPath("//div[@class='de1' and contains(text(), 'Privet :)')]"));
            assert.Click();
        }
    }
}