namespace SchoolAdministration.UnitTest;

[TestClass]
public class CourseNumberGeneratorTests
{
    private readonly CourseNumberGenerator _sut;

    public CourseNumberGeneratorTests()
    {
        _sut = new CourseNumberGenerator();
    }

    [TestMethod]
    public void GenerateCourseNumber_ValidInput_ReturnsExpectedValue()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2024, 9, 1);
        string courseName = "Mathematics";
        ushort level = 3;
        string className = "B";
        // Expected: startYear = "23", endYear = "24", code = "MAT", level = 3, className = "B"

        string expected = "2425-MAT-3B";
        // Act
        string result = _sut.GenerateCourseNumber(startDate, courseName, level, className);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_StartDateBeforeAllowed_ThrowsArgumentException()
    {
        // Arrange
        // Assuming the rule is: startDate must be >= Jan 1 of last year.
        // If today is 2023, a start date in 2021 is invalid.
        DateOnly invalidStartDate = new DateOnly(2021, 12, 31);
        string courseName = "History";
        ushort level = 2;
        string className = "A";

        // Act
        _sut.GenerateCourseNumber(invalidStartDate, courseName, level, className);

        // Assert is handled by ExpectedException
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_CourseNameTooShort_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2023, 9, 1);
        string shortCourseName = "AB"; // less than 3 letters
        ushort level = 2;
        string className = "A";

        // Act
        _sut.GenerateCourseNumber(startDate, shortCourseName, level, className);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_LevelOutOfRange_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2023, 9, 1);
        string courseName = "History";
        ushort invalidLevel = 6; // level must be between 1 and 5
        string className = "A";

        // Act
        _sut.GenerateCourseNumber(startDate, courseName, invalidLevel, className);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_InvalidClassName_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2023, 9, 1);
        string courseName = "History";
        ushort level = 2;
        string invalidClassName = "D"; // allowed values are "A", "B", or "C"

        // Act
        _sut.GenerateCourseNumber(startDate, courseName, level, invalidClassName);
    }
}
