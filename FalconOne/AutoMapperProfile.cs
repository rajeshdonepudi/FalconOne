using AutoMapper;
using FalconOne.DAL.Entities;
using Utilities.DTOs;

namespace FalconOne.API
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
            CreateMap<User, UserDTO>();
            CreateMap<UserRoleDTO, UserRole>().ReverseMap();
            CreateMap<AuthenticateResponseDTO, User>().ReverseMap();
            CreateMap<CreatePolicyDTO, ApplicationPolicy>().ReverseMap();
            CreateMap<ApplicationSettingDTO, ApplicationSetting>().ReverseMap();
            //CreateMap<DepartmentDTO, Department>()
            //    .ForMember(x => x.Employees, x => x.MapFrom(x => x.Users))
            //    .ForMember(x => x.Posts, x => x.MapFrom(x => x.Posts)).ReverseMap();
        }
    }
}