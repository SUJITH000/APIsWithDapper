using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess;
public interface ISqlDataAccess
{
    IConfiguration _Config { get; }

    Task<IEnumerable<T>> LoadData<T, U>(string StoredProcedure, U Parameters, string ConnectionId = "Default");
    Task SaveData<T>(string StoredProcedure, T Parameters, string ConnectionId = "Default");
}