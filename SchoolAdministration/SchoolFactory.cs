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
        var coursesPath = Path.Combine(testFilesPath, "courses.json");
        var peoplePath = Path.Combine(testFilesPath, "people.json");

        var coursesJson = File.ReadAllText(coursesPath);
        var courses = JsonSerializer.Deserialize<List<Course>>(coursesJson)!;

        var peopleJson = File.ReadAllText(peoplePath);
        var people = JsonSerializer.Deserialize<List<Person>>(peopleJson)!;

        var school = new School(courses);







        var rng = new Random();

        var inscribedStudents = new List<Student>();

        // Inscribe students
        foreach (var person in people)
        {
            var courseIndex = rng.Next(0, courses.Count);
            var course = courses[courseIndex];
            var student = school.InscribeStudent(person, course.CourseNumber);
            inscribedStudents.Add(student);
        }

        // student can inscribe to multiple courses
        for (var i = 0; i < 100; i++)
        {
            var studentIndex = rng.Next(0, inscribedStudents.Count);
            var courseIndex = rng.Next(0, courses.Count);

            var studentNumber = inscribedStudents[studentIndex].StudentNumber;
            var courseNumber = courses[courseIndex].CourseNumber;

            school.InschribeToCourse(studentNumber, courseNumber);
        }

        // populate exam results
        for (var i = 0; i < 100; i++)
        {
            var studentIndex = rng.Next(0, inscribedStudents.Count);
            var examIndex = rng.Next(0, courses.Count);

            var studentNumber = inscribedStudents[studentIndex].StudentNumber;
            var examNumber = courses[examIndex].CourseNumber;

            var result = rng.NextBoolean();

            school.TrySetExamResult(studentNumber, examNumber, result);
        }

        return school;
    }
}
