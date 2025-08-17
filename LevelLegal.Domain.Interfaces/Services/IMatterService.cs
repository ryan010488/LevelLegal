using LevelLegal.Domain.Entities.ViewModels;

namespace LevelLegal.Domain.Interfaces.Services
{
    public interface IMatterService
    {
        Task<List<MatterVM>> GetAllAsync();

        Task<List<OptionItemVM>> GetAllToOptionItemAsync();
    }
}
