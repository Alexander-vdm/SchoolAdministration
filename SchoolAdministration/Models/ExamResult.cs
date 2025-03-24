namespace SchoolAdministration.Models;

internal sealed class ExamResult
{
    public ExamResult(Course course, Student student, bool hasPassed)
    {
        Course = course;
        Student = student;
        Result = hasPassed;
    }

    public Course Course { get; set; }

    public Student Student { get; set; }

    public bool Result { get; set; }
}
