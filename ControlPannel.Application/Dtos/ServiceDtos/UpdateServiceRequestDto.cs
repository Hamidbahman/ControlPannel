using System;
using ControlPannel.Domain.Enums;

namespace controlpannel.application.Dtos.ServiceDtos;

public class UpdateServiceRequestDto
{
    public long Id { get; set; }
    public long ActeeId { get; set; }
    public ServiceTypes ServiceType { get; set; }
    public string ServiceKey { get; set; }
    public string Rest { get; set; }
}
