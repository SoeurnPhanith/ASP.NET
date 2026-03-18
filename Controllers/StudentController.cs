using dotnet_db_api.Data;
using dotnet_db_api.Model;
using dotnet_db_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_db_api.Controller;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    //inject data from service who manage login code
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public IActionResult CreateStudent([FromBody]Student student)
    {
        var s = _studentService.CreateStudent(student);
        return Created("Student Created", s);
    }

    [HttpGet]
    public IActionResult GetAllStudent()
    {
        return Ok(_studentService.GetAllStudent());
    }

    [HttpGet("{id}")]
    public IActionResult GetOneStudent(int id)
    {
        Student oneStudent = _studentService.GetOneUser(id);
        return (oneStudent == null) ? NotFound("Student not found") : Ok(oneStudent);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] Student student)
    {
        return Ok(_studentService.UpdateStudent(id, student));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentService.DeleteStudent(id);
        return Ok("Student Deleted");
    }
}