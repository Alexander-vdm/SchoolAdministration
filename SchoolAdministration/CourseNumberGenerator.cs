namespace SchoolAdministration;

public class CourseNumberGenerator
{
    private const string allowedClassNames = "ABC";

    public string GenerateCourseNumber(DateOnly startDate, string courseName, ushort level, char classCode)
    {
        var now = DateTime.Now;

        if (startDate.Year < now.Year - 1)
        {
            var mindate = new DateTime(now.Year - 1, 1, 1);
            throw new ArgumentException($"{nameof(startDate)} {startDate} is before {mindate:dd/MM/yyyy}");
        }

        if ( courseName == null || courseName.Length < 3)
        {
            throw new ArgumentException($"{nameof(courseName)} {courseName} should contain at least 3 characters");
        }

        if (level < 1 || level >= 6)
        {
            throw new ArgumentException($"{nameof(level)} {level} must be grater than 0 and less or equal to 5");
        }


        if (!allowedClassNames.Contains(classCode)) 
        {
            throw new ArgumentException($"{nameof(classCode)} {classCode} is not allowed.");
        }

        string startYear = startDate.ToString("yy");
        string endYear = startDate.AddYears(1).ToString("yy");

        string code = courseName.Substring(0, 3).ToUpper();

        string courseNumber = $"{startYear}{endYear}-{code}-{level}{classCode}";
        return courseNumber;
    }
}
