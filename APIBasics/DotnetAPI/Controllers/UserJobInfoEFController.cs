using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.DTO;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserJobInfoEFController : ControllerBase
    {
        // DataContextEF _entityframework;
        IUserJobInfoRepository _userJobInfoRepository;
        // IMapper _mapper;
        
        public UserJobInfoEFController(IConfiguration config, IUserJobInfoRepository userJobInfoRepository)
        {
            // _entityframework = new DataContextEF(config);
            _userJobInfoRepository = userJobInfoRepository;
            // _mapper = new Mapper(new MapperConfiguration(config => {
            //     config.CreateMap<UserJobInfoDTO, UserJobInfo>();
            // }));
        }

        [HttpGet("AllJobs")]
        public IEnumerable<UserJobInfo> UserJobs()
        {
            return _userJobInfoRepository.GetAll();
        }

        [HttpGet("UserJobInfo/{userId}")]
        public UserJobInfo GetUserJobInfo(int userId)
        {
            UserJobInfo? userJobInfoDb = _userJobInfoRepository.GetById(userId);
            // return _entityframework.UserJobInfo.Where(u => u.UserId == userId).FirstOrDefault<UserJobInfo>();


            if(userJobInfoDb != null)
            {
                return userJobInfoDb;
                // return Ok();
            }
            throw new Exception("User's JobInfo not found");

        }

        [HttpPut("EditJobInfo")]
        public IActionResult UpdateJobInfo(int userId, UserJobInfoDTO userJobInfoDTO)
        {
            UserJobInfo? userJobInfoDb = _userJobInfoRepository.GetById(userId);
            var isSuccess = _userJobInfoRepository.UpdateUserJobInfo(userId, userJobInfoDTO);
            
            return isSuccess ? Ok() : throw new Exception("Failed to update User's JobInfo");

            // {
            //     userJobInfoDb.JobTitle = UserJobInfo.JobTitle;
            //     userJobInfoDb.Department = UserJobInfo.Department;
            //     if(_userJobInfoRepository.SaveChanges())
            //     {
            //         return Ok();
            //     }
                

            // }

            throw new Exception("Could not find User's JobInfo");

        }

        [HttpPost("AddNewJobInfo")]
        public IActionResult AddNewJobInfo(UserJobInfo newJobInfo)
        {
            if (_userJobInfoRepository.AddEntity(newJobInfo))
            {
                return Ok();
            }
            throw new Exception("Failed to add JobInfo");
        }

        [HttpDelete("DeleteJobInfo/{userId}")]
        public IActionResult DeleteUserJobInfo(int userId)
        {
            UserJobInfo? jobInfoToDelete = _userJobInfoRepository.GetById(userId);
            if(jobInfoToDelete != null)
            {
                _userJobInfoRepository.RemoveEntity(jobInfoToDelete);
                _userJobInfoRepository.SaveChanges();
                return Ok();
            }
            throw new Exception("Failed to delete");
        }

    }
}