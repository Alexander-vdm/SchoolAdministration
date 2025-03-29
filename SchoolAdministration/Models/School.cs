using SchoolAdministration.Enums;

namespace SchoolAdministration.Models;

internal sealed class School
{
    private readonly List<Student> _students = [];

    private readonly List<Course> _courses = [];

    public School(List<Course> courses)
    {
        _courses = courses;
    }

    public IReadOnlyList<Student> Students => _students.AsReadOnly();

    public IReadOnlyList<Course> Courses => _courses.AsReadOnly();


    public Student InscribeStudent(Person person, Guid courseId)
    {
        var course = _courses.Single(x => x.Id == courseId);

        var student = new Student(Guid.NewGuid())
        {
            FamilyName = person.FamilyName,
            FirstName = person.FirstName
        };

        student.AddCourse(course);
        course.AddStudent(student);

        _students.Add(student);

        return student;
    }

    public void InschribeToCourse(Guid studentNumber, Guid courseId)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var course = _courses.Single(x => x.Id == courseId);

        student.AddCourse(course);
        course.AddStudent(student);
    }

    public void TrySetExamResult(Guid studentNumber, Guid courseId, ExamResultEnum examResultEnum)
    {
        var student = _students.Single(x => x.StudentNumber == studentNumber);
        var course = student.TryGetCourse(courseId);
        if (course is null)
        {
            var existingExam = _courses.Single(x => x.Id == courseId);
            Console.WriteLine($"Could not find exam {existingExam} for student {student}");
            return;
        }

        var examResult = new ExamResult(course, student, examResultEnum);

        student.ReceiveExamResult(courseId, examResultEnum);
        course.ReportExamResult(student, examResultEnum);
    }
}
