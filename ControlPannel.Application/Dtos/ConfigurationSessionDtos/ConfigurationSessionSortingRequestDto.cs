using System;

namespace controlpannel.application.Dtos.ConfigurationSessionDtos;

public class ConfigurationSessionSortingRequestDto
{
    public long ApplicationId { get; set; }
    public string SortByField { get; set; }
    public bool Descending { get; set; }
}
