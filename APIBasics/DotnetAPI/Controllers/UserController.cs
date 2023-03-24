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
    [HttpGet("GetUsers/{testValue}")] // custom route name --- User/GetUsers/:params
    // public IEnumerable<User> GetUsers()
    // public string[] GetUsers(string testValue) //sets endpoint params as method parameters
    public string[] GetUsers(string testValue)
    {
        // return new string[] {"user1", "user2"};
        return new string[] {"user1", "user2", testValue }; // returns with params
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
