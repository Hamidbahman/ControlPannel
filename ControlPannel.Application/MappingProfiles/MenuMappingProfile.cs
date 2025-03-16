using System;
using AutoMapper;
using controlpannel.application.Dtos.MenuDtos;
using ControlPannel.Domain.Entities;

namespace controlpannel.application.MappingProfiles;

public class MenuMappingProfile : Profile
{
    public MenuMappingProfile()
    {
        CreateMap<Menu, AddMenuRequestDto>();
        CreateMap<AddMenuRequestDto, Menu>();
        CreateMap<UpdateMenuRequestDto, Menu>();
    }
}
