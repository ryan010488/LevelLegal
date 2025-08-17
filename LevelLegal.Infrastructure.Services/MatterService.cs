using AutoMapper;
using LevelLegal.Domain.Entities.ViewModels;
using LevelLegal.Domain.Interfaces.Repositories;
using LevelLegal.Domain.Interfaces.Services;

namespace LevelLegal.Infrastructure.Services
{
    public class MatterService : IMatterService
    {
        private readonly IMapper _mapper;

        private IMatterRepository _matterRepository;        

        public MatterService(IMapper mapper,
            IMatterRepository matterRepository)
        {
            _mapper = mapper;

            _matterRepository = matterRepository;
        }

        public async Task<List<MatterVM>> GetAllAsync()
        {
            var model = await _matterRepository.GetAllAsync();
            var result = _mapper.Map<List<MatterVM>>(model);

            return result;
        }

        public async Task<List<OptionItemVM>> GetAllToOptionItemAsync()
        {
            var model = await _matterRepository.GetAllAsync();
            var result = _mapper.Map<List<OptionItemVM>>(model);

            return result;
        }

    }
}
