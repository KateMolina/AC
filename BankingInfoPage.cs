using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using Microsoft.SqlServer;

namespace avioCreditSelenium

{
    class BankingInfoPage
    {
        public String routing, account, account2, monthValue, yearValue, ccnumber;

        public static BankingInfoPage CreateDefaultBanking(IWebDriver driver)
        {
            BankingInfoPage BIP = new BankingInfoPage(driver);
            return BIP.withRouting("071000013")
                .withAccount("476537634")
                .withAccount2("476537634");
        }
        public static BankingInfoPage CreateDefaultBanking2(IWebDriver driver)
        {
            BankingInfoPage BIP = new BankingInfoPage(driver);
            return BIP.withCardNumber("7400767392370581")
                .withExpDate("5", "2021");
        }

        private IWebDriver driver;

        public BankingInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "BankAccount_TransitNumber")]
        public IWebElement RoutingNum { get; set; }

        [FindsBy(How = How.Id, Using = "BankAccount_AccountNumber")]
        public IWebElement AccountNum { get; set; }

        [FindsBy(How = How.Id, Using = "BankAccount_AccountNumberVerify")]
        public IWebElement AccountNumVerify { get; set; }

        [FindsBy(How = How.Id, Using = "btn-get-test-card")]
        [CacheLookup]
        public IWebElement GetTestCard { get; set; }

        [FindsBy(How = How.Id, Using = "btnSelectCard1")]
        [CacheLookup]
        public IWebElement Card { get; set; }

        [FindsBy(How = How.Id, Using = "Card_Number")]
        public IWebElement CardNumber { get; set; }

        [FindsBy(How = How.Name, Using = "Card.Expiry.Month")]
        public IWebElement ExpMonth { get; set; }

        [FindsBy(How = How.Name, Using = "Card.Expiry.Year")]
        public IWebElement ExpYear { get; set; }

        [FindsBy (How = How.ClassName, Using = "close")]
        public IWebElement CloseWindow { get; set; }

       // [FindsBy(How = How.XPath, Using = "//* [@id='btnNext']")]
       [FindsBy(How = How.Id, Using = "btnNext")]
       [CacheLookup]
        public IWebElement SbmtNext { get; set; }



        public BankingInfoPage withRouting(String routing)
        {
            this.routing = routing;
            return this;
        }
        public BankingInfoPage withAccount(String account)
        {
            this.account = account;
            return this;
        }
        public BankingInfoPage withAccount2(String account2)
        {
            this.account2 = account2;
            return this;
        }
        public BankingInfoPage withExpDate(String monthValue, String yearValue)
        {
            this.monthValue = monthValue;
            this.yearValue = yearValue;
            return this;
        }

     

        public BankingInfoPage UseBankNums()
        {
            RoutingNum.SendKeys(routing);
            AccountNum.SendKeys(account);
            AccountNumVerify.SendKeys(account2);
            return this;
        }
        public BankingInfoPage UseCard()
        {
            SelectElement month = new SelectElement(ExpMonth);
            month.SelectByValue(monthValue);
            SelectElement year = new SelectElement(ExpYear);
            year.SelectByText(yearValue);
            CardNumber.SendKeys(ccnumber);
            return this;
        }

        public BankingInfoPage ClickTestCard()
        {
            IJavaScriptExecutor jse2 = (IJavaScriptExecutor)driver;
            jse2.ExecuteScript("arguments[0].scrollIntoView()", GetTestCard);
            GetTestCard.Click();
            return this;
        }

        public BankingInfoPage withCardNumber(String ccnumber)
        {
            this.ccnumber = ccnumber;
            return this;
        }

        public BankingInfoPage withCard()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Card));
            Card.Click();

           
            return this;
        }

           public BankingInfoPage withCloseWindow()
             {
          //  WebDriverWait wait0 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // wait0.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("button[class='close']"))); 
            IJavaScriptExecutor jse5 = (IJavaScriptExecutor)driver;
            jse5.ExecuteScript("arguments[0].scrollIntoView()", CloseWindow);
            CloseWindow.Click();
                 return this;
             }
             

        public BankingInfoPage ClickNext()
        {
            IJavaScriptExecutor jse4 = (IJavaScriptExecutor)driver;
            jse4.ExecuteScript("arguments[0].scrollIntoView()", SbmtNext);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnNext")));
            SbmtNext.Click();
            return this;
        }

    }
}
