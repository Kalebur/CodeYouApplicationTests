using CodeYouApplicationTests.Data;
using Microsoft.VisualBasic;

namespace CodeYouApplicationTests.Helpers
{
    public class ApplicantHelpers
    {
        private readonly static DateTime _currentDate = DateTime.Now;
        private readonly static DateTime _oldestValidBirthdate = _currentDate.AddYears(-99);
        private readonly static DateTime _youngestValidBirthdate = _currentDate.AddYears(-18);
        private readonly static int _minPastYear = _currentDate.Year - 1000;
        private readonly static int _maxFutureYear = _currentDate.Year + 1000;

        public static DateTime GetRandomBirthDate(BirthdateType birthdateType)
        {
            var random = new Random();

            int year = birthdateType switch
            {
                BirthdateType.Valid => random.Next(_oldestValidBirthdate.Year, _youngestValidBirthdate.Year),
                BirthdateType.Future => random.Next(_currentDate.Year, _maxFutureYear),
                BirthdateType.Under18 => random.Next(_youngestValidBirthdate.Year, _currentDate.Year),
                _ => random.Next(_minPastYear, _oldestValidBirthdate.Year)
            };

            var day = 1;
            var month = random.Next(1, 13);
            if (month == 2)
            {
                if (IsLeapYear(year))
                {
                    day = random.Next(1, 30);
                }
                else
                {
                    day = random.Next(1, 29);
                }
            }
            else if (month == 4 || month == 6
                || month == 9 || month == 11)
            {
                day = random.Next(1, 31);
            }
            else
            {
                day = random.Next(1, 32);
            }

            var newBirthdate = DateTime.Parse($"{month}-{day}-{year}");
            while (!BirthDateIsOfType(newBirthdate, birthdateType))
            {
                newBirthdate = GetRandomBirthDate(birthdateType);
            }

            return newBirthdate;
        }

        private static bool BirthDateIsOfType(DateTime birthDate, BirthdateType expectedType)
        {
            return expectedType switch
            {
                BirthdateType.Valid => birthDate >= _oldestValidBirthdate && birthDate <= _youngestValidBirthdate,
                BirthdateType.Future => birthDate > _currentDate,
                BirthdateType.Under18 => birthDate > _youngestValidBirthdate && birthDate <= _currentDate,
                _ => birthDate < _oldestValidBirthdate,
            };
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 == 0 && year % 100 != 0)
            {
                return true;
            }
            if (year % 4 == 0 && year % 100 == 0)
            {
                if (year % 400 == 0) return true;
                else return false;
            }

            return false;
        }
    }
}
