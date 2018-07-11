using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace avioCreditSelenium
{
    [TestFixture]
    public class IncomeInfoPageTests
    {
        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
            AccountInfoPage.CreateDefaultAccount(driver).IDCredentials().Submit();
            PersonalInfoPage.CreateDefaultPersonal(driver).UseParameters().UseParametersDoB().UseParametersID().UseParametersAddress().UseParametersAPT().UseParametersMovinDate().UseParametersMobilePhone().Submit();
            
        }

        [Test]
        public void PositiveTest()
        {

            IncomeInfoPage.CreateDefaultIncome(driver)
                .withEmployerNamePhone("Curo", "7797463362")
                .UseParametersSourceOfIncome()
                .UseParamatersEmployerNamePhone()
                .UseParametersHireDate()
                .UseParametersPaycycle();
            IncomeInfoPage.CreateDefaultIncome2(driver)
                .withGrossNetPay("4000", "3000")
                .UseParametersGrossNetPay()
               .Submit();
        }
    }

}
