using System;

namespace ControlPannel.Domain.Entities;

public abstract class BaseEntity
{
    public long Id { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime ModifyDate { get; private set; }
    public DateTime? DeleteDate { get; private set; }
    public string? DeleteUser { get; private set; }
    public string? ModifyUser { get; private set; }

    protected BaseEntity() { }

    protected BaseEntity(long id, DateTime createDate, DateTime modifyDate, DateTime? deleteDate, string? deleteUser, string? modifyUser)
    {
        Id = id;
        CreateDate = createDate;
        ModifyDate = modifyDate;
        DeleteDate = deleteDate;
        DeleteUser = deleteUser;
        ModifyUser = modifyUser;
    }
}
