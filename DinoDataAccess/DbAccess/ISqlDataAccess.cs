namespace DinoDataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> QueryAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<IEnumerable<T>> QueryAsync<T>(string storedProcedure, string connectionId = "Default");
    Task<T> QuerySingleOrDefault<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<T> QuerySingleOrDefault<T>(string storedProcedure, string connectionId = "Default");
}