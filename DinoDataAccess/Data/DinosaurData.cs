namespace DinoDataAccess.Data;

using DinoDataAccess.DbAccess;
using DinoDataAccess.Models;

public class DinosaurData : IDinosaurData
{
    private readonly ISqlDataAccess _db;

    public DinosaurData(ISqlDataAccess db)
    {
        this._db = db;
    }

    public Task<IEnumerable<DinosaurModel>> GetAllDinosaurs() =>
        this._db.QueryAsync<DinosaurModel>(storedProcedure: "dbo.spDinosaur_GetAll");

    public Task<DinosaurModel?> GetDinosaur(int id) =>
        this._db.QuerySingleOrDefault<DinosaurModel?, dynamic>(
            storedProcedure: "dbo.spDinosaur_Get",
            new { Id = id });

    public Task<IEnumerable<DinosaurModel>> SearchDinosaurs(string criteria) =>
        this._db.QueryAsync<DinosaurModel, dynamic>(
            storedProcedure: "dbo.spDinosaur_Search",
            new { Criteria = criteria });
}
