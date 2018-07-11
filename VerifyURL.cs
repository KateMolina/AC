using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avioCreditSelenium
{
    public class VerifyURL
    {
       
        public static Boolean ValidateURL(IWebDriver driver, String ExpURL)
        {
            return (driver.Url.Equals(ExpURL));
        }
    }
}
