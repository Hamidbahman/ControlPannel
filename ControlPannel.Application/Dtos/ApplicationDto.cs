using System;
using ControlPannel.Domain.Enums;

namespace controlpannel.Application.Dtos;

    public class ApplicationDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ClientId { get; set; }
        public string RedirectUrls { get; set; }
        public string ClientScope { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationGrandType { get; set; }
        public string IpRange { get; set; }
        public bool IsAutoApprove { get; set; }
        public string Scheduled { get; set; }
        public StatusTypes Status { get; set; }
        public bool LockEnabled { get; set; }
        public string Description { get; set; }
    }
