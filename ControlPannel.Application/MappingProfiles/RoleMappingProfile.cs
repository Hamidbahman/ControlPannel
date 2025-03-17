using System;
using AutoMapper;
using controlpannel.application.Dtos.RoleDtos;
using ControlPannel.Domain.Entities;
namespace controlpannel.application.MappingProfiles;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<AddRoleRequestDto, Role>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) 
            .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => Guid.NewGuid().ToString())) 
            .ForMember(dest => dest.Application, opt => opt.Ignore()) 
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
            .ForMember(dest => dest.Permissions, opt => opt.Ignore());

        CreateMap<UpdateRoleRequestDto, Role>()
            .ForMember(dest => dest.Uuid, opt => opt.Ignore()) 
            .ForMember(dest => dest.Application, opt => opt.Ignore()) 
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
            .ForMember(dest => dest.Permissions, opt => opt.Ignore());

        CreateMap<Role, RoleDto>();

        CreateMap<RoleSortingDto, Role>(); 
    }
}

