using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace avioCreditSelenium

{
    
    [TestFixture]
    public class ReviewIncomePageTest
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
            AccountInfoPage.CreateDefaultAccount(driver).IDCredentials().Submit();
            PersonalInfoPage.CreateDefaultPersonal(driver).UseParameters().UseParametersDoB().UseParametersID().UseParametersAddress().UseParametersAPT().UseParametersMovinDate().UseParametersMobilePhone().Submit();
            IncomeInfoPage.CreateDefaultIncome(driver).UseParametersSourceOfIncome().UseParamatersEmployerNamePhone().UseParametersHireDate().UseParametersPaycycle();
            IncomeInfoPage.CreateDefaultIncome2(driver).UseParametersGrossNetPay().Submit();
        }



        [Test]
        public void PositiveTest()
        {
            ReviewIncomePage RIP = new ReviewIncomePage(driver);
            RIP.SubmitBthNext();
        }

       
        [TearDown]
        public void TearDown()
        {
           
        }
    }
}
