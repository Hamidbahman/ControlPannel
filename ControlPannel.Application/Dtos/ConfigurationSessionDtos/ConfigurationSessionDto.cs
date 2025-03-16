using System;



namespace controlpannel.application.Dtos.ConfigurationSessionDtos;
public class ConfigurationSessionDto
{
    public long Id { get; set; }
    public bool IsConcurrentActive { get; set; }
    public int ConcurrencyCount { get; set; }
    public int SessionTimeout { get; set; }
    public long ApplicationId { get; set; }
}
