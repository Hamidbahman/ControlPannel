using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPannel.Domain.Entities;

    [Table("tbConfigurationSession")]
    public class ConfigurationSession : BaseEntity
    {
        public bool IsConcurrentActive { get; private set; }
        public int ConcurrencyCount { get; private set; }
        public int SessionTimeout { get; private set; }
        
        [ForeignKey("Application")]
        public long ApplicationId { get; private set; }
        
        public Aplication Application { get; private set; }

        // Constructor
        public ConfigurationSession(
            long id,
            DateTime createDate,
            DateTime modifyDate,
            DateTime? deleteDate,
            string? deleteUser,
            string? modifyUser,
            long applicationId, 
            bool isConcurrentActive, 
            int concurrencyCount, 
            int sessionTimeout
        ) : base(id, createDate, modifyDate, deleteDate, deleteUser, modifyUser)  
        {
            ApplicationId = applicationId;
            IsConcurrentActive = isConcurrentActive;
            ConcurrencyCount = concurrencyCount;
            SessionTimeout = sessionTimeout;
        }
    }

