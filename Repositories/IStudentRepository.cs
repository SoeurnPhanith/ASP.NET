using dotnet_db_api.Model;

namespace dotnet_db_api.Repository;

public interface IStudentRepository
{
    List<Student> FindAll();
    
    /// This method is use for find student by id
    /// if found it will return @data, otherwise return @null
    Student FindById(int id);
    
    /// This save method is insert or save data into database
    /// and make Id is auto increment ++
    void Save(Student student);
    
    void Update(Student student);
    
    Student DeleteById(int id);
    
    Student Delete(Student student);
    
    /// This method is use for check exists student by student name
    /// if exists return @true, otherwise return @false
    bool ExistByEmail(string email);
}