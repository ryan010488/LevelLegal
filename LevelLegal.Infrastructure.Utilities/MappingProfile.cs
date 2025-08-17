using System.Security.Policy;
using AutoMapper;
using LevelLegal.Domain.Entities.Models;
using LevelLegal.Domain.Entities.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LevelLegal.Infrastructure.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Models.Evidence, EvidenceVM>()
                .ForMember(dest => dest.MatterName, opt => opt.MapFrom(src => src.Matter.Name));

            CreateMap<Matter, OptionItemVM>();
        }
    }
}
