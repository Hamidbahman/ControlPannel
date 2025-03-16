using System;
using System.ComponentModel.DataAnnotations;




namespace controlpannel.application.Dtos.ConfigurationPassword;
public class UpdateConfigurationPasswordRequestDto
{
    [Required]
    public long Id { get; set; }

    public bool IsComplex { get; set; }
    public bool MustBeChangedInFirstLogin { get; set; }
    public bool MustContainChar { get; set; }
    public bool MustContainUpperCase { get; set; }
    public bool IsPolicyNeeded { get; set; }
    public short MinPassLength { get; set; }
    public short MaxPassLength { get; set; }
    public short NumericPassNotEqual { get; set; }
    public bool WillPassExpire { get; set; }
    public short ExpireDaysAmount { get; set; }
    public bool RedirectToCustomUrlAfterChangePass { get; set; }
    public string UrlAfterChangePass { get; set; }
    public bool TwoFactorEnabled { get; set; }
}
