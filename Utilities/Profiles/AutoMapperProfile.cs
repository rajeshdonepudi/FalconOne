using AutoMapper;
using FalconOne.DLL.Entities;
using Utilities.DTOs;

namespace Utilities.Profiles
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
            CreateMap<UserRoleDTO, UserRole>().ReverseMap();
            CreateMap<AuthenticateResponseDTO, User>().ReverseMap();
            CreateMap<CreatePolicyDTO, ApplicationPolicy>().ReverseMap();
            CreateMap<ApplicationSettingDTO, ApplicationSetting>().ReverseMap();
        }
    }
}
