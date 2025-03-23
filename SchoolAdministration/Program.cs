using SchoolAdministration;

// Enums

// Guids

// OOP and DDD

// Exceptions


var school = SchoolFactory.CreateSchool();

// This does not work.  
var studentsWhoFailedAllExams = school.Students
    .Where(x => x.ExamResults.All(y => !y.Result))
    .ToList();

var studentsWhoSucceededAllExams = school.Students
    .Where(x => x.ExamResults.All(y => y.Result))
    .ToList();

var studentsWithDifferentResults = school.Students
    .Where(x => !x.ExamResults.All(y => y.Result) && !x.ExamResults.All(y => !y.Result))
    .ToList();

Console.ReadLine();