using System;


namespace controlpannel.application.Dtos.ConfigurationPassword;
public class ConfigurationPasswordSortingRequestDto
{
    public long ApplicationId { get; set; }
    public string SortByField { get; set; }
    public bool Descending { get; set; }
}
