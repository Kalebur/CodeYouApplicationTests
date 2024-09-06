using OpenQA.Selenium;

namespace CodeYouApplicationTests
{
    public class ApplyPage
    {
        private readonly IWebDriver _driver;

        public ApplyPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Url => "https://code-you.org/apply/";
        public IWebElement IntroText => _driver.FindElement(By.Id("tfa_525-HTML"));
        public IWebElement EmailTextbox => _driver.FindElement(By.Id("tfa_215"));
        public IWebElement FirstNameTextbox => _driver.FindElement(By.Id("tfa_2"));
        public IWebElement LastNameTextbox => _driver.FindElement(By.Id("tfa_3"));
        public IWebElement PreferredNameTextbox => _driver.FindElement(By.Id("tfa_1230"));
        public IWebElement PhoneNumberTextbox => _driver.FindElement(By.Id("tfa_216"));
        public IWebElement BirthDateTextbox => _driver.FindElement(By.Id("tfa_5"));
        public IWebElement StreetTextbox => _driver.FindElement(By.Id("tfa_6"));
        public IWebElement CityTextbox => _driver.FindElement(By.Id("tfa_7"));
        public IWebElement StateDropdown => _driver.FindElement(By.Id("tfa_220"));
        public IWebElement IndianaCountiesGroup => _driver.FindElement(By.Id("tfa_663"));
        public IWebElement KentuckyCountiesGroup => _driver.FindElement(By.Id("tfa_666"));
        public IWebElement OhioCountiesGroup => _driver.FindElement(By.Id("tfa_684"));
        public IWebElement ZipCodeTextbox => _driver.FindElement(By.Id("tfa_9"));
        public IWebElement CountyDropdown => _driver.FindElement(By.Id("tfa_59"));
        public IWebElement GenderDropdown => _driver.FindElement(By.Id("tfa_30"));
        public IWebElement RaceCheckboxes => _driver.FindElement(By.Id("tfa_794"));
        public IWebElement FluentInEnglishDropdown => _driver.FindElement(By.Id("tfa_30"));
        public IWebElement WorkAuthorizationDropdown => _driver.FindElement(By.Id("tfa_821"));
        public IWebElement VeteranStatusDropdown => _driver.FindElement(By.Id("tfa_54"));
        public IWebElement LGBTQDropdown => _driver.FindElement(By.Id("tfa_1255"));
        public IWebElement DisabilityDropdown => _driver.FindElement(By.Id("tfa_1065"));
        public IWebElement EmploymentStatusDropdown => _driver.FindElement(By.Id("tfa_105"));
        public IWebElement CurrentOrSeekingTechJobDropdown => _driver.FindElement(By.Id("tfa_97"));
        public IWebElement FelonyConvictionDropdown => _driver.FindElement(By.Id("tfa_114"));
        public IWebElement GovernmentAssistanceDropdown => _driver.FindElement(By.Id("tfa_129"));
        public IWebElement CurrentAssistanceCheckboxes => _driver.FindElement(By.Id("tfa_510"));
        public IWebElement HousingSituationDropdown => _driver.FindElement(By.Id("tfa_1164"));
        public IWebElement EducationLevelDropdown => _driver.FindElement(By.Id("tfa_132"));
        public IWebElement CollegeOrDegreePursuitDropdown => _driver.FindElement(By.Id("tfa_147"));
        public IWebElement SubstanceAbuseDropdown => _driver.FindElement(By.Id("tfa_1250"));
        public IWebElement LaptopOrDesktopOwnerDropdown => _driver.FindElement(By.Id("tfa_150"));
        public IWebElement StableInternetDropdown => _driver.FindElement(By.Id("tfa_153"));
        public IWebElement ComputerSkillRadioButtons => _driver.FindElement(By.Id("tfa_1110"));
        public IWebElement TimeCommitmentDropdown => _driver.FindElement(By.Id("tfa_156"));
        public IWebElement AcknowledgementCheckbox => _driver.FindElement(By.Id("tfa_545"));
        public IWebElement SubmitButton => _driver.FindElement(By.Id("submit_button"));
    }
}
