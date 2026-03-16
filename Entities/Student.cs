namespace demo_dotnet_api.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public Student(int studentId, string firstName, string lastName, string email, DateTime dob)
    {
        this.StudentId = studentId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.DateOfBirth = dob;
    }
}   