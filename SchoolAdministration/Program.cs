using SchoolAdministration;

// OOP and DDD

// Exceptions





var school = SchoolFactory.CreateSchool();

Console.ReadLine();


class StudentAlreadyInscribedException : Exception
{
    public StudentAlreadyInscribedException() : base("Student is already inscribed!")
    {
    }
}