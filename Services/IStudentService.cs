using dotnet_db_api.Model;

namespace dotnet_db_api.Services;

public interface IStudentService
{
    Student CreateStudent(Student student);
    List<Student> GetAllStudent();
    Student GetOneUser(int id);
    Student UpdateStudent(int id, Student student);
    
    void DeleteStudent(int id);
}