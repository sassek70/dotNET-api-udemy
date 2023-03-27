using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.DTO;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserSalaryEFController : ControllerBase
    {
        DataContextEF _entityframework;
        IUserSalaryRepository _userSalaryRepository;
        IMapper _mapper;
        
        public UserSalaryEFController(IConfiguration config, IUserSalaryRepository userSalaryRepository)
        {
            _entityframework = new DataContextEF(config);
            _userSalaryRepository = userSalaryRepository;
            _mapper = new Mapper(new MapperConfiguration(config => {
                config.CreateMap<UserSalaryDTO, UserSalary>();
            }));
        }

        [HttpGet("AllSalaries")]
        public IEnumerable<UserSalary> UserSalaries()
        {
            IEnumerable<UserSalary> allSalaries =  _entityframework.UserSalary.ToList();

            return allSalaries;
        }

        [HttpGet("UserSalary/{userId}")]
        public UserSalary GetUserSalary(int userId)
        {
            UserSalary? userSalaryDb = _entityframework.UserSalary.Where(u => u.UserId == userId).FirstOrDefault<UserSalary>();
            // return _entityframework.UserSalary.Where(u => u.UserId == userId).FirstOrDefault<UserSalary>();


            if(userSalaryDb != null)
            {
                return userSalaryDb;
                // return Ok();
            }
            throw new Exception("User's Salary not found");

        }

        [HttpPut("EditSalary")]
        public IActionResult UpdateSalary(UserSalary userSalary)
        {
            UserSalary? userSalaryDb = _entityframework.UserSalary.Where(u => u.UserId == userSalary.UserId).FirstOrDefault<UserSalary>();
            if (userSalaryDb != null)
            {
                userSalaryDb.Salary = userSalary.Salary;
                if(_userSalaryRepository.SaveChanges())
                // if(_entityframework.SaveChanges() > 0)
                {
                    return Ok();
                }
                throw new Exception("Failed to update User's Salary");

            }

            throw new Exception("Could not find User's Salary");

        }

        [HttpPost("AddNewSalary")]
        public IActionResult AddNewSalary(UserSalary newSalary)
        {
            if(_userSalaryRepository.AddEntity(newSalary))
            {
                _userSalaryRepository.SaveChanges();
                return Ok();
            }
            throw new Exception("Failed to add salary");
        }

        [HttpDelete("DeleteSalary/{userId}")]
        public IActionResult DeleteUserSalary(int userId)
        {
            UserSalary? salaryToDelete = _entityframework.UserSalary.Where(u => u.UserId == userId).FirstOrDefault<UserSalary>();
            if(salaryToDelete != null)
            {
                _userSalaryRepository.RemoveEntity(salaryToDelete);
                 if (_userSalaryRepository.SaveChanges())
                {
                    return Ok();
                }
            }
            throw new Exception("Failed to delete");
        }
    }

}