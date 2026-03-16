using demo_dotnet_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace demo_dotnet_api.Controllers;

[ApiController] //Tell dotnet it is a class controller
[Route("api/v2/[controller]")]
public class StudentController : ControllerBase 
/*ControllerBase is a class use for customize messages and status codes
 , All controllers have consistent response format and in Spring boot is use ResponseEntity<T>
 but in ControllerBase class is always use interface IActionResult for method return type*/
{
    private static readonly List<Student> allStudent = new()
    {
        new Student(1, "Soeurn", "Phanith", "phanithsoeurn371@gmail.com",new DateTime(2006,11,16)),
        new Student(2, "Soeurn", "Channen", "channen11@gmail.com",new DateTime(2010,10,05)),
        new Student(3, "Soeurn", "Chananna", "anansoeurn@gmail.com",new DateTime(2016,06,16)),
    };
    
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        if (!allStudent.Any())
        {
            return NotFound("No students found.");
        }
        return Ok(allStudent);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        if (!allStudent.Any())
        {
            return NotFound("No student found.");
        }
        
        Student student = allStudent.FirstOrDefault(s => s.StudentId.Equals(id));
        if (student.Equals(null))
        {
            return NotFound("student not found.");
        }
        return Ok(student); 
    }
}