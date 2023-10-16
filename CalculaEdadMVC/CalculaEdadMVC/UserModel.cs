using System;

namespace CalculaEdadMVC
{
    public class UserModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int CalculateAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - BirthDate.Year;

            if (now.Month < BirthDate.Month)
                --age;
            return age;
        }

        public AgeModel CalculateAgeMonthDay()
        {
            DateTime now = DateTime.Now;
            AgeModel age = new AgeModel()
            {
                Years = now.Year - BirthDate.Year,
                Months = now.Month - BirthDate.Month,
                Days = now.Day - BirthDate.Day
            };

            if (age.Days < 0)
            {
                age.Months--;
                age.Days += DateTime.DaysInMonth(now.Year, now.Month - 1);
            }
            if (age.Months < 0)
            {
                age.Years--;
                age.Months += 12;
            }

            return age;
        }
    }
}
