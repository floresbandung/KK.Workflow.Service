using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Workflow.Shared;

namespace KK.Workflow.Service.DataContext
{
    public class StatusRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]
        public Guid ProcessActivityId { get; set; }
        [Required]
        [StringLength(32)]
        public string RequestNumber { get; set; }
        [StringLength(128)]
        public string DocumentName { get; set; }
        [StringLength(64)]
        public string DocumentNumber { get; set; }
        [Required]
        public ActivityStatusEnum NewRequestStatus { get; set; }
        [StringLength(64)]
        [Required]
        public string DisplayStatus { get; set; }

        [Required]
        [StringLength(24)]
        public string ActorCode { get; set; }
        [Required]
        [StringLength(64)]
        public string ActorName { get; set; }
        [Required]
        public bool IsComplete { get; set; }

        public DateTime? CompleteDate { get; set; }
        [StringLength(128)]
        [Required]
        public string Subject { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [StringLength(24)]
        public string LastAssignTo { get; set; }
        public DateTime? LastAssignDate { get; set; }

        public DateTime? CommitmentDate { get; set; }
        [Required]
        public SlaTypeEnum SlaType { get; set; }

        public int? SlaTime { get; set; }
        [StringLength(128)]
        public string Notes { get; set; }
        [Required]
        [StringLength(24)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ProcessActivity ProcessActivity { get; set; }
        public IEnumerable<InboxRequest> InboxRequests { get; set; }
    }
}
