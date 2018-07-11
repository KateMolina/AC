using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;


namespace avioCreditSelenium
{
    class AccountInfoPage
    {
        
        private String password;
        private String confPass;
        private String value;
        private String answer;

             public static AccountInfoPage CreateDefaultAccount(IWebDriver driver)
             {
                 AccountInfoPage AIP = new AccountInfoPage(driver);

                 return AIP.ApplyBtn()
                      .GenerateEmail()
                      .withPassword("Speedy123$")
                      .withConfirmPassword("Speedy123$")
                      .withSequrityQuest("14")
                      .withSecurityAnswer("something");
             }
            
        public AccountInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        private IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Apply Now")]
        public IWebElement ApplyNowBtn { get; set; }

        [FindsBy(How = How.Name, Using = "AccountSecurity.Email")]
        public IWebElement EmailFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "AccountSecurity_Password")]
        public IWebElement PasswordFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "AccountSecurity_VerifyPassword")]
        public IWebElement ConfirmPasswordFieldElement { get; set; }

        [FindsBy(How = How.Name, Using = "AccountSecurity.SecurityQuestion")]
        public IWebElement SecurityQuestionElement { get; set; }

        [FindsBy(How = How.Name, Using = "AccountSecurity.SecurityAnswer")]
        public IWebElement AnswerFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "btnNext")]
        public IWebElement SubmitBtnElement { get; set; }

        
        public AccountInfoPage ApplyBtn()
        {
            ApplyNowBtn.Click();
            return this;
        }


       
        public AccountInfoPage withPassword(String password)
        {
            this.password = password;
            return this;
        }

        public AccountInfoPage withConfirmPassword(String confPass)
        {
            this.confPass = confPass;
            return this;
        }
        public AccountInfoPage withSequrityQuest(String value)
        {
            this.value = value;
            return this;
        }
        public AccountInfoPage withSecurityAnswer(String answer)
        {
            this.answer = answer;
            return this;
        }
        public AccountInfoPage Submit()
        {
            IJavaScriptExecutor jse6 = (IJavaScriptExecutor)driver;
            jse6.ExecuteScript("arguments[0].scrollIntoView()", SubmitBtnElement);
            SubmitBtnElement.Click();
            return this;
        }
        public AccountInfoPage IDCredentials()
        {
         //   EmailFieldElement.SendKeys(email);
            PasswordFieldElement.SendKeys(password);
            ConfirmPasswordFieldElement.SendKeys(confPass);
            SelectElement secquestion = new SelectElement(SecurityQuestionElement);
            secquestion.SelectByValue(value);
            AnswerFieldElement.SendKeys(answer);
            return this;
        }
        public AccountInfoPage GenerateEmail()
        {
            Guid guid = Guid.NewGuid();
            EmailFieldElement.SendKeys(guid.ToString() + "@curo.com");
            return this;
        }


        /*


        public AccountInfoPage withEmail(String email)
        {
            EmailFieldElement.SendKeys(email);
            return this;
        }
        public AccountInfoPage withPassword(String pass)
        {
            PasswordFieldElement.SendKeys(pass);
            return this;
        }
        public AccountInfoPage withConfirmPassword(String pass)
        {
            ConfirmPasswordFieldElement.SendKeys(pass);
            return this;
        }
        public AccountInfoPage withSequrityQuest(String value)
        {
            SelectElement secquestion = new SelectElement(SecurityQuestionElement);
            secquestion.SelectByValue(value);
            return this;
        }
        public AccountInfoPage withSecurityAnswer(String answer)
        {
            AnswerFieldElement.SendKeys(answer);
            return this;
        }
        public AccountInfoPage Submit()
        {
            IJavaScriptExecutor jse6 = (IJavaScriptExecutor)driver;
            jse6.ExecuteScript("arguments[0].scrollIntoView()", SubmitBtnElement);
            SubmitBtnElement.Click();
            return this;
        } 
        
    */


    }
}
