using Microsoft.AspNetCore.Mvc;

namespace demo_dotnet_api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] //here is base endpoint in dotnet
    //in dotnet no need using / like spring boot 
    
    /*[controller is == / to your class name]
        +example without [controller] => http:/localhost:5277/api/v1....
        +example with [controller] => http:/localhost:5277/api/hello/......
     */
    
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Greeting()
        {
            return "Hello World";
        } 

        [HttpGet("welcome")]
        public string Welcome()
        {
            return "Welcome to ASP.NET API project" +
                   "And i will to do it all my best!";
        }

        //[FromQuery] is tells ASP.NET Core to get the value of a parameter from the query string of the URL.
        [HttpGet("profile")]
        public string MyProfile(
            [FromQuery]string id,
            [FromQuery]string firstName,
            [FromQuery]string lastName,
            [FromQuery]string email)
        {
            return $"Id           : {id}\n\n" +
                   $"first name   : {firstName}\n\n" +
                   $"last name    : {lastName}\n\n" +
                   $"email        : {email}\n\n";  
        }
        
        //using dynamic route it's not need to use @PathVariable just normal
        [HttpGet("{id}")]
        public string Users(int id)
        {
            return $"User id : {id}";
        }
        
        
        //try to use dynamic route with same method
        [HttpGet("show-msg/{message}")]
        public string ShowUser(string message)
        {
            return $"message : {message}";
        }
    }
}