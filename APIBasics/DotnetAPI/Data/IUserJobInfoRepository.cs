using DotnetAPI.DTO;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public interface IUserJobInfoRepository : IRepositoryBase<UserJobInfo>
    {
        // public bool SaveChanges();
        // public bool AddEntity<T>(T entityToAdd);
        // public bool RemoveEntity<T>(T entityToRemove);
        public bool UpdateUserJobInfo(int userId, UserJobInfoDTO userDTO);

    }
}