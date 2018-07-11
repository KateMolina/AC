using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace avioCreditSelenium

{

    [TestFixture]
    public class BankingInfoPageTest
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
            AccountInfoPage.CreateDefaultAccount(driver).IDCredentials().Submit();
            PersonalInfoPage.CreateDefaultPersonal(driver).withName("Sarah", "Rain").withSSN("736021298").UseParameters().UseParametersDoB().UseParametersID().UseParametersAddress().UseParametersAPT().UseParametersMovinDate().UseParametersMobilePhone().Submit();
            IncomeInfoPage.CreateDefaultIncome(driver).UseParametersSourceOfIncome().UseParamatersEmployerNamePhone().UseParametersHireDate().UseParametersPaycycle();
            IncomeInfoPage.CreateDefaultIncome2(driver).UseParametersGrossNetPay().Submit();
            ReviewIncomePage RIP = new ReviewIncomePage(driver).SubmitBthNext();
        }



        [Test]
        public void PositiveTest()
        {
            BankingInfoPage.CreateDefaultBanking(driver).UseBankNums();
            BankingInfoPage.CreateDefaultBanking2(driver).UseCard().ClickNext();
        }


        [TearDown]
        public void TearDown()
        {

        }
    }
}
