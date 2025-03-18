using System;
using ControlPannel.Domain.Enums;

namespace controlpannel.application.Dtos.UserDto;

public class AddUserRequestDto
{

    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Email {get;set;}
    public string Mobile {get;set;}
    public string NationalCode {get;set;}
    public string PrimaryKey {get;set;}
    public string IpRange {get;set;}
    public int LoginAttempt {get;set;}
    public string Scheduled {get; set;}
    public StatusTypes Status {get;set;}
    public bool TwoFactor {get;set;}
    public string Description {get;set;}


}
