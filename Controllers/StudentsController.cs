using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace StudentsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetStudents()
    {
        // Dummy data for demonstration purposes
        var students = new List<Student>
        {
            new Student { Name = "John Doe", Marks = 90 },
            new Student { Name = "Jane Doe", Marks = 85 },
            new Student { Name = "Bob Smith", Marks = 78 }
            // Add more students as needed
        };

        return Ok(students);
    }

    public class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
    }
}
