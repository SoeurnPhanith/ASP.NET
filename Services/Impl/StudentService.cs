using dotnet_db_api.Model;
using dotnet_db_api.Repository;

namespace dotnet_db_api.Services;

public class StudentService : IStudentService
{
    //inject data from Repository who store query from LINQ query builder
    private readonly IStudentRepository _studentRepository;
    
    public  StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }


    public Student CreateStudent(Student student)
    {
        if (_studentRepository.ExistByEmail(student.Name))
        {
             throw new Exception("Student email already exists");
        }
        _studentRepository.Save(student);
        return student;
    }

    public List<Student> GetAllStudent()
    {
        return _studentRepository.FindAll();
    }

    public Student GetOneUser(int id)
    {
        return _studentRepository.FindById(id);
    }

    public Student UpdateStudent(int id, Student student)
    {
        Student find = _studentRepository.FindById(id);
        if (find == null)
        {
            throw new Exception("Student not found");
        }

        find.Name = student.Name;
        find.Email = student.Email;
        
        _studentRepository.Update(find);
        return find;
    }

    public void DeleteStudent(int id)
    {
         _studentRepository.DeleteById(id);
    }
}