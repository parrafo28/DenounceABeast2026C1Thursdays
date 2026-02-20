using DenounceBeasts.API.Data.Entities;

namespace DenounceBeasts.API.Models.Dtos
{
    public class MappingProfile: AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Municipality, MunicipalityDto>()
                //.ForMember(dest => dest.PropertyTest2, op=> op.MapFrom(src => src.PropertyTest1))
                .ReverseMap()
              //  .ForMember(dest => dest.PropertyTest1, op=> op.MapFrom(src => src.PropertyTest2))
                ;
            //CreateMap<MunicipalityDto, Municipality>();

            CreateMap<Municipality, MunicipalityListDto>().ReverseMap();
            CreateMap<Municipality, MunicipalityCreateDto>().ReverseMap();

            CreateMap<Sector, SectorDto>().ReverseMap();

            CreateMap<Status, StatusDto>().ReverseMap();
        }
    }
}
