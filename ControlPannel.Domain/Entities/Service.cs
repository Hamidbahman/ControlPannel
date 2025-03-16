using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPannel.Domain.Enums;

namespace ControlPannel.Domain.Entities;

[Table("tbService")]
public class Service : BaseEntity
{
    public ServiceTypes ServiceType {get;private set;}
    [Key]
    [StringLength(200)]
    public string? ServiceKey {get;private set;}
    [StringLength(200)]
    public string Rest {get;private set;}
    [ForeignKey("Actee")]
    public long ActeeId{get;private set;}

    public Actee? Actee {get;private set;}
    public Service (){}

    public Service(
        long id,
        DateTime createDate,
        DateTime modifyDate,
        DateTime deleteDate,
        string? deleteUser,
        string? modifyUser,
        ServiceTypes serviceType, 
        string serviceKey, 
        string rest, 
        long acteeId

    ): base (id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
    {
        ServiceType = serviceType;
        ServiceKey = serviceKey;
        Rest = rest;
        ActeeId = acteeId;
    }

}

