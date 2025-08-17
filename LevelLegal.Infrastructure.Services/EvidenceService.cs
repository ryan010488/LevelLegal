using AutoMapper;
using LevelLegal.Domain.Entities.ViewModels;
using LevelLegal.Domain.Interfaces.Repositories;
using LevelLegal.Domain.Interfaces.Services;

namespace LevelLegal.Infrastructure.Services
{
    public class EvidenceService : IEvidenceService
    {
        private readonly IMapper _mapper;

        private IEvidenceRepository _evidenceRepository;        

        public EvidenceService(IMapper mapper, 
            IEvidenceRepository evidenceRepository)
        {
            _mapper = mapper;

            _evidenceRepository = evidenceRepository;
        }

        public async Task<List<EvidenceVM>> GetAllAsync(int matterId = 0)
        {
            var model = await _evidenceRepository.GetAllAsync(matterId);
            var result = _mapper.Map<List<EvidenceVM>>(model);

            return result;
        }

    }
}
