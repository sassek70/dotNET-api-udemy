using DotnetAPI.DTO;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        // public bool SaveChanges();
        // public bool AddEntity<T>(T entityToAdd);
        // public bool RemoveEntity<T>(T entityToRemove);
        // public User? GetById(int userId);
        // public List<User> GetAll();
        public bool UpdateUser(int userId, UserDTO userDTO);
    }
}