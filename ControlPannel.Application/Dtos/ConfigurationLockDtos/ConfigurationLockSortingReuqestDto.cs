using System;


namespace controlpannel.application.Dtos.ConfigurationLockDtos;
public class ConfigurationLockSortingRequestDto
{
    public long ApplicationId { get; set; }
    public string SortByField { get; set; }
    public bool Descending { get; set; }
}
