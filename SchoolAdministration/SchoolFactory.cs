using SchoolAdministration.Extensions;
using SchoolAdministration.Models;
using System.Text.Json;

namespace SchoolAdministration;

internal static class SchoolFactory
{
    public static School CreateSchool()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var testFilesPath = Path.Combine(currentDirectory, "DemoFiles");
        var examsPath = Path.Combine(testFilesPath, "exams.json");
        var peoplePath = Path.Combine(testFilesPath, "people.json");

        var examsJson = File.ReadAllText(examsPath);
        var exams = JsonSerializer.Deserialize<List<Exam>>(examsJson)!;

        var peopleJson = File.ReadAllText(peoplePath);
        var people = JsonSerializer.Deserialize<List<Person>>(peopleJson)!;

        var school = new School(exams);
        var rng = new Random();

        var inscribedStudents = new List<Student>();

        // Inscribe students
        foreach (var person in people)
        {
            var examIndex = rng.Next(0, exams.Count);
            var exam = exams[examIndex];
            var student = school.InscribeStudent(person, exam.ExamNumber);
            inscribedStudents.Add(student);
        }

        // student can inscribe to multiple exams
        for (var i = 0; i < 100; i++)
        {
            var studentIndex = rng.Next(0, inscribedStudents.Count);
            var examIndex = rng.Next(0, exams.Count);

            var studentNumber = inscribedStudents[studentIndex].StudentNumber;
            var examNumber = exams[examIndex].ExamNumber;

            school.InschribeToExam(studentNumber, examNumber);
        }

        // populate exam results
        for (var i = 0; i < 100; i++)
        {
            var studentIndex = rng.Next(0, inscribedStudents.Count);
            var examIndex = rng.Next(0, exams.Count);

            var studentNumber = inscribedStudents[studentIndex].StudentNumber;
            var examNumber = exams[examIndex].ExamNumber;

            var result = rng.NextBoolean();

            school.TrySetExamResult(studentNumber, examNumber, result);
        }

        return school;
    }
}
