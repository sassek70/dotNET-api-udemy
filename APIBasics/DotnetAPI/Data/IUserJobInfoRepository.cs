namespace DotnetAPI.Data
{
    public interface IUserJobInfoRepository
    {
        public bool SaveChanges();
        public bool AddEntity<T>(T entityToAdd);
        public bool RemoveEntity<T>(T entityToRemove);

    }
}