using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace avioCreditSelenium
{
    [TestFixture]
    public class E2EAllPagesTest
    {/*

        public static IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.aviocredit.com.train/");
        }
        
        [Test]
        public static void E2EAll()
        {
            AccountInfoPage AIP = new AccountInfoPage(driver);

            AIP.ApplyBtn()
                 .withEmail("molinakate5@curo.com")
                 .withPassword("Speedy123$")
                 .withConfirmPassword("Speedy123$")
                 .withSequrityQuest("14")
                 .withSecurityAnswer("something")
                 .Submit();

            PersonalInfoPage PIP = new PersonalInfoPage(driver);
            /* PIP.FirsNameElement = "dfsdfds";
               PIP.SSN = "SDSFSA";
               PIP.PressSumbit();
               */

           /* 
            PIP.withName("Maria", "Raily")
                 .withSSN("456550011")
                 .withDOB("3", 6, "1994")
                 .withID("2", "7564346937", "FL")
                 .withNoMillitary()
                 .withAddress("6301 w Berenice ave", "Huntsville", "AL", "35754")
                 .withAPT("APT", "25")
                 .withRentRadio()
                 .withMovinDate("3", "2014")
                 .withMobilePhone("4328765488")
                 .Submit();


            IncomeInfoPage IIP = new IncomeInfoPage(driver);
            IIP.withSourseOfIncome("E")
                 .withEmployerName("Company")
                 .withWorkPhone("7765526585")
                 .withHireDateMonth("10")
                 .withHireDateYear("2017")
                 .withPaycycle("BiWeekly")
                 .withLastPayDateDropdown()
                 .withDatePicker()
                 .withYesDirectDeposit()
                 .withMonthlyFrequency()
                 .withGrossPay("3000")
                 .withNetPay("2600")
                 .withSubmitSave();


            ReviewIncomePage RIP = new ReviewIncomePage(driver);
            RIP.withBthNext();
            BankingInfoPage BIP = new BankingInfoPage(driver);
            BIP.withRoutingNum("071000013")
                .withAccountNum("439575649")
                .withAccountNumVerify("439575649")
                .withTestCard()
                .withCard()
                //.withCloseWindow()
                .withExpDate("5", "2021")
                 .withNextClick();


        }
        


        


        [TearDown]
        public void TearDown()
        {

        }
        */
    }
}
    
