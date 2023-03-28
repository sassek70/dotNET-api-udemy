using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.SqlClient;
using DotnetAPI.Data;
using DotnetAPI.Models;
using DotnetAPI.DTO;
using AutoMapper;

namespace DotnetAPI.Controllers;

[ApiController] // identifies this file as a controller to the app.MapControllers() method
[Route("[controller]")]// can specify the name of the class in the controller or let it infer the name with "[controller]" -- Inferring is standard
//End point is class name - "Controller" --- `/User`
public class UserEFController : ControllerBase // <Class Name> ":" == "inherit from" "ControllerBase" class. Similar to ActiveRecord
{
    // DataContextEF _entityFramework;
    IUserRepository _userRepository;
    IMapper _mapper;


    public UserEFController(IConfiguration config, IUserRepository userRepository)
    {
        // _entityFramework = new DataContextEF(config);

        _userRepository = userRepository;

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
        
        // User? user = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();           
        User? user = _userRepository.GetById(userId);

        if (user != null)
        {
            return user; 
        }
        
        throw new Exception("Failed to find user.");

    }

    [HttpGet("GetUsers")]
    public List<User> GetAllUsers()
    {
        // IEnumerable<User> users = _entityFramework.Users.ToList();           
        var users = _userRepository.GetAll();
        return users;
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(int userId, UserDTO userDTO) // IActionResult returns a response, (success/fail, error messages)
    {
        // User? userDb = _entityFramework.Users.Where(u => u.UserId == user.UserId).FirstOrDefault<User>();           
        var userDb = _userRepository.GetById(userId);
        

        var isSuccess = _userRepository.UpdateUser(userId, userDTO);

        return isSuccess ? Ok() : throw new Exception("Failed to update user.");
        // if (userDb != null)
        // {
        //     userDb.FirstName = userDTO.FirstName;
        //     userDb.LastName = userDTO.LastName;
        //     userDb.Gender = userDTO.Gender;
        //     userDb.Active = userDTO.Active;

        //     if (_userRepository.SaveChanges())
        //     {
        //         return Ok();
        //     }

        //     throw new Exception("Failed to update user.");
        // }
        
        // throw new Exception("Failed to get user.");

    }

    [HttpPost("AddUser")]
    // UserDTO -- DTO = Data Transfer Object, separate class with only the attributes you need to worry about. i.e: we don't need userId when creating a new user.
    public IActionResult AddUser(UserDTO user)
    {

        // User userDb = new User(); // not needed with AutoMapper
        User userDb = _mapper.Map<User>(user);           

        /* This block is not needed if you use AutoMapper
           
           userDb.FirstName = user.FirstName;
           userDb.LastName = user.LastName;
           userDb.Gender = user.Gender;
           userDb.Active = user.Active;
        */
        //    _entityFramework.Add(userDb);

        // if (_userRepository.SaveChanges())
        // {
        //     return Ok();
        // }
        // throw new Exception("Failed to create user.");

        if( _userRepository.AddEntity(userDb))
        {
            _userRepository.SaveChanges();
            return Ok();
        }
        throw new Exception("Failed to create user.");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
    //    User? userDb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();           
        User? userDb = _userRepository.GetById(userId);

        
        if (userDb == null) throw new Exception("Failed to delete user.");
        _userRepository.RemoveEntity(userDb);
        return Ok();

            // if (_userRepository.SaveChanges())
            // {
            //     return Ok();
            // }
    }

    // ############################################################
    // ############################################################
    // ############################################################

    // [HttpGet("UserSalary/{userId}")]
    // public IActionResult GetUserSalary(int userId)
    // {
    //     User? userDb = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();
        

    //     UserSalary? userSalaryDb = _entityFramework.UserSalary.Where(user => user.UserId == userId).FirstOrDefault<UserSalary>();

    //     if (userSalaryDb != null)
    //     {
    //        return userSalaryDb;
    //     }

    //     throw new Exception("Cannot find user salary");
    // }
}

/* 
    Reading:
        - DBModel  (Entity.User) -> The model stored in the DB -> User.Options is a string (JSON serialized)
            - Look this is in a "Repository"
            - UserRepository.GetByIdAsync(long userId)
                -> var entityUser = DbContext.Users.SingleOrDefault(u => u.UserId == userId) returns Entity.User from the DB, but I want to work with the User model in the backend...
                -> Convert Entity.User to User before you return the result (Automapper)
                -> _mapper.Map<User>(entityUser); (Maps entityUser into a User)

            .CreateMap<EntityUser, User>()
                .ForMember(dest => dest.Options, c => c.MapFrom(source => JsonConvert.Deserialize(source.Options)))


            class User {
                public int UserId {get; set;}
                public string FirstName {get; set;} = "";
                public string LastName {get; set;} = "";
                public string Email{get; set;} = "";
                public string Gender{get; set;} = "";
                public bool Active {get; set;}
                public Dictionary<string, string> UserOptions { get; set; }
            }

        - Base Model    (User) -> The model we "work with" on the backend -> User.Options is a Dictionary<string(key), string(value)>

            - Work with this on the backend, doing what we need to


        - DisplayModel (UserDTO) -> This is the model that the public sees
            - Before returning data to the client, the base model is converted to this, so that only specific data becomes public
            - Done in the Controller

            Ex: UsersController.GetUser(long userId)
                var user = UserService.




    Controller - Take in requests, authorizes, invokes some action in a service to get a result
    Service - Performs actions, calls other services / repositories, does things
    Repository - talks to database

    READING:

    Ex: I want to look up a User and return their info  (ONION architecture)
    1) UsersController
        - Receive the request..Does this route even exist?
        - Who is this requestor? **Authentication**
            -> Send their web token to the AuthService to find out who the user is
        - Is this "requestor" allowed to make this request? ** Authorize **
            --> If any of these fail, return the appropriate error codes
        - Ok, they're allowed to do this...Tell someone else to do it
            - const user = usersService.GetById(userId)
            2) UsersService
                - Responsible for working with Users (Get them? Authorize Them? Update them?)
                Ex: We need to look up this user. Lets get it from the DB (but I cant do that myself)
                - Call the repo
                
                public User GetById(long userId)
                {
                    return usersRepository.GetById(userId);
                }
                
                3) UserRepository
                    - Look up the the in the DB by some value
                        
                        public User GetById(long userId)
                        {
                            var entityUser = DbContext.Users.SingleOrDefault(u => u.UserId == userId) //returns Entity.User from the DB, but I want to work with the User model in the backend...

                            // Convert Entity.User to User before you return the result (Automapper)
                            return _mapper.Map<User>(entityUser); // (Maps entityUser into a User)
                        }

            4) The userService received the User model back!
                - The UserService.GetById method isnt doing any other logic, just return the User Model to its caller

        5) The UserController gets the User model back from the UserService
            - We dont want to just return the User model, because there is some: a) sensitive info, b) too much info, c) something else reason
            - Lets pick the data we want/need from the User Model, and return only that
                - Return one or two specific fields OR return a DTO / DisplayModel

                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;

------------------------------------------------------------------------------------------------
    WRITING:

    Ex: I want to update User and return their info  (ONION architecture)
    1) UsersController
        - Receive the request..Does this route even exist?
        - Who is this requestor? **Authentication**
            -> Send their web token to the AuthService to find out who the user is
        - Is this "requestor" allowed to make this request? ** Authorize **
            - ARE they allowed to do a PUT PERIOD. (AuthService)
            - ARE they allowed to PUT THIS USER SPECIFICALLY (UserAuthService)
                
                public bool UserHasWriteAccessToUser(long userId, long requestorsUserId)
                {
                    var user = UserService.GetById(userId);
                    
                    return user is not null && user.UserId == requestorUserId
                }

            --> If any of these fail, return the appropriate error codes
        - Ok, they're allowed to do this...Take in the DTO from the client and Convert into / UpdateParams or CreateParams
            - Users should ONLY BE ALLOWED TO UPDATE / SET SPECIFIC PROPERTIES -> Same as strong params in Ruby

            class UsersDTO 
            {
                public string FirstName {get; set;} = "";
                public string LastName {get; set;} = "";
                public string Email{get; set;} = "";
                public bool Active {get; set;}

                public UserUpdateParams ToUpdateParams()
                {
                    var updateParams = new UserUpdateParams
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        Email = Email.ToLower()
                    }
                }
            }

            class UserUpdateParams 
            {
                public string FirstName {get; set;} = "";
                public string LastName {get; set;} = "";
                public string Email{get; set;} = "";
                public bool Active {get; set;}
            }

            So in my controller:
                - after doing the auth
                UsersUpdateParams updateParams = usersDTO.ToUpdateParams()

                - Tell the userService to start the update logic
                    var updatedUser = userService.UpdateUser(userId, updateParams)
 
            2) UsersService
                Ex: We are preparing an update for a User, given the userId, and the updateParams
                - Call the repo
                
                public User UpdateById(long userId, UpdateUserParams updateParams)
                {
                    return usersRepository.UpdateUser(userId, updateParams);
                }

                public User SetAsInactive(long userId, UpdateUserParams updateParams)
                {
                    updateParams.Active = false;
                    return usersRepository.UpdateUser(userId, updateParams);
                }
                
                3) UserRepository
                    - Find the user, udate their stuff
                        
                        public User UpdateUser(long userId, UpdateUserParams updateParams)
                        {
                            var existingUserEntity = DbContext.Users.SingleOrDefault(u => u.UserId == userId) //returns Entity.User from the DB, but I want to work with the User model in the backend...
                            if (existingUserEntity is null) return null;


                            existingUserEntity.FirstName = updateParams.FirstName;
                            existingUserEntity.LastName = updateParams.LastName;
                            existingUserEntity.Email = updateParams.Email;
                            existingUserEntity.Active = updateParams.Active;

                            existingUserEntity.UpdateOn = DateTime.UtcNow;

                            DbContext.SaveChanges();

                            // Convert Entity.User to User before you return the result (Automapper)
                            return _mapper.Map<User>(existingUserEntity); // (Maps existingUserEntity into a User)
                        }

            4) The userService received the User model back!
                - The UserService.UpdateUser returns the updated User model to the controller.

        5) The UserController gets the User model back from the UserService
            - The UserController, now converts the updated User model back to a DTO and sends it to the client

                UserDTO userDTO = _mapper.Map<UserDTO>(updatedUser);
                return userDTO;


*/
