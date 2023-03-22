using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        
        private IConfiguration _config;
        public DataContextDapper(IConfiguration config){
            _config = config;

        }
        /* 
            To connect to a server, create a string in this format:
            //Windows
            "Server=<servername>;Database=<database name>;TrustServerCertificate=true(if running locally without SSL);Trusted_Connection=true(if using windows auth)";

            //Mac/Linux
            "Server=<servername>;Database=<database name>;TrustServerCertificate=true(if running locally without SSL);Trusted_Connection=false; User Id=<username>;Password=<password>;";
        */

        public IEnumerable<T> LoadData<T>(string sql)// "T" is a generic, type will be defined when calling the method
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)// "T" is a generic, type will be defined when calling the method
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql<T>(string sql)// "T" is a generic, type will be defined when calling the method
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return (dbConnection.Execute(sql) > 0);
        }

        public int ExecuteSqlWithRowCount<T>(string sql)// "T" is a generic, type will be defined when calling the method
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql);
        }    
        //make connection to db using the connectionString
    }
}