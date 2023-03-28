namespace DotnetAPI.Data
{
    public interface IRepositoryBase<TEntity>
    {
        public bool SaveChanges();
        public bool AddEntity(TEntity entityToAdd);
        public bool RemoveEntity(TEntity entityToRemove);
        public TEntity? GetById(int userId);
        public List<TEntity> GetAll();

    }
}