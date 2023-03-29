using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public interface IUserSalaryRepository : IRepositoryBase<UserSalary>
    {
        // public bool SaveChanges();
        // public bool AddEntity<T>(T entityToAdd);
        // public bool RemoveEntity<T>(T entityToRemove);
        public bool UpdateUserSalary(int userId, UserSalaryDTO userDTO);

    }
}