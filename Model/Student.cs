using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_db_api.Model;

[Table("tbl_student")]
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
}