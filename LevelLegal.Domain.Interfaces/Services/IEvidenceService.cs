using LevelLegal.Domain.Entities.ViewModels;

namespace LevelLegal.Domain.Interfaces.Services
{
    public interface IEvidenceService
    {
        Task<List<EvidenceVM>> GetAllAsync(int matterId = 0);
    }
}
