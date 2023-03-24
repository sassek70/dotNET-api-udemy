using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.DTO;
using AutoMapper;

namespace DotnetAPI.Controllers;

[ApiController] // identifies this file as a controller to the app.MapControllers() method
[Route("[controller]")]// can specify the name of the class in the controller or let it infer the name with "[controll]" -- Inferring is standard
//End point is class name - "Controller" --- `/User`
public class UserEFController : ControllerBase // <Class Name> ":" == "inherit from" "ControllerBase" class. Similar to ActiveRecord
{
    DataContextEF _entityFramework;
    IMapper _mapper;


    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
        _mapper = new Mapper(new MapperConfiguration(config =>{
            config.CreateMap<UserDTO, User>();
        }));
    }

    // [HttpGet("GetUsers")] // custom route name --- User/GetUsers
    [HttpGet("GetSingleUser/{userId}")] // custom route name --- User/GetUsers/:params
    // public IEnumerable<User> GetUsers()
    // public string[] GetUsers(string testValue) //sets endpoint params as method parameters
    public User GetSingleUser(int userId) // will return a single User instance
    {
        
        User? user = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();           
        
        if (user != null)
        {
            return user; 
        }
        
        throw new Exception("Failed to find user.");

    }

    [HttpGet("GetUsers")]

    public IEnumerable<User> GetAllUsers()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList();           

        return users;
    }
    [HttpPut("EditUser")]
    public IActionResult EditUser(User user) // IActionResult returns a response, (success/fail, error messages)
    {
        User? userDb = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault<User>();           

        if (userDb != null)
        {
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Gender = user.Gender;
            userDb.Active = user.Active;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        // throw new Exception("Failed to update user.");

        }
        
        throw new Exception("Failed to get user.");

    }

    [HttpPost("AddUser")]
    // UserDTO -- DTO = Data Transfer Object, separate class with only the attributes you need to worry about. i.e: we don't need userId when creating a new user.
    public IActionResult AddUser(UserDTO user)
    {

        User userDb = new User(); // not needed with AutoMapper
            // User userDb = _mapper.Map<User>(user);           

        // /* This block is not needed if you use AutoMapper
           
           userDb.FirstName = user.FirstName;
           userDb.LastName = user.LastName;
           userDb.Gender = user.Gender;
           userDb.Active = user.Active;
           _entityFramework.Add(userDb);
        // */

        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }
        throw new Exception("Failed to create user.");

        
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
       User? userDb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();           

        if (userDb != null)
        {
            _entityFramework.Users.Remove(userDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }
        }
        
        throw new Exception("Failed to delete user.");
    }
}
