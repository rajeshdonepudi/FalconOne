using AutoMapper;
using FalconeOne.BLL.DTOs;
using FalconOne.DLL.Entities;

namespace FalconeOne.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterNewUserRequestDTO, User>()
                .ForMember(destination => destination.PasswordHash, source => source.MapFrom(s => s.Password))
                .ReverseMap()
                .ForMember(dest => dest.Password, source => source.MapFrom(x => x.PasswordHash));

            CreateMap<RequestInformationDTO, RequestInformation>().ReverseMap();
            CreateMap<User, AccountDTO>();
        }
    }
}
