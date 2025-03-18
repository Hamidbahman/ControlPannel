using System;
using AutoMapper;
using controlpannel.application.Dtos.UserDto;

namespace controlpannel.application.MappingProfiles;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<AddUserRequestDto, UserDto>();

        CreateMap<UpdateUserRequestDto, UserDto>();

        CreateMap<UserDto, UpdateUserRequestDto>()
            .ForMember(dest => dest.PrimaryKey, opt => opt.Ignore());
    }
}

