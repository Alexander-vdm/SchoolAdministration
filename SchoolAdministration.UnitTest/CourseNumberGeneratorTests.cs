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
        char classCode = 'B';

        string expected = "2425-MAT-3B";

        // Act
        string result = _sut.GenerateCourseNumber(startDate, courseName, level, classCode);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_StartDateBeforeAllowed_ThrowsArgumentException()
    {
        // Arrange
        DateOnly invalidStartDate = new DateOnly(2021, 12, 31);
        string courseName = "History";
        ushort level = 2;
        char classCode = 'A';

        // Act
        _sut.GenerateCourseNumber(invalidStartDate, courseName, level, classCode);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_CourseNameTooShort_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2024, 9, 1);
        string shortCourseName = "AB"; 
        ushort level = 2;
        char classCode = 'A';

        // Act
        _sut.GenerateCourseNumber(startDate, shortCourseName, level, classCode);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_LevelOutOfRange_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2024, 9, 1);
        string courseName = "History";
        ushort invalidLevel = 6;
        char classCode = 'A';

        // Act
        _sut.GenerateCourseNumber(startDate, courseName, invalidLevel, classCode);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GenerateCourseNumber_InvalidClassCode_ThrowsArgumentException()
    {
        // Arrange
        DateOnly startDate = new DateOnly(2024, 9, 1);
        string courseName = "History";
        ushort level = 2;
        char invalidclassCode = 'D';

        // Act
        _sut.GenerateCourseNumber(startDate, courseName, level, invalidclassCode);
    }
}
