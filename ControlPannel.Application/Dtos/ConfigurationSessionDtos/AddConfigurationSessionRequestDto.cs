using System;
using System.ComponentModel.DataAnnotations;



namespace controlpannel.application.Dtos.ConfigurationSessionDtos;
public class AddConfigurationSessionRequestDto
{
    [Required]
    public long ApplicationId { get; set; }

    public bool IsConcurrentActive { get; set; }
    public int ConcurrencyCount { get; set; }
    public int SessionTimeout { get; set; }
}
