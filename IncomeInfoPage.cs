using OpenQA.Selenium;
// using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace avioCreditSelenium
{
    class IncomeInfoPage
    {
        String IncomeValue, employerName, workPhone, hireMonthValue, hireYearValue, paycycleValue, gross, net;
        public static IncomeInfoPage CreateDefaultIncome(IWebDriver driver)
        {
            IncomeInfoPage IIP = new IncomeInfoPage(driver);
            return IIP.withSourseOfIncome("E")
                 .withEmployerNamePhone("Company", "7765526585")
                 .withHireDate("10", "2017")
                 .withPaycycle("BiWeekly");
        }
        public static IncomeInfoPage CreateDefaultIncome2(IWebDriver driver)
        {
            IncomeInfoPage IIP = new IncomeInfoPage(driver);
            return IIP.withLastPayDateDropdown()
                 .withDatePicker()
                 .withYesDirectDeposit()
                 .withMonthlyFrequency()
                 .withGrossNetPay("3000", "2600");
        }

        public IncomeInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "EditableIncome.IncomeTypeCode")] 
        public IWebElement SourceOfIncomeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_Employer")]
        public IWebElement EmployerNameField { get; set; }

        [FindsBy(How = How.Name, Using = "EditableIncome.WorkPhone")]
        public IWebElement WorkPhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_HireDate_Month")]
        public IWebElement HireDateMonthDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_HireDate_Year")]
        public IWebElement HireDateYearDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_PayCycle")]
        public IWebElement PaycycleDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_LastBiweeklyPayDate")]
        public IWebElement LastPayDateDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div[1]/table/tbody/tr[5]/td[1]")] 
        public IWebElement DateFromDatePicker { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[class='custom-control custom-radio']")]
        [CacheLookup]
        public IWebElement YesDirectDeposit { get; set; } 

        [FindsBy(How = How.CssSelector, Using = "input[value='false']")]
        public IWebElement NoDirectDeposit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Income']/div[4]/div[6]/div[2]/div/div/label[1]")]  
        [CacheLookup]
        public IWebElement MonthlyFrequency { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[class='custom-control custom-radio']")]
        public IWebElement PerPaycheckFrequency { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_GrossPay")]
        public IWebElement GrossPayField { get; set; }

        [FindsBy(How = How.Id, Using = "EditableIncome_NetPay")]
        public IWebElement NetPayField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[value = 'Save']")]
        public IWebElement Savebtn { get; set; }



        public IncomeInfoPage withSourseOfIncome(String IncomeValue)
        {
            this.IncomeValue = IncomeValue;
            
            return this;
        }
        public IncomeInfoPage UseParametersSourceOfIncome()
        {
            SelectElement SoI = new SelectElement(SourceOfIncomeDropdown);
            SoI.SelectByValue(IncomeValue);
            return this;
        }
        public IncomeInfoPage withEmployerNamePhone(String employerName, String workPhone)
        {
            this.employerName = employerName;
            this.workPhone = workPhone;
            return this;
        }
        public IncomeInfoPage UseParamatersEmployerNamePhone()
        {
            EmployerNameField.SendKeys(employerName);
            WorkPhoneField.SendKeys(workPhone);
            return this;
        }
        
        public IncomeInfoPage withHireDate(String hireMonthValue, String hireYearValue)
        {
            this.hireMonthValue = hireMonthValue;
            this.hireYearValue = hireYearValue;
            return this;
        }
        public IncomeInfoPage UseParametersHireDate()
        {
            SelectElement HDM = new SelectElement(HireDateMonthDropdown);
            HDM.SelectByValue(hireMonthValue);
            SelectElement HDY = new SelectElement(HireDateYearDropdown);
            HDY.SelectByText(hireYearValue);
            return this;
        }
       
        public IncomeInfoPage withPaycycle(String paycycleValue)
        {
            this.paycycleValue = paycycleValue;
            return this;
        }
        public IncomeInfoPage UseParametersPaycycle()
        {
            SelectElement PC = new SelectElement(PaycycleDropdown);
            PC.SelectByText(paycycleValue);
            return this;
        }
        public IncomeInfoPage withLastPayDateDropdown()
        {
            IJavaScriptExecutor jss = (IJavaScriptExecutor)driver;
            jss.ExecuteScript("arguments[0].scrollIntoView()", LastPayDateDropdown);
            LastPayDateDropdown.Click();
            return this;
        }
        public IncomeInfoPage withDatePicker()
        {
            DateFromDatePicker.Click();
            return this;
        }
        public IncomeInfoPage withYesDirectDeposit()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView()", YesDirectDeposit);
            YesDirectDeposit.Click();
            return this;
        }
        public IncomeInfoPage withNoDirectDeposit()
        {
            NoDirectDeposit.Click();
            return this;
        }
        public IncomeInfoPage withMonthlyFrequency()
        {
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("arguments[0].scrollIntoView()", MonthlyFrequency);
            MonthlyFrequency.Click();
            return this;
        }
        public IncomeInfoPage withPerPaycheckFrequency()
        {
            PerPaycheckFrequency.Click();
            return this;
        }
        public IncomeInfoPage withGrossNetPay(String gross, String net)
        {
            this.gross = gross;
            this.net = net;
            return this;
        }
        public IncomeInfoPage UseParametersGrossNetPay()
        {
            GrossPayField.SendKeys(gross);
            NetPayField.SendKeys(net);
            return this;
        }
        public IncomeInfoPage Submit()
        {
            Savebtn.Click();
            return this;
        }

    }

}