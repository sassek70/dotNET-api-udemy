using DotnetAPI.DTO;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config) { }

        public User? GetById(int userId)
        {
            return _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault<User>();           
        }

        public List<User> GetAll()
        {
            return _entityFramework.Users.ToList();
        }
        
        public bool UpdateUser(int userId, UserDTO userDTO)
        {
            var userDb = GetById(userId);

            if (userDb == null) return false;

            userDb.FirstName = userDTO.FirstName;
            userDb.LastName = userDTO.LastName;
            userDb.Gender = userDTO.Gender;
            userDb.Active = userDTO.Active;

            return SaveChanges();
        }
        // DataContextEF _entityFramework;

        // public UserRepository(IConfiguration config)
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

        // public bool AddEntity<T>(T entityToAdd)
        // {
        //     if (entityToAdd != null)
        //     {
        //         _entityFramework.Add(entityToAdd);
        //         return true;
        //     }
        //     return false;
        // }

        // public bool RemoveEntity<T>(T entityToRemove)
        // {
        //     if (entityToRemove != null)
        //     {
        //         _entityFramework.Remove(entityToRemove);
        //         return true;
        //     }
        //     return false;
        // }
    }
}