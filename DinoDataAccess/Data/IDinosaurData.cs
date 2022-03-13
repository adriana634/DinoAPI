using DinoDataAccess.Models;

namespace DinoDataAccess.Data;

public interface IDinosaurData
{
    Task<IEnumerable<DinosaurModel>> GetAllDinosaurs();
    Task<DinosaurModel?> GetDinosaur(int id);
    Task<IEnumerable<DinosaurModel>> SearchDinosaurs(string criteria);
}