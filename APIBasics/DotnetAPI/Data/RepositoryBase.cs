using DotnetAPI.DTO;

namespace DotnetAPI.Data
{

    public abstract class RepositoryBase<TEntity> 
    {
        protected DataContextEF _entityFramework;

        public RepositoryBase(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }

        public bool SaveChanges()
        {
            if (_entityFramework.SaveChanges() > 0)
            {
                return true;
            };
            return false;
        }

        public bool AddEntity(TEntity entityToAdd)
        {
            if (entityToAdd == null) return false;
            _entityFramework.Add(entityToAdd);
            return SaveChanges();
        }

        public bool RemoveEntity(TEntity entityToRemove)
        {
            if (entityToRemove == null) return false;
            _entityFramework.Remove(entityToRemove);
            return SaveChanges();
        }
    }
}