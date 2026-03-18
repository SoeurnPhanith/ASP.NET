using dotnet_db_api.Data;
using dotnet_db_api.Model;

namespace dotnet_db_api.Repository.Impl;

public class StudentRepository : IStudentRepository
{
    //inject bridge of database
    private readonly ApplicationDbContext _dbContext;
    public StudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<Student> FindAll()
    {
        return _dbContext.Students.ToList();
    }

    /// This method is use for find student by id
    /// if found it will return @data, otherwise return @null
    public Student FindById(int id)
    {
        return _dbContext.Students.FirstOrDefault(s => s.Id == id);
    }

 
    /// This save method is insert or save data into database
    /// and make Id is auto increment ++
    public void Save(Student student)
    {   
        // Check if table is empty
        int maxId = _dbContext.Students.Any() ? _dbContext.Students.Max(s => s.Id) : 0;
        student.Id = maxId + 1;
        
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges(); //save into db
    }

    public void Update(Student student)
    {
        _dbContext.Students.Update(student);
        _dbContext.SaveChanges();
    }

    public Student DeleteById(int id)
    {
        Student student = _dbContext.Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            throw new Exception("Student Not Found");
        }

        Student removeStudent = _dbContext.Students.Remove(student).Entity;
        _dbContext.SaveChanges();
        return removeStudent;
    }

    public Student Delete(Student student)
    {
        throw new NotImplementedException();
    }
    
    /// This method is use for check exists student by student name
    /// if exists return @true, otherwise return @false
    public bool ExistByEmail(string email)
    {
        return _dbContext.Students.Any(s=> s.Name==email);
    }
}