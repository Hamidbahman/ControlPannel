using System;

namespace controlpannel.application.Dtos.MenuDtos;

public class UpdateMenuRequestDto
{    
    public long Id { get; set; }
    public string Icon {get;set;}
    public short Priority {get;set;}
    public string MenuKey { get; set; }
    public long ActeeId { get; set; }
}
