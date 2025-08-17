using LevelLegal.Domain.Entities.Models;

namespace LevelLegal.Domain.Interfaces.Repositories
{
    public interface IMatterRepository
    {

        Task<List<Matter>> GetAllAsync();

    }
}
