using dotnet_db_api.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnet_db_api.Data;

///AppDbContext គឺជា ថ្នាក់ច្រកចូលទៅកាន់ Database (Database Context)
///DbContext manage database connection, ORM (EF core) , manage Queries, និង Crud Operation with Data.........
///if compare with spring boot : @Entity + @Repository == ApplicationDbContext : DbContext
public class ApplicationDbContext : DbContext
{
    //This constructor is injection connection from Program.cs
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  base(options){}
    
    //Set Model Class to table in database
    public DbSet<Student> Students { get; set; }
}   

//Note* about DbContext Class is use for manage Query specific but it
//not like spring boot having method to store query and spring generate query
//in ASP.NET is need to write query by your own using LINQ method for query builder
//more over query we write is not write in AppDbContext class we must seperate it to repository to store query
//but inject from AppDbContext because it is bridge of database to ASP.NET