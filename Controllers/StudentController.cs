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
        
        Student existingStudent = findStudentById(id);
        if (existingStudent.Equals(null))
        {
            return NotFound("No student found.");
        }
        return Ok(existingStudent); 
    }

    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student student)
    {
        if (existsByEmail(student.Email))
        {
            return NotFound("Email already exists. Try again later.");
        }
        
        //method Max is use for find max value id in all collection
        int newId = allStudent.Count > 0 ? allStudent.Max(s => s.StudentId) + 1 : 1;
        
        Student newStudent = new Student(
            newId,  
            student.FirstName,
            student.LastName,
            student.Email,
            student.DateOfBirth
        );
        allStudent.Add(newStudent);
        return Created("New Student created",newStudent);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] Student student)
    {
        Student existingStudent = findStudentById(id);
        if (existingStudent.Equals(null))
        {
            return NotFound("No student found.");
        }

        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.Email = student.Email;
        existingStudent.DateOfBirth = student.DateOfBirth;

        return Ok(existingStudent);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        Student remove = findStudentById(id);
        if (remove.Equals(null))
        {
            return NotFound("No student found.");
        }
        
        //remove from list
        allStudent.Remove(remove);
        return Ok("Removed student successfully");
    }

    
    ///This metho is use for find student by id
    /// if it exists it will return @data , otherwise return @null
    Student findStudentById(int id)
    {
        Student existingStudent = allStudent.FirstOrDefault(s => s.StudentId == id);
        return existingStudent;
    }

    ///This method is use for check exists student in collection or not
    /// if it exists return @true and if not return @false
    bool existsByEmail(string email)
    {
        return allStudent.Any(exists => exists.Email == email);
    }
    
    
    
}