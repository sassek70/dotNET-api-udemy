namespace DotnetAPI.Data
{
    public interface IUserSalaryRepository
    {
        public bool SaveChanges();
        public bool AddEntity<T>(T entityToAdd);
        public bool RemoveEntity<T>(T entityToRemove);

    }
}