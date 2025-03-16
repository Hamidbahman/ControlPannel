using System;
using AutoMapper;
using controlpannel.application.Dtos.ConfigurationSessionDtos;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.MappingProfiles;
public class ConfigurationSessionMappingProfile : Profile
{
    public ConfigurationSessionMappingProfile()
    {
        CreateMap<ConfigurationSession, ConfigurationSessionDto>();

        CreateMap<AddConfigurationSessionRequestDto, ConfigurationSession>();

        CreateMap<UpdateConfigurationSessionRequestDto, ConfigurationSession>();
    }
}
