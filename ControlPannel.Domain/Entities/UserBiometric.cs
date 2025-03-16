using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPannel.Domain.Entities;


[Table("tbUserBiometric")]
public class UserBiometric : BaseEntity
{
    [ForeignKey("BiometricType")]
    public string BiometricTitle {get;private set;}
    public BiometricType BiometricType {get; private set;}
    [ForeignKey("User")]
    public long UserId {get;private set;}
    public User? User {get;private set;}

    public UserBiometric() {}

    public UserBiometric(
        DateTime createDate,
        DateTime modifyDate,
        DateTime? deleteDate,
        string? deleteUser,
        string? modifyUser,
        string biometricTitle,
        long userId,
        long id
    
    ): base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
    {
        BiometricTitle = biometricTitle;
        UserId = userId;
    }
}
