using DotnetAPI.DTO;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserJobInfoRepository : RepositoryBase<UserJobInfo>, IUserJobInfoRepository
    {
        // DataContextEF _entityFramework;

        public UserJobInfoRepository(IConfiguration config) : base(config) { }
        public UserJobInfo? GetById(int userId)
        {
            return _entityFramework.UserJobInfo.Where(u => u.UserId == userId).FirstOrDefault<UserJobInfo>();
        }

        public List<UserJobInfo> GetAll()
        {
            return _entityFramework.UserJobInfo.ToList();
        }

        public bool UpdateUserJobInfo(int userId, UserJobInfoDTO userJobInfoDTO)
        {
            UserJobInfo? userJobInfoDb = GetById(userId);

            if (userJobInfoDb == null) return false;

            userJobInfoDb.JobTitle = userJobInfoDTO.JobTitle;
            userJobInfoDb.Department= userJobInfoDTO.Department;

            return SaveChanges();
        }
    }
}