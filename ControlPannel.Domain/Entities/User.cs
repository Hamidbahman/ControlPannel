using System;
using System.ComponentModel.DataAnnotations.Schema;
using controlpannel.domain.Entities;
using ControlPannel.Domain.Enums;

namespace ControlPannel.Domain.Entities;

[Table("tbUser")]
public class User : BaseEntity
{
    public string Uuid { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string NationalCode { get; private set; }
    public string Email { get; private set; }
    public string Mobile {get; private set;}
    public string PrimaryKey {get; private set;}
    public string IpRange {get; private set;}
    public int LoginAttempt {get; private set;}
    public string Picture {get; private set;}
    public string PictureType {get; private set;}
    public string Scheduled {get; private set;}
    public StatusTypes Status {get; private set;}
    public bool TwoFactor {get; private set;}
    public string Description {get; private set;}

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public ICollection<UserProperty> UserProperties {get; private set;} = new List<UserProperty>();
    public ICollection<LoginPolicy> LoginPolicies {get; private set;} = new List<LoginPolicy>();

    private User(){}

    public User(
        long id,
        DateTime createDate,
        DateTime modifyDate,
        DateTime? deleteDate,
        string? deleteUser,
        string? modifyUser,
        string uuid,
        string firstName,
        string mobile,
        string primaryKey,
        string ipRange,
        int loginAttempt,
        string picture,
        string pictureType,
        string scheduled,
        StatusTypes status,
        bool twoFactor,
        string lastName,
        string nationalCode,
        string email,
        string? description
    ) : base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
    {
        Uuid = uuid;
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        Email = email;
        Mobile = mobile;
        Description = description;
        PrimaryKey = primaryKey;
        IpRange = ipRange;
        LoginAttempt = loginAttempt;
        Picture = picture;
        PictureType = pictureType;
        Scheduled = scheduled;
        Status = status;
        TwoFactor = twoFactor;

    }
}
