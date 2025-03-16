using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using ControlPannel.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using controlpannel.domain.Enums;

namespace ControlPannel.Domain.Entities
{
    [Table("tbApplications")]
    public class Aplication : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string RedirectUrls { get; set; }

        [Required]
        [StringLength(50)]
        public string ClientId { get; set; }

        [StringLength(200)]
        public string ClientScope { get; set; }

        [StringLength(100)]
        public string ClientSecret { get; set; }

        [Required]
        [EnumDataType(typeof(GrantType))]
        public GrantType AuthorizationGrandType { get; set; }

        [StringLength(50)]
        public string IpRange 
        { 
            get => _ipRange;
            set
            {
                if (!IsValidCidr(value))
                    throw new ArgumentException("Invalid CIDR format for IpRange");
                _ipRange = value;
            }
        }

        private string _ipRange;

        public bool IsAutoApprove { get; set; }

        [StringLength(50)]
        public string Scheduled { get; set; }

        [Required]
        [EnumDataType(typeof(StatusTypes))]
        public StatusTypes Status { get; set; }

        public bool LockEnabled { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<ApplicationPackage> ApplicationPackages { get; set; } = new List<ApplicationPackage>();
        public ICollection<ConfigurationSession> ConfigurationSessions { get; set; } = new List<ConfigurationSession>();
        public ICollection<ConfigurationLock> ConfigurationLocks { get; set; } = new List<ConfigurationLock>();
        public ICollection<ConfigurationPassword> ConfigurationPasswords { get; set; } = new List<ConfigurationPassword>();

        public Aplication() {}

        public Aplication(
            long id,
            string title,
            string clientId,
            DateTime createDate,
            DateTime modifyDate,
            DateTime? deleteDate = null,
            string? deleteUser = null,
            string? modifyUser = null,
            string? redirectUrls = null,
            string? clientScope = null,
            string? clientSecret = null,
            GrantType authenticateGrantType = GrantType.AuthorizationCode,
            string? ipRange = null,
            bool isAutoApprove = false,
            string? scheduled = null,
            StatusTypes status = StatusTypes.Active,
            bool lockEnabled = true,
            string? description = null,
            ICollection<Role?> roles = null,
            ICollection<ApplicationPackage>? applicationPackages = null,
            ICollection<ConfigurationSession>? configurationSessions = null,
            ICollection<ConfigurationLock>? configurationLocks = null,
            ICollection<ConfigurationPassword>? configurationPasswords = null
        ) : base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            RedirectUrls = redirectUrls;
            ClientScope = clientScope;
            ClientSecret = clientSecret;
            AuthorizationGrandType = authenticateGrantType;
            IpRange = ipRange;
            IsAutoApprove = isAutoApprove;
            Scheduled = scheduled;
            Status = status;
            LockEnabled = lockEnabled;
            Description = description;
            ApplicationPackages = applicationPackages ?? new List<ApplicationPackage>();
            ConfigurationSessions = configurationSessions ?? new List<ConfigurationSession>();
            ConfigurationLocks = configurationLocks ?? new List<ConfigurationLock>();
            ConfigurationPasswords = configurationPasswords ?? new List<ConfigurationPassword>();
            Roles = roles ?? new List<Role>();
        }

        private static bool IsValidCidr(string cidr)
        {
            if (string.IsNullOrWhiteSpace(cidr))
                return false;

            var parts = cidr.Split('/');
            if (parts.Length != 2 || !int.TryParse(parts[1], out int prefixLength))
                return false;

            if (IPAddress.TryParse(parts[0], out IPAddress address))
            {
                return (address.AddressFamily == AddressFamily.InterNetwork && prefixLength >= 0 && prefixLength <= 32) ||
                       (address.AddressFamily == AddressFamily.InterNetworkV6 && prefixLength >= 0 && prefixLength <= 128);
            }

            return false;
        }
    }
}