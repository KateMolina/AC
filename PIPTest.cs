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
    public class PersonalInfoPageTests
    {
        public static IWebDriver driver;
        static bool result;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
            AccountInfoPage.CreateDefaultAccount(driver).IDCredentials().Submit();
        }

        [Test]
        public void PositiveTest()
        {
            PersonalInfoPage.CreateDefaultPersonal(driver)
                .withName("Tonny", "Run")
                .UseParameters()
                .UseParametersDoB()
                .UseParametersID()
                .UseParametersAddress()
                .UseParametersAPT()
                .UseParametersMovinDate()
                .UseParametersMobilePhone()
                .Submit();
            result = VerifyURL.ValidateURL(driver, "https://secure.aviocredit.com.train/LoanApplication/Income");
            Assert.IsTrue(result);
        }
       /* [Test]
        public void NegativeSubmit()
        {
            PersonalInfoPage.CreateDefaultPersonal(driver);
            result = VerifyURL.ValidateURL(driver, "https://secure.aviocredit.com.train/LoanApplication/Income");
            Assert.IsFalse(result);
        }
       
        //email should be new everytime you wanna run each test 
        
        [Test] 
        public void WithoutSSN()
        {
            PersonalInfoPage PIP = new PersonalInfoPage(driver);
            PIP.withSSN("");

            PersonalInfoPage.CreateDefaultPersonal(driver).Submit();
            result = VerifyURL.ValidateURL(driver, "https://secure.aviocredit.com.train/LoanApplication/Income");
            Assert.IsFalse(result);
        }
       */ 
        [TearDown]
        public void TearDown()
        {

        }

    }
}

