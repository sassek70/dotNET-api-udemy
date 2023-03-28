using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserSalaryRepository : RepositoryBase<UserSalary>, IUserSalaryRepository
    {
        // DataContextEF _entityFramework;

        public UserSalaryRepository(IConfiguration config) : base(config) { }
        // {
        //     _entityFramework = new DataContextEF(config);
        // }

        // public bool SaveChanges()
        // {
        //     if (_entityFramework.SaveChanges() > 0)
        //     {
        //         return true;
        //     };
        //     return false;
        // }

        public bool AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
                return true;
            }
            return false;
        }

        public bool RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove);
                return true;
            }
            return false;
        }
    }
}