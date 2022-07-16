using System.Data.SqlClient;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    public IConfiguration _Config { get; }
    public SqlDataAccess(IConfiguration config)
    {
        _Config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string StoredProcedure, U Parameters, string ConnectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_Config.GetConnectionString(ConnectionId));
        return await connection.QueryAsync<T>(StoredProcedure, Parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string StoredProcedure, T Parameters, string ConnectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_Config.GetConnectionString(ConnectionId));
        await connection.ExecuteAsync(StoredProcedure, Parameters, commandType: CommandType.StoredProcedure);

    }

}
