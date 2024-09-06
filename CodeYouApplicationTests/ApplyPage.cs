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
        public string ExpectedIntroText => "Please use this form to sign-up for Code:You. Applicants will be sent pre-work for the course on a rolling basis until spots are filled. Please note we have a considerable waiting list to get into the program – it could be many months (even a year or more) before your spot comes up in line.\r\n\r\nApplicants will be contacted to complete the necessary pre-work for the upcoming course a month or two before the class is slated to begin. Please check your email and be sure to whitelist info@code-you.org to receive periodic updates from our team.\r\n  \r\nIMPORTANT NOTE: Due to overwhelming interest in the program, we have a very long waiting list to get into the program. Sometimes a year or even more. Please be patient, but in the meantime you are welcome to contact info@code-you.org for any questions.";

        // Field Selectors
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
        public IWebElement ZipCodeTextbox => _driver.FindElement(By.Id("tfa_9"));
        public IWebElement CountyDropdown => _driver.FindElement(By.Id("tfa_59"));
        public IWebElement IndianaCountiesGroup => _driver.FindElement(By.Id("tfa_663"));
        public IWebElement KentuckyCountiesGroup => _driver.FindElement(By.Id("tfa_666"));
        public IWebElement OhioCountiesGroup => _driver.FindElement(By.Id("tfa_684"));
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
