using AutoMapper;
using FalconOne.DAL.Entities;
using Utilities.DTOs;

namespace FalconOne.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<RegisterNewUserRequestDTO, User>()
                .ForMember(destination => destination.PasswordHash, source => source.MapFrom(s => s.Password))
                .ReverseMap()
                .ForMember(dest => dest.Password, source => source.MapFrom(x => x.PasswordHash));
            CreateMap<User, UserDTO>();

            CreateMap<UserRoleDTO, UserRole>().ReverseMap();
            CreateMap<User, AuthenticateResponseDTO>()
                .ForMember(d => d.TenantId, s => s.MapFrom(p => p.TenantId));
            #endregion

            #region Audit
            CreateMap<RequestInformationDTO, RequestInformation>().ReverseMap();
            #endregion

            #region Department
            CreateMap<Department, DepartmentDTO>();
            #endregion

            #region Policy
            CreateMap<CreatePolicyDTO, ApplicationPolicy>().ReverseMap();
            #endregion

            #region Settings
            CreateMap<ApplicationSettingDTO, ApplicationSetting>().ReverseMap();
            #endregion 

            #region Post
            CreateMap<Post, PostDTO>();
            #endregion
        }
    }
}