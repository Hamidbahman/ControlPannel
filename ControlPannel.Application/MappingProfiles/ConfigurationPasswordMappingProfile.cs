using System;
using AutoMapper;
using controlpannel.application.Dtos;
using controlpannel.application.Dtos.ConfigurationPassword;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.MappingProfiles;

public class ConfigurationPasswordMappingProfile : Profile
{
    public ConfigurationPasswordMappingProfile()
    {
        CreateMap<ConfigurationPassword, ConfigurationPasswordDto>();

        CreateMap<AddConfigurationPasswordRequestDto, ConfigurationPassword>();

        CreateMap<UpdateConfigurationPasswordRequestDto, ConfigurationPassword>();
    }
}
