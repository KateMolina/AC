using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avioCreditSelenium
{
    class ReviewIncomePage
    {
        public ReviewIncomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "Action")]
        public IWebElement BtnNext { get; set; }


        public ReviewIncomePage SubmitBthNext()
        {
            IJavaScriptExecutor jse6 = (IJavaScriptExecutor)driver;
            jse6.ExecuteScript("arguments[0].scrollIntoView()", BtnNext);
            BtnNext.Click();
            return this;
        }

        


    }
}
