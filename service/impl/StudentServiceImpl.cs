using demo_dotnet_api.Entities;

namespace demo_dotnet_api.service.impl;

public class StudentServiceImpl : IStudentServices
{
    private static readonly List<Student> allStudent = new()
    {
        new Student(1, "Soeurn", "Phanith", "phanithsoeurn371@gmail.com",new DateTime(2006,11,16)),
        new Student(2, "Soeurn", "Channen", "channen11@gmail.com",new DateTime(2010,10,05)),
        new Student(3, "Soeurn", "Chananna", "anansoeurn@gmail.com",new DateTime(2016,06,16)),
    };
    public Student GetStudentById(int id)
    {
        return findStudentById(id);
    }

    public List<Student> GetAllStudents() => allStudent;

    public Student CreateStudent(Student student)
    {
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

        return newStudent;
    }

    public bool UpdateStudent(int id, Student student)
    {
        Student existsStudent = findStudentById(id);
        if (existsStudent == null) return false;
        
        existsStudent.FirstName = student.FirstName;
        existsStudent.LastName = student.LastName;
        existsStudent.Email = student.Email;
        existsStudent.DateOfBirth = student.DateOfBirth;
        return true;
    }

    public bool DeleteStudentById(int id)
    {
        Student student = findStudentById(id);
        if (student == null) return false;

        allStudent.Remove(student);
        return true;
    }
    
    
    ///This metho is use for find student by id
    /// if it exists it will return @data , otherwise return @null
    public Student findStudentById(int id)
    {
        return allStudent.FirstOrDefault(s => s.StudentId == id);
    }

    ///This method is use for check exists student in collection or not
    /// if it exists return @true and if not return @false
    public bool ExistsByEmail(string email) => allStudent.Any(s => s.Email == email);
}