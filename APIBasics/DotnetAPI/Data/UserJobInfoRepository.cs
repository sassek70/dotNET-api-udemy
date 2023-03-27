namespace DotnetAPI.Data
{
    public class UserJobInfoRepository : IUserJobInfoRepository
    {
        DataContextEF _entityFramework;
    
    public UserJobInfoRepository(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

    public bool SaveChanges()
    {
        if(_entityFramework.SaveChanges() > 0)
        {
            return true;
        };
        return false;
    }

    public bool AddEntity<T>(T entityToAdd)
    {
        if(entityToAdd != null)
        {
            _entityFramework.Add(entityToAdd);
            return true;
        }
        return false;
    }

    public bool RemoveEntity<T>(T entityToRemove)
    {
        if(entityToRemove != null)
        {
            _entityFramework.Remove(entityToRemove);
            return true;
        }
        return false;
    }



    }
}