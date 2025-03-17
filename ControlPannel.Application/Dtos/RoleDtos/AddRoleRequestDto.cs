using System;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPannel.Domain.Entities;
using ControlPannel.Domain.Enums;

namespace controlpannel.application.Dtos.RoleDtos;

public class AddRoleRequestDto
{
        public string Uuid { get; private set; }
    public AuthorityType Authority { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public StatusTypes Status { get; private set; }

    [ForeignKey("ApplicationId")]
    public long ApplicationId { get; private set; }

    public bool IsAdmin { get; private set; }

}
