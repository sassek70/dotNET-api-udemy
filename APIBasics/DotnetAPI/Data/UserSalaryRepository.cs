using DotnetAPI.DTO;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserSalaryRepository : RepositoryBase<UserSalary>, IUserSalaryRepository
    {
        // DataContextEF _entityFramework;

        public UserSalaryRepository(IConfiguration config) : base(config) { }
        public UserSalary? GetById(int userId)
        {
            return _entityFramework.UserSalary.Where(u => u.UserId == userId).FirstOrDefault<UserSalary>();
        }

        public List<UserSalary> GetAll()
        {
            return _entityFramework.UserSalary.ToList();
        }

        public bool UpdateUserSalary(int userId, UserSalaryDTO userSalaryDTO)
        {
            UserSalary? userSalaryDb = GetById(userId);

            if (userSalaryDb == null) return false;

            userSalaryDb.Salary = userSalaryDTO.Salary;

            return SaveChanges();
        }
    }
}
