using System;
using System.ComponentModel.DataAnnotations;
using ControlPannel.Domain.Enums;



namespace controlpannel.application.Dtos.ConfigurationLockDtos;
public class AddConfigurationLockRequestDto
{
    [Required]
    public long ApplicationId { get; set; }

    public bool CaptchaNeeded { get; set; }
    public short FailedLoginAmountBeforeCaptcha { get; set; }
    public int LockTimeInterval { get; set; }
    public LockTypes LockType { get; set; }
}
