using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAdministration
{
    internal class CourseNumberGenerator
    {
        public string GenerateCourseNumber(DateOnly startDate, string courseName, ushort level, string className)
        {
            //int startYear = startDate.Year;
            //int endYear = startYear + 1;
            string startYear = startDate.ToString("yy");
            string endYear = startDate.AddYears(1).ToString("yy");
            string code = courseName.Substring(0, 3).ToUpper();

            string courseNumber = $"{startYear}{endYear}{code}{level}{className}";
            return courseNumber;
            
        }
    }
}
