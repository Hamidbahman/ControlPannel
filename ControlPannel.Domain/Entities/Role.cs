using System;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPannel.Domain.Enums;

namespace ControlPannel.Domain.Entities;

[Table("tbRole")]
public class Role : BaseEntity
{
    public Guid Uuid { get; private set; } = Guid.NewGuid();
    public AuthorityType Authority { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public StatusTypes Status { get; private set; }

    [ForeignKey("ApplicationId")]
    public long ApplicationId { get; private set; }
    public Aplication Application { get; private set; }

    public bool IsAdmin { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();
    public ICollection<Permission> Permissions { get; private set; } = new List<Permission>();

    private Role(){}

    public Role(
        long id,
        DateTime createDate,
        DateTime modifyDate,
        DateTime? deleteDate,
        string? deleteUser,
        string? modifyUser,
        Guid uuid,
        AuthorityType authority,
        string title,
        string description,
        StatusTypes status,
        long applicationId,
        bool isAdmin
    ) : base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
    {
        Uuid = uuid;
        Authority = authority;
        Title = title;
        Description = description;
        Status = status;
        ApplicationId = applicationId;
        IsAdmin = isAdmin;
    }
}
