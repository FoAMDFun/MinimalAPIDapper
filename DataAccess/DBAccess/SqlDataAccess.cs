using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DBAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private IConfiguration Configuration { get; }
    public SqlDataAccess(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection SQLConnection = new SqlConnection(Configuration.GetConnectionString(connectionId));

        return await SQLConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection SQLConnection = new SqlConnection(Configuration.GetConnectionString(connectionId));

        await SQLConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

}
