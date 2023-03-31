using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.DTO;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserJobInfoEFController : RepositoryBase<UserJobInfo>, IUserJobInfoRepository
    {
        DataContextEF _entityframework;
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
            IEnumerable<UserJobInfo> allJobs =  _entityframework.UserJobInfo.ToList();

            return allJobs;
        }

        [HttpGet("UserJobInfo/{userId}")]
        public UserJobInfo GetUserJobInfo(int userId)
        {
            UserJobInfo? userJobInfoDb = _userJobInfoRepository. GetById();
            // return _entityframework.UserJobInfo.Where(u => u.UserId == userId).FirstOrDefault<UserJobInfo>();


            if(UserJobInfoDb != null)
            {
                return UserJobInfoDb;
                // return Ok();
            }
            throw new Exception("User's JobInfo not found");

        }

        [HttpPut("EditJobInfo")]
        public IActionResult UpdateJobInfo(UserJobInfo UserJobInfo)
        {
            UserJobInfo? UserJobInfoDb = _entityframework.UserJobInfo.Where(u => u.UserId == UserJobInfo.UserId).FirstOrDefault<UserJobInfo>();
            if (UserJobInfoDb != null)
            {
                UserJobInfoDb.JobTitle = UserJobInfo.JobTitle;
                UserJobInfoDb.Department = UserJobInfo.Department;
                if(_userJobInfoRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to update User's JobInfo");

            }

            throw new Exception("Could not find User's JobInfo");

        }

        [HttpPost("AddNewJobInfo")]
        public IActionResult AddNewJobInfo(UserJobInfo newJobInfo)
        {
            _userJobInfoRepository.AddEntity(newJobInfo);

            if(_userJobInfoRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add JobInfo");
        }

        [HttpDelete("DeleteJobInfo/{userId}")]
        public IActionResult DeleteUserJobInfo(int userId)
        {
            UserJobInfo? JobInfoToDelete = _entityframework.UserJobInfo.Where(u => u.UserId == userId).FirstOrDefault<UserJobInfo>();
            if(JobInfoToDelete != null)
            {
                _userJobInfoRepository.RemoveEntity(JobInfoToDelete);
                _userJobInfoRepository.SaveChanges();
                return Ok();
            }
            throw new Exception("Failed to delete");
        }

    }
}