using OpenQA.Selenium;

namespace CodeYouApplicationTests
{
    public class ApplyPage
    {
        private readonly IWebDriver _driver;
        private readonly SeleniumHelpers _seleniumHelpers;

        public ApplyPage(IWebDriver driver, SeleniumHelpers seleniumHelpers)
        {
            _driver = driver;
            _seleniumHelpers = seleniumHelpers;
        }

        public string ApplyPageUrl => "https://code-you.org/apply/";
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
        public IWebElement FluentInEnglishDropdown => _driver.FindElement(By.Id("tfa_49"));
        public IWebElement WorkAuthorizationDropdown => _driver.FindElement(By.Id("tfa_821"));
        public IWebElement VeteranStatusDropdown => _driver.FindElement(By.Id("tfa_54"));
        public IWebElement LGBTQDropdown => _driver.FindElement(By.Id("tfa_1255"));
        public IWebElement DisabilityDropdown => _driver.FindElement(By.Id("tfa_1065"));
        public IWebElement EmploymentStatusDropdown => _driver.FindElement(By.Id("tfa_105"));
        public IWebElement DetailedUnemploymentStatusDropdown => _driver.FindElement(By.Id("tfa_785"));
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

        // Error Selectors
        public IWebElement BirthdateError => _driver.FindElement(By.Id("tfa_5-HH"));

        // Expected Error Values
        public string GetExpectedFormSubmissionErrorAlertText(int expectedErrorCount) => $"The form is not complete and has not " +
                        $"been submitted yet. There are {expectedErrorCount} problems with your submission.";
        public string GetTooYoungErrorAlertText()
        {
            var oldestValidBirthdate = DateTime.Now.AddYears(-99).ToString("MM/dd/yyyy");
            var youngestValidBirthdate = DateTime.Now.AddYears(-18).ToString("MM/dd/yyyy");
            return $"This date must be between {oldestValidBirthdate} - {youngestValidBirthdate}.";
        }

        public string ExpectedInvalidDateErrorText => "This does not appear to be a valid date.";


        public IList<Applicant> Applicants => [
            new Applicant
            {
                Email = "tester_king_marlon@testinggrounds.com",
                FirstName = "Marlon",
                LastName = "Testerino",
                PreferredName = "Moze",
                PhoneNumber = "555-123-9876",
                BirthDate = DateTime.Parse("12/13/2001"),
                StreetAddress = "8324 Wiley Ave",
                City = "Tester Town",
                State = "IN",
                ZipCode = "33219",
                County = "Crawford",
                Gender = "Male",
                Race = ["Black or African American"],
                FluentInEnglish = true,
                AuthorizedToWorkInTheUS = true,
                VeteranStatus = false,
                HasDisability = true,
                IdentifiesAsLGBTQ = true,
                EmploymentStatus = "Unemployed, actively seeking work",
                UnemploymentStatus = "Long Term Unemployed (26+ weeks)",
                SeekingTechEmployment = TechEmploymentStatus.ExploringOptions,
                FelonyConviction = false,
                QualifiesForGovernmentAssistance = true,
                GovernmentAssistanceTypes = new Dictionary<string, bool>
            {
                { "SNAP", true },
                { "Unemployment Insurance", false },
                { "Medicaid", true },
                { "TANF", false },
                { "SSI", true },
            },
                HousingSituation = HousingType.FamilyOrFriend,
                HighestEducationCompleted = "GED",
                EnrolledInCollege = false,
                SubstanceAbuseHistory = true,
                OwnLaptopOrDesktop = false,
                HasStableInternetAccess = true,
                ComputerSkillLevel = 2,
                WillCommitRecommendedHours = true
            },
            new Applicant
            {
                Email = "jenny.tester@testinggrounds.com",
                FirstName = "Jenny",
                LastName = "Tester",
                PhoneNumber = "555-555-1234",
                BirthDate = DateTime.Parse("03/21/1998"),
                StreetAddress = "1620 N Main",
                City = "Dullsville",
                State = "KY",
                ZipCode = "33219",
                County = "Bell",
                Gender = "Female",
                Race = ["White", "Asian"],
                FluentInEnglish = true,
                AuthorizedToWorkInTheUS = true,
                VeteranStatus = true,
                HasDisability = false,
                EmploymentStatus = "Employed full-time",
                SeekingTechEmployment = TechEmploymentStatus.SeekingTechJob,
                QualifiesForGovernmentAssistance = false,
                HousingSituation = HousingType.Own,
                HighestEducationCompleted = "Bachelor’s Degree",
                EnrolledInCollege = false,
                SubstanceAbuseHistory = false,
                OwnLaptopOrDesktop = true,
                HasStableInternetAccess = true,
                ComputerSkillLevel = 5,
                WillCommitRecommendedHours = true
            },
            new Applicant
            {
                Email = "markanthony8303@testinggrounds.com",
                FirstName = "Mark",
                LastName = "Caldwell",
                PreferredName = "Tony",
                PhoneNumber = "555-111-9074",
                BirthDate = DateTime.Parse("09/14/2003"),
                StreetAddress = "610 Martin Ln",
                City = "Test City",
                State = "OH",
                ZipCode = "80025",
                County = "Warren",
                Gender = "Male",
                Race = ["White"],
                FluentInEnglish = true,
                AuthorizedToWorkInTheUS = true,
                VeteranStatus = false,
                HasDisability = true,
                IdentifiesAsLGBTQ = false,
                EmploymentStatus = "Unemployed, actively seeking work",
                UnemploymentStatus = "Long Term Unemployed (26+ weeks)",
                SeekingTechEmployment = TechEmploymentStatus.ExploringOptions,
                QualifiesForGovernmentAssistance = true,
                GovernmentAssistanceTypes = new Dictionary<string, bool>
                {
                    { "SNAP", true },
                    { "Unemployment Insurance", true },
                    { "Medicaid", false },
                    { "TANF", false },
                    { "SSI", false },
                },
                HousingSituation = HousingType.Own,
                HighestEducationCompleted = "Associate’s Degree",
                EnrolledInCollege = false,
                SubstanceAbuseHistory = false,
                OwnLaptopOrDesktop = true,
                HasStableInternetAccess = true,
                ComputerSkillLevel = 3,
                WillCommitRecommendedHours = true
            },
        ];

        public void FillAllFieldsAs(Applicant applicant)
        {
            FillOptionalFieldsAs(applicant);
            FillRequiredFieldsAs(applicant);
        }

        public void FillRequiredFieldsAs(Applicant applicant)
        {
            FillTextFields(applicant);
            SelectDropdownItems(applicant);
            SelectCheckboxesAndRadioButtons(applicant);
        }

        public void SubmitApplication()
        {
            _seleniumHelpers.ScrollToElement(SubmitButton);
            SubmitButton.Click();
        }

        private void FillTextFields(Applicant applicant)
        {
            EmailTextbox.SendKeys(applicant.Email);
            FirstNameTextbox.SendKeys(applicant.FirstName);
            LastNameTextbox.SendKeys(applicant.LastName);
            PhoneNumberTextbox.SendKeys(applicant.PhoneNumber);
            BirthDateTextbox.SendKeys(applicant.BirthDate.ToString("MM/dd/yyyy"));
            StreetTextbox.SendKeys(applicant.StreetAddress);
            CityTextbox.SendKeys(applicant.City);
            ZipCodeTextbox.SendKeys(applicant.ZipCode);

        }

        private void SelectDropdownItems(Applicant applicant)
        {
            _seleniumHelpers.SelectDropdownItemWithText(StateDropdown,
                applicant.State);
            _seleniumHelpers.SelectDropdownItemWithText(CountyDropdown,
                applicant.County);
            _seleniumHelpers.SelectDropdownItemWithText(GenderDropdown,
                applicant.Gender);
            _seleniumHelpers.SelectDropdownItemWithText(FluentInEnglishDropdown,
                BoolToYesNo(applicant.FluentInEnglish));
            _seleniumHelpers.SelectDropdownItemWithText(WorkAuthorizationDropdown,
                BoolToYesNo(applicant.AuthorizedToWorkInTheUS));
            _seleniumHelpers.SelectDropdownItemWithText(VeteranStatusDropdown,
                BoolToYesNo(applicant.VeteranStatus));
            _seleniumHelpers.SelectDropdownItemWithText(DisabilityDropdown,
                BoolToYesNo(applicant.HasDisability));
            _seleniumHelpers.SelectDropdownItemWithText(EmploymentStatusDropdown, applicant.EmploymentStatus);

            if (DetailedUnemploymentStatusDropdown.Displayed)
            {
                _seleniumHelpers.SelectDropdownItemWithText(DetailedUnemploymentStatusDropdown,
                    applicant.UnemploymentStatus);
            }

            _seleniumHelpers.SelectDropdownItemWithText(CurrentOrSeekingTechJobDropdown,
                EmploymentStatusToString(applicant.SeekingTechEmployment));
            _seleniumHelpers.SelectDropdownItemWithText(GovernmentAssistanceDropdown,
                BoolToYesNo(applicant.QualifiesForGovernmentAssistance));
            _seleniumHelpers.SelectDropdownItemWithText(HousingSituationDropdown,
                HousingTypeToString(applicant.HousingSituation));

            _seleniumHelpers.SelectDropdownItemWithText(EducationLevelDropdown,
                applicant.HighestEducationCompleted);
            _seleniumHelpers.SelectDropdownItemWithText(CollegeOrDegreePursuitDropdown,
                BoolToYesNo(applicant.EnrolledInCollege));
            _seleniumHelpers.SelectDropdownItemWithText(SubstanceAbuseDropdown,
                BoolToYesNo(applicant.SubstanceAbuseHistory));
            _seleniumHelpers.SelectDropdownItemWithText(LaptopOrDesktopOwnerDropdown,
                BoolToYesNo(applicant.OwnLaptopOrDesktop));
            _seleniumHelpers.SelectDropdownItemWithText(StableInternetDropdown,
                BoolToYesNo(applicant.HasStableInternetAccess));
            _seleniumHelpers.SelectDropdownItemWithText(TimeCommitmentDropdown,
                BoolToYesNo(applicant.WillCommitRecommendedHours));
        }

        private void SelectCheckboxesAndRadioButtons(Applicant applicant)
        {
            foreach (var race in applicant.Race)
            {
                _seleniumHelpers.SelectInputWithText(RaceCheckboxes, race);
            }
            _seleniumHelpers.SelectInputWithText(ComputerSkillRadioButtons,
                applicant.ComputerSkillLevel.ToString());
            SelectGovernmentAssistanceTypes(applicant);
        }

        private void SelectGovernmentAssistanceTypes(Applicant applicant)
        {
            // Government assistance selection requires a little more work
            // because the labels are wonky. The checkboxes have blank labels
            // connected to them, and the labels with text aren't linked to anything
            _seleniumHelpers.ScrollToElement(CurrentAssistanceCheckboxes);
            var labels = CurrentAssistanceCheckboxes.FindElements(By.XPath(".//child::label"))
                .Where(label => !string.IsNullOrWhiteSpace(label.Text))
                .Select(label => label.Text)
                .ToList();
            var assistanceCheckboxes = CurrentAssistanceCheckboxes.FindElements(By.XPath(".//child::input"));

            foreach (var assistanceType in applicant.GovernmentAssistanceTypes.Keys)
            {
                if (applicant.GovernmentAssistanceTypes[assistanceType])
                {
                    var index = labels.FindIndex(label => label == assistanceType);
                    assistanceCheckboxes[index].Click();
                }
            }
        }

        private void FillOptionalFieldsAs(Applicant applicant)
        {
            PreferredNameTextbox.SendKeys(applicant.PreferredName);
            _seleniumHelpers.SelectInputWithText(LGBTQDropdown,
                BoolToYesNo(applicant.IdentifiesAsLGBTQ));
            _seleniumHelpers.SelectInputWithText(FelonyConvictionDropdown,
                BoolToYesNo(applicant.FelonyConviction));
        }

        private static string BoolToYesNo(bool input)
        {
            return input ? "Yes" : "No";
        }

        private static string EmploymentStatusToString(TechEmploymentStatus input)
        {
            return input switch
            {
                TechEmploymentStatus.ExploringOptions => "I am exploring my options.",
                TechEmploymentStatus.CurrentlyEmployedInTech => "I am employed in the tech industry.",
                TechEmploymentStatus.SeekingTechJob => "I am seeking to enter the tech industry.",
                _ => "I am not seeking a job in the tech industry."
            };
        }

        private static string HousingTypeToString(HousingType input)
        {
            return input switch
            {
                HousingType.Own => "Own",
                HousingType.Rent => "Rent",
                HousingType.PublicOrSection8 => "Public Housing/Section 8",
                HousingType.Temp => "Temporary Housing",
                HousingType.Transitional => "Transitional Housing",
                HousingType.FamilyOrFriend => "Living with family/friend",
                HousingType.Shelter => "Shelter",
                HousingType.VeteranHousing => "Veteran Housing",
                _ => "Other"
            };
        }
    }
}
