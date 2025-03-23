namespace SchoolAdministration.Exceptions;

internal class StudentNotFoundException : Exception
{
    public StudentNotFoundException(Guid studentNumber) : base($"Student with studentnumber {studentNumber} not found!")
    {
    }
}
