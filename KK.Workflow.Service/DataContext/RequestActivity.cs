using System;
using System.ComponentModel.DataAnnotations;
using Workflow.Shared;

namespace KK.Workflow.Service.DataContext
{
    public class RequestActivity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public byte RowStatus { get; set; }
        [Required]
        public Guid ProcessActivityId { get; set; }
        [Required]
        [StringLength(64)]
        public string ReferenceKey { get; set; }
        [Required]
        [StringLength(32)]
        public string RequestNumber { get; set; }
        [StringLength(128)]
        public string DocumentName { get; set; }
        [StringLength(64)]
        public string DocumentNumber { get; set; }
        [Required]
        public int ActivityIndex { get; set; }

        [Required]
        [StringLength(24)]
        public string ActorCode { get; set; }
        [Required]
        [StringLength(64)]
        public string ActorName { get; set; }
        [StringLength(64)]
        public ActivityStatusEnum RequestStatus { get; set; }
        [StringLength(64)]
        public string DisplayStatus { get; set; }
        [StringLength(128)]
        public string SubjectName { get; set; }

        public bool IsComplete { get; set; }
        [StringLength(24)]
        [Required]
        public string ActionName { get; set; }

        public DateTime? ActionDate { get; set; }

        [Required]
        public SlaTypeEnum SlaType { get; set; }

        public int? SlaTime { get; set; }
        [StringLength(128)]
        public string Notes { get; set; }
        [StringLength(24)]
        public string IpAddress { get; set; }

        [Required]
        [StringLength(24)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }



        public ProcessActivity ProcessActivity { get; set; }
    }
}
