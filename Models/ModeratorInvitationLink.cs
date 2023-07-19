﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ModeratorInvitationLink
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Moderator")]
        public int ModeratorId { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public string InvitationCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual Moderator Moderator { get; set; }
        public virtual PollingData PollingData { get; set; }
    }
}
