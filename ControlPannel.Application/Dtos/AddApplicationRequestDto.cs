using System;
using System.ComponentModel.DataAnnotations;
using ControlPannel.Domain.Enums;

namespace controlpannel.Application.Dtos;

public class AddApplicationRequestDto 
{
    public string RedirectUrls {get;set;}
    [Required]
    public string ClientId {get;set;}
    public string ClientScope {get;set;}
    public string ClientSecret {get;set;}
    public string  AuthorizationGrandType {get;set;} 
    public string IpRange {get;set;}
    public bool IsAutoApprove {get;set;}
    public StatusTypes Status {get;set;}
    public bool LockEnabled {get;set;}
    public string Description {get;set;}
    [RegularExpression(@"^(\d{2}:\d{2}-\d{2}:\d{2})$", ErrorMessage = "Scheduled format should be HH:mm-HH:mm")]

    public string Scheduled {get;set;}

    [Required]
    public string Title {get;set;}
}
