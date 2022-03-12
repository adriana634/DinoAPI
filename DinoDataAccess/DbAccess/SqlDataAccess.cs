using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DinoDataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        this._config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T>(
        string storedProcedure,
        string connectionId = "Default")
    {
        string connectionString = this._config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);

        IEnumerable<T> data = await connection.QueryAsync<T>(
            storedProcedure,
            commandType: CommandType.StoredProcedure);

        return data;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        string connectionString = this._config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);

        IEnumerable<T> data = await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure);

        return data;
    }
}
