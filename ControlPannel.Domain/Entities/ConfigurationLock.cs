using System;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPannel.Domain.Enums;

namespace ControlPannel.Domain.Entities;

[Table("tbConfigurationLock")]
public class ConfigurationLock : BaseEntity
{
    public bool CaptchaNeeded {get;private set;} = false;
    public short FailedLoginAmountBeforeCaptcha {get;private set;}
    public int LockTimeInterval {get;private set;}
    public LockTypes LockType {get;private set;}
    [ForeignKey("Application")]
    public long ApplicationId {get;private set;}
    public Aplication Application {get;private set;}

    public ConfigurationLock(){}

    public ConfigurationLock(
        DateTime createDate,
        DateTime modifyDate,
        DateTime? deleteDate,
        string? deleteUser,
        string? modifyUser,
        long id,
        bool captchaNeeded,
        short failedLoginAmountBeforeCaptcha,
        int lockTimeInterval,
        LockTypes lockType,
        long applicationId
    ): base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
     {
        CaptchaNeeded = captchaNeeded;
        FailedLoginAmountBeforeCaptcha = failedLoginAmountBeforeCaptcha;
        LockTimeInterval = lockTimeInterval;
        LockType = lockType;
        ApplicationId = applicationId;
    }

    public void EnableCaptcha()
        {
            CaptchaNeeded = true;
        }

        /// <summary>
        /// Resets failed login attempts and disables CAPTCHA.
        /// </summary>
        public void ResetFailedLoginAttempts()
        {

            CaptchaNeeded = false;
        }
}
