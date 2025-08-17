using LevelLegal.Domain.Entities.Models;

namespace LevelLegal.Domain.Interfaces.Repositories
{
    public interface IEvidenceRepository
    {

        Task<List<Evidence>> GetAllAsync(int matterId);

    }
}
