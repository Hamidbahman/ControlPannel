using System;



namespace controlpannel.application.Dtos.ConfigurationLockDtos;
public class ConfigurationLockDto
{
    public long Id { get; set; }
    public bool CaptchaNeeded { get; set; }
    public short FailedLoginAmountBeforeCaptcha { get; set; }
    public int LockTimeInterval { get; set; }
    public string LockType { get; set; }
    public long ApplicationId { get; set; }
}
