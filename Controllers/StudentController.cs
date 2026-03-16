using demo_dotnet_api.Entities;
using demo_dotnet_api.service;
using Microsoft.AspNetCore.Mvc;

namespace demo_dotnet_api.Controllers;

[ApiController] //Tell dotnet it is a class controller
[Route("api/v2/[controller]")]
public class StudentController : ControllerBase 
/*ControllerBase is a class use for customize messages and status codes
 , All controllers have consistent response format and in Spring boot is use ResponseEntity<T>
 but in ControllerBase class is always use interface IActionResult for method return type*/
{
    
    //inject data from Service to Controller
    private readonly IStudentServices _studentServices;
    public StudentController(IStudentServices studentServices)
    {
        this._studentServices = studentServices;
    }
    
    [HttpGet]
    public IActionResult GetAllStudents() => Ok(_studentServices.GetAllStudents());

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentServices.GetStudentById(id);
        return student == null ? NotFound("Student not found") : Ok(student);
    }

    [HttpPost]
    public IActionResult CreateStudent([FromBody] Student student)
    {
        if (_studentServices.ExistsByEmail(student.Email))
        {
            return Conflict("Email already exists");
        }
        Student create = _studentServices.CreateStudent(student);
        return Created("student created successfully", create);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] Student student)
    {   
        bool updated = _studentServices.UpdateStudent(id, student);
        return updated? Ok("Student updated successfully") : NotFound("Student not found");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        bool removed = _studentServices.DeleteStudentById(id);
        return removed ? Ok("Student deleted successfully") : NotFound("Student not found");
    }
}