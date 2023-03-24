using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using DotnetAPI.Data;

namespace DotnetAPI.Controllers;

[ApiController] // identifies this file as a controller to the app.MapControllers() method
[Route("[controller]")]// can specify the name of the class in the controller or let it infer the name with "[controll]" -- Inferring is standard
//End point is class name - "Controller" --- `/User`
public class UserController : ControllerBase // <Class Name> ":" == "inherit from" "ControllerBase" class. Similar to ActiveRecord
{
    DataContextDapper _dapper;


    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    // [HttpGet("GetUsers")] // custom route name --- User/GetUsers
    [HttpGet("GetSingleUser/{userId}")] // custom route name --- User/GetUsers/:params
    // public IEnumerable<User> GetUsers()
    // public string[] GetUsers(string testValue) //sets endpoint params as method parameters
    public User GetSingleUser(int userId) // will return a single User instance
    {
        string sql = @"
            SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
                FROM TutorialAppSchema.Users
                    WHERE UserId = " + userId.ToString();

        User user = _dapper.LoadDataSingle<User>(sql);           
        return user; 

    //     // return new string[] {"user1", "user2"};
    //     // return new  {"user1", "user2", testValue }; // returns with params
    //     // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     // {
    //     //     Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //     //     TemperatureC = Random.Shared.Next(-20, 55),
    //     //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     // })
    //     // .ToArray();
    }

    [HttpGet("GetUsers")]

    public IEnumerable<User> GetAllUsers()
    {
        string sql = @"
            SELECT [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
                FROM TutorialAppSchema.Users";

        
        IEnumerable<User> users = _dapper.LoadData<User>(sql); 
        return users;
    }
    [HttpPut("EditUser")]
    public IActionResult EditUser(User user) // IActionResult returns a response, (success/fail, error messages)
    {
        string sql = @"
            UPDATE TutorialAppSchema.Users
                SET [FirstName] = '" + user.FirstName + 
                    "', [LastName] = '" + user.LastName + 
                    "', [Email] = '" + user.Email +
                    "', [Gender] = '" + user.Gender +
                    "', [Active] ='" + user.Active + 
                "' WHERE UserId = " + user.UserId;

        if (_dapper.ExecuteSql(sql))
        {
            return Ok(); // Built-in method in ControllerBase class - same as status: :ok
        }

        throw new Exception("Failed to update user.");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(User user)
    {
        string sql = @"INSERT INTO TutorialAppSchema.Users(
                    [FirstName],
                    [LastName],
                    [Email],
                    [Gender],
                    [Active]
                ) VALUES (" +
                    "'" + user.FirstName + 
                    "', '" + user.LastName +
                    "', '" + user.Email + 
                    "', '" + user.Gender + 
                    "', '" + user.Active + 
                "')";

                if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to update user.");
    }
}
