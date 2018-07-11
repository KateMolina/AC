using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avioCreditSelenium
{
    [TestFixture]
    public class AccountInfoPageTests
    {
        public static IWebDriver driver;
        static bool result;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
        }
        
        [Test]
        public void PositiveTest()
        {
            AccountInfoPage.CreateDefaultAccount(driver)
                .withPassword("Speedy123$")
                .withSequrityQuest("16")
                .IDCredentials()
                .Submit();
            result = VerifyURL.ValidateURL(driver, "https://secure.aviocredit.com.train/LoanApplication/Personal");
            Assert.IsTrue(result);
            
        }

        [Test]
     /*   public static void NegativeTest()
        {
            AccountInfoPage.CreateDefaultAccount(driver)
                .withEmail("wichita2@curo.com")
                .withConfirmPassword("speedy123$")
                .withSequrityQuest("16")
                .IDCredentials()
                .Submit();
            result = VerifyURL.ValidateURL(driver, "https://secure.aviocredit.com.train/LoanApplication/Personal");
            Assert.IsFalse(result);

        }*/
        
        [TearDown]
        public void TearDown()
        {
            
        }

    }
}