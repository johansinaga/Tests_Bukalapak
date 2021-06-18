using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace Web_Automation
{
    [TestClass]
    public class TestCases
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            // Start Chrome
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

            // Go to Bukalapak Site
            driver.Url = "https://www.bukalapak.com/";

            // Check Bukalapak logo element(s) can be found
            var logoElements = driver.FindElements(By.XPath("//img[contains(@src, 'bukalapak-logo')]"));
            Assert.IsTrue(logoElements.Count != 0, "No bukalapak logo elements found");
        }

        [TestMethod]
        public void Register()
        {
            // Click Register button
            var registerButton = driver.FindElement(By.XPath("//a[contains(@href, 'register')]"));
            registerButton.Click();

            // Fill in Input field
            int randomNum = new Random().Next(10000);
            string userEmail = $"TestUIAutomation{randomNum}@gmail.com";
            var inputField = driver.FindElement(By.CssSelector("input.bl-text-field__input"));
            inputField.SendKeys(userEmail);

            // Click Daftar
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[span/text()='Daftar']")).Click();

            // Check PopUp Header
            var popUpText = driver.FindElement(By.XPath("//*[contains(./text(), 'Email kamu sudah benar?')]"));
            Assert.IsTrue(popUpText.Displayed, "PopUp with text 'Email kamu sudah benar?' cannot be found on page");

            // Kirim Kode
            driver.FindElement(By.XPath("//button[contains(span/text(),'kirim kode')]")).Click();

            Thread.Sleep(1000);
            // Check header text
            var actualHeaderText = driver.FindElement(By.CssSelector(".bl-text--subheading-3")).Text;
            var expectedHeaderText = "Verifikasi Pendaftaran";
            Assert.AreEqual(expectedHeaderText, actualHeaderText, $"Header text is not correct, expected: '{expectedHeaderText}'; but found: '{actualHeaderText}'");

            // Check email
            var emailShown = driver.FindElement(By.CssSelector(".handle")).Text;
            Assert.AreEqual(userEmail, emailShown, $"User email shown is not correct, expected: '{userEmail}'; but found: '{emailShown}'");
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
