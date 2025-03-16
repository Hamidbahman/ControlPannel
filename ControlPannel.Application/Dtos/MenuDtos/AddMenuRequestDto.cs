using System;

namespace controlpannel.application.Dtos.MenuDtos;

public class AddMenuRequestDto
{
    public string MenuKey { get; set; }
    public string Icon {get;set;}
    public short Priority {get;set;}
    public long ActeeId { get; set; }
}