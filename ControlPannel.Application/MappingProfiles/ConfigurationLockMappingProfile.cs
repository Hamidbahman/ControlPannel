using System;
using AutoMapper;
using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationLockDtos;
using ControlPannel.Domain.Entities;


namespace controlpannel.application.MappingProfiles;
public class ConfigurationLockMappingProfile : Profile
{
    public ConfigurationLockMappingProfile()
    {
        CreateMap<ConfigurationLock, ConfigurationLockDto>()
            .ForMember(dest => dest.LockType, opt => opt.MapFrom(src => src.LockType.ToString()));

        CreateMap<AddConfigurationLockRequestDto, ConfigurationLock>();

        CreateMap<UpdateConfigurationLockRequestDto, ConfigurationLock>();
    }
}
