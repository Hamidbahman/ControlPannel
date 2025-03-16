using System;
using AutoMapper;
using controlpannel.Application.Dtos;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;

namespace controlpannel.application.MappingProfiles;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Aplication, ApplicationDto>();
        CreateMap<AddApplicationRequestDto, Aplication>()
            .ForMember(dest => dest.Status, opt=>opt.MapFrom(src => (StatusTypes)src.Status));
        CreateMap<UpdateApplicationRequestDto, Aplication>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (StatusTypes)src.Status));
    }

}
