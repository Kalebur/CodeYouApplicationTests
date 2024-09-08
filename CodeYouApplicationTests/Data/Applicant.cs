namespace CodeYouApplicationTests.Data
{
    public class Applicant
    {
        public Applicant()
        {
            Email = "tester@testingrounds.com";
            FirstName = "Test";
            LastName = "Testington";
            PreferredName = string.Empty;
            PhoneNumber = "555-555-5555";
            StreetAddress = "1428 Elm St";
            City = "Springwood";
            State = "OH";
            ZipCode = "86309";
            County = "Butler";
            Gender = "Male";
            Race = ["White"];
            EmploymentStatus = "Employed full-time";
            UnemploymentStatus = "Student";
            HighestEducationCompleted = "GED";
            FelonyConviction = false;
            IdentifiesAsLGBTQ = false;

        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string County { get; set; }
        public string Gender { get; set; }
        public List<string> Race { get; set; }
        public bool FluentInEnglish { get; set; }
        public bool AuthorizedToWorkInTheUS { get; set; }
        public bool VeteranStatus { get; set; }
        public bool IdentifiesAsLGBTQ { get; set; }
        public bool HasDisability { get; set; }
        public string EmploymentStatus { get; set; }
        public string UnemploymentStatus { get; set; }
        public TechEmploymentStatus SeekingTechEmployment { get; set; }
        public bool FelonyConviction { get; set; }
        public bool QualifiesForGovernmentAssistance { get; set; }
        public Dictionary<string, bool> GovernmentAssistanceTypes { get; set; } = [];
        public HousingType HousingSituation { get; set; }
        public string HighestEducationCompleted { get; set; }
        public bool EnrolledInCollege { get; set; }
        public bool SubstanceAbuseHistory { get; set; }
        public bool OwnLaptopOrDesktop { get; set; }
        public bool HasStableInternetAccess { get; set; }
        public int ComputerSkillLevel { get; set; }
        public bool WillCommitRecommendedHours { get; set; }
    }
}
