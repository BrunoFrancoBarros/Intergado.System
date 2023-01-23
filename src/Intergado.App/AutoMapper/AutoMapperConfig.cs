using AutoMapper;
using Intergado.App.ViewModels;
using Intergado.Business.Model;

namespace Intergado.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FazendaEntity, FazendaViewModel>().ReverseMap();
            CreateMap<AnimalEntity, AnimalViewModel>().ReverseMap();
        }
    }
}