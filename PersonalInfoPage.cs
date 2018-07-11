using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;




namespace avioCreditSelenium
{
    class PersonalInfoPage
    {
        String firstName, lastName, ssn, monthValue;
        String yearValue, idValue, idnumber, idStateValue, address;
        String city, stateValue, zip, aptValue, aptNumber, moveInMonthValue;
        String moveInYearValue, mobilePhoneNumber, homePhoneNumber;
        int dayValue;


        public static PersonalInfoPage CreateDefaultPersonal(IWebDriver driver)
        {
            PersonalInfoPage PIP = new PersonalInfoPage(driver);
            return PIP.withName("Larry", "Rregular")
            .withSSN("456550022")
            .withDOB("3", 6, "1995")
            .withID("2", "7564345437", "FL")
            .withNoMillitary()
            .withAddress("6301 w Berenice ave", "Huntsville", "AL", "35754")
            .withAPT("APT", "25")
            .withRentRadio()
            .withMovinDate("3", "2014")
            .withMobilePhone("4328765488");
        }
        
        public PersonalInfoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        private IWebDriver driver;

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement FirsNameElement { get; set; }

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement LastNameElement { get; set; }

        [FindsBy(How = How.Id, Using = "NIN")]
        public IWebElement SSNElement { get; set; }

        [FindsBy(How = How.Name, Using = "BirthDate.Month")]
        public IWebElement DobMonthElement { get; set; }

        [FindsBy(How = How.Id, Using = "BirthDate_Day")]
        public IWebElement DobDayElement { get; set; }

        [FindsBy(How = How.Name, Using = "BirthDate.Year")]
        public IWebElement DobYearElement { get; set; }

        [FindsBy(How = How.Id, Using = "Identification_TypeKey")]
        public IWebElement IDType { get; set; }

        [FindsBy(How = How.Id, Using = "Identification_Number")]
        public IWebElement IDNumber { get; set; }

        [FindsBy(How = How.Id, Using = "Identification_State")]
        public IWebElement IDState { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[class = 'custom-control custom-radio mr-0']")]
        [CacheLookup]
        public IWebElement NoRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label [class = 'custom-control custom-radio']")]
        public IWebElement YesRadioBtn { get; set; }

        [FindsBy(How = How.Id, Using = "Address_Address")]
        public IWebElement AddressFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "Address_City")]
        public IWebElement CityFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "Address_State")]
        public IWebElement StateDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "Address.Zip")]
        public IWebElement ZipFieldElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[class='custom-control custom-radio col-5 col-md-3 mr-0']")]
        public IWebElement RentRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[class='custom - control custom - radio col - 5 col - md - 3']")]
        public IWebElement OwnRadioBtn { get; set; }

        [FindsBy(How = How.Id, Using = "Address_UnitType")]
        public IWebElement AptDropdownElement { get; set; }

        [FindsBy(How = How.Name, Using = "Address.UnitNumber")]
        public IWebElement AptFieldElement { get; set; }

        [FindsBy(How = How.Id, Using = "ResidenceSince_Month")]
        public IWebElement MoveInMonthdropdown { get; set; }

        [FindsBy(How = How.Name, Using = "ResidenceSince.Year")]
        public IWebElement MoveInYearDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "PrimaryPhone")]
        public IWebElement HomePhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "SecondaryPhone")]
        public IWebElement MobilePhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "btnNext")]
        [CacheLookup]
        public IWebElement Nextbtn { get; set; }




        public PersonalInfoPage withName(String firstName, String lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            return this;
        }
        public PersonalInfoPage withSSN(String ssn)
        {
            this.ssn = ssn;
            return this;
        }
      
        public PersonalInfoPage UseParameters()
        {
            FirsNameElement.SendKeys(firstName);
            LastNameElement.SendKeys(lastName);
            SSNElement.SendKeys(ssn);
            return this;
        }
        public PersonalInfoPage withDOB(String monthValue, int dayValue, String yearValue)
        {
            this.monthValue = monthValue;
            this.dayValue = dayValue;
            this.yearValue = yearValue;
            return this;
        }
        public PersonalInfoPage UseParametersDoB()
        {
            SelectElement month = new SelectElement(DobMonthElement);
            month.SelectByValue(monthValue);
            SelectElement day = new SelectElement(DobDayElement);
            day.SelectByIndex(dayValue);
            SelectElement year = new SelectElement(DobYearElement);
            year.SelectByText(yearValue);
            return this;
        }
        public PersonalInfoPage withID(String idValue, String idnumber, String idStateValue)
        {
            this.idValue = idValue;
            this.idnumber = idnumber;
            this.idStateValue = idStateValue;
            return this;
        }
        public PersonalInfoPage UseParametersID()
        {
            SelectElement id = new SelectElement(IDType);
            id.SelectByValue(idValue);
            IDNumber.SendKeys(idnumber);
            SelectElement idstate = new SelectElement(IDState);
            idstate.SelectByValue(idStateValue);
            return this;
        }
        public PersonalInfoPage withNoMillitary()
        {
            IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
            jse1.ExecuteScript("arguments[0].scrollIntoView()", NoRadioBtn);
            NoRadioBtn.Click();
            return this;
        }
        public PersonalInfoPage withAddress(String address, String city, String stateValue, String zip)
        {
            this.address = address;
            this.city = city;
            this.stateValue = stateValue;
            this.zip = zip;
            return this;
        }
        public PersonalInfoPage UseParametersAddress()
        {
            AddressFieldElement.SendKeys(address);
            CityFieldElement.SendKeys(city);
            SelectElement state = new SelectElement(StateDropdown);
            state.SelectByValue(stateValue);
            ZipFieldElement.SendKeys(zip);
            return this;
        }
        public PersonalInfoPage withAPT(String aptValue, String aptNumber)
        {
            this.aptValue = aptValue;
            this.aptNumber = aptNumber;
            return this;
        }

        public PersonalInfoPage UseParametersAPT()
        {
            SelectElement aptdropdown = new SelectElement(AptDropdownElement);
            aptdropdown.SelectByValue(aptValue);
            AptFieldElement.SendKeys(aptNumber);
            return this;
        }
        public PersonalInfoPage withRentRadio()
        {
            RentRadioBtn.Click();
            return this;
        }
        public PersonalInfoPage withMovinDate(String moveInMonthValue, String moveInYearValue)
        {
            this.moveInMonthValue = moveInMonthValue;
            this.moveInYearValue = moveInYearValue;
            return this;
        }
        public PersonalInfoPage UseParametersMovinDate()
        {
            SelectElement monthdropdown = new SelectElement(MoveInMonthdropdown);
            monthdropdown.SelectByValue(moveInMonthValue);
            SelectElement yeardropdown = new SelectElement(MoveInYearDropdown);
            yeardropdown.SelectByText(moveInYearValue);
            return this;
        }
        public PersonalInfoPage withMobilePhone(String mobilePhoneNumber)
        {
            this.mobilePhoneNumber = mobilePhoneNumber;
            return this;
        }
        public PersonalInfoPage UseParametersMobilePhone()
        {
            MobilePhoneField.SendKeys(mobilePhoneNumber);
            return this;
        }
        public PersonalInfoPage Submit()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", Nextbtn);
            Nextbtn.Click();
            return this;
        }

    }
}
        /*


           public PersonalInfoPage withName (String firstName, String lastName)
           {
               FirsNameElement.SendKeys(firstName);
               LastNameElement.SendKeys(lastName);
               return this;
           }
           public PersonalInfoPage withSSN(String ssn)
           {
               SSNElement.SendKeys(ssn);
               return this;
           }
           public PersonalInfoPage withDOB(String monthValue, int dayValue, String yearValue)
           {
               SelectElement month = new SelectElement(DobMonthElement);
               month.SelectByValue(monthValue);
               SelectElement day = new SelectElement(DobDayElement);
               day.SelectByIndex(dayValue);
               SelectElement year = new SelectElement(DobYearElement);
               year.SelectByText(yearValue);
               return this;
           }
           public PersonalInfoPage withID(String idValue, String idnumber, String idStateValue)
           {
               SelectElement id = new SelectElement(IDType);
               id.SelectByValue(idValue);
               IDNumber.SendKeys(idnumber);
               SelectElement idstae = new SelectElement(IDState);
               idstae.SelectByValue(idStateValue);
               return this;
           }

            public PersonalInfoPage withNoMillitary()
           {
               IJavaScriptExecutor jse1 = (IJavaScriptExecutor)driver;
               jse1.ExecuteScript("arguments[0].scrollIntoView()", NoRadioBtn);
               NoRadioBtn.Click();
               return this;
           }
           public PersonalInfoPage withYesMillitary()
           {
               IJavaScriptExecutor jse3 = (IJavaScriptExecutor)driver;
               jse3.ExecuteScript("arguments[0].scrollIntoView()", YesRadioBtn);
               YesRadioBtn.Click();
               return this;
           }
           public PersonalInfoPage withAddress(String address, String city, String stateValue, String zip)
           {
               AddressFieldElement.SendKeys(address);
               CityFieldElement.SendKeys(city);
               SelectElement state = new SelectElement(StateDropdown);
               state.SelectByValue(stateValue);
               ZipFieldElement.SendKeys(zip);
               return this;
           }
           public PersonalInfoPage withAPT(String aptValue, String aptNumber)
           {
               SelectElement aptdropdown = new SelectElement(AptDropdownElement);
               aptdropdown.SelectByValue(aptValue);
               AptFieldElement.SendKeys(aptNumber);
               return this;
           }
           public PersonalInfoPage withRentRadio()
           {
               RentRadioBtn.Click();
               return this;
           }
           public PersonalInfoPage withOwnRadio()
           {
               OwnRadioBtn.Click();
               return this;
           }
           public PersonalInfoPage withMovinDate(String moveInMonthValue, String moveInYearValue)
           {
               SelectElement monthdropdown = new SelectElement(MoveInMonthdropdown);
               monthdropdown.SelectByValue(moveInMonthValue);
               SelectElement yeardropdown = new SelectElement(MoveInYearDropdown);
               yeardropdown.SelectByText(moveInYearValue);
               return this;
           }
           public PersonalInfoPage withMobilePhone(String mobilePhoneNumber)
           {
               MobilePhoneField.SendKeys(mobilePhoneNumber);
               return this;
           }
           public PersonalInfoPage withHomePhone(String homePhoneNumber)
           {
               HomePhoneField.SendKeys(homePhoneNumber);
               return this;
           } 
           public PersonalInfoPage Submit(){
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].scrollIntoView()", Nextbtn);
            Nextbtn.Click();
            return this;
        }
       

    }
}

    */