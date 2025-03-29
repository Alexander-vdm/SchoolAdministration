namespace SchoolAdministration;

public class CourseNumberGenerator
{
    public string GenerateCourseNumber(DateOnly startDate, string courseName, ushort level, string className)
    {
        var now = DateTime.Now;

        if (startDate.Year < now.Year - 1)
        {
            var mindate = new DateTime(now.Year - 1, 1, 1);
            throw new ArgumentException($"{nameof(startDate)} is before {mindate:dd/MM/yyyy}");
        }

        string startYear = startDate.ToString("yy");
        string endYear = startDate.AddYears(1).ToString("yy");
        string code = courseName.Substring(0, 3).ToUpper();

        string courseNumber = $"{startYear}{endYear}-{code}-{level}{className}";
        return courseNumber;
    }
}
