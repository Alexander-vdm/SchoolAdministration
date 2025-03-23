namespace SchoolAdministration.Exceptions;

internal class ExamNotFoundException : Exception
{
    public ExamNotFoundException(Guid examNumber) : base($"Exam with examnumber {examNumber} not found!")
    {
    }
}
