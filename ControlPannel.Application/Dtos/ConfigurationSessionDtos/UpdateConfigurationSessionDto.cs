using System;
using System.ComponentModel.DataAnnotations;


namespace controlpannel.application.Dtos.ConfigurationSessionDtos;
public class UpdateConfigurationSessionRequestDto
{
    [Required]
    public long Id { get; set; }

    public bool IsConcurrentActive { get; set; }
    public int ConcurrencyCount { get; set; }
    public int SessionTimeout { get; set; }
}
