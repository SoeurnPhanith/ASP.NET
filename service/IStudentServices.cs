using demo_dotnet_api.Entities;

namespace demo_dotnet_api.service;

public interface IStudentServices
{
    //Logic method
    Student GetStudentById(int id);
    List<Student> GetAllStudents();
    Student CreateStudent(Student student);
    bool UpdateStudent(int id,Student student);
    bool DeleteStudentById(int id);
    
    
    //heaper method
    Student findStudentById(int id);
    public bool ExistsByEmail(string email);
}