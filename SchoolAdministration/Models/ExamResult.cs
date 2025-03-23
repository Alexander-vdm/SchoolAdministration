namespace SchoolAdministration.Models;

internal class ExamResult
{
    public ExamResult(Exam exam, Student student, bool hasPassed)
    {
        Exam = exam;
        Student = student;
        Result = hasPassed;
    }

    public Exam Exam { get; set; }

    public Student Student { get; set; }

    public bool Result { get; set; }
}
