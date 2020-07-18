using System;
using System.ComponentModel.DataAnnotations;
using Workflow.Shared;

namespace KK.Workflow.Service.DataContext
{
    public class InboxRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]
        public Guid StatusRequestId { get; set; }
        [Required]
        [StringLength(32)]
        public string RequestNumber { get; set; }
        [StringLength(128)]
        public string DocumentName { get; set; }
        [StringLength(64)]
        public string DocumentNumber { get; set; }
        [StringLength(24)]
        [Required]
        public string ActorCodeRequester { get; set; }
        [StringLength(64)]
        [Required]
        public string ActorNameRequester { get; set; }
        [Required]
        public DateTime AssignDate { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
        [StringLength(128)]
        public string Subject { get; set; }

        public DateTime? CommitmentDate { get; set; }
        [StringLength(24)]
        [Required]
        public string ActorCodeAssignees { get; set; }
        [StringLength(64)]
        [Required]
        public string ActorNameAssignees { get; set; }
        [Required]
        public bool IsComplete { get; set; }
        [Required]
        public ActivityStatusEnum RequestStatus { get; set; }
        [StringLength(64)]
        [Required]
        public string DisplayStatus { get; set; }

        public DateTime? CompleteDate { get; set; }

        [Required]
        public bool HasView { get; set; }

        public DateTime? ViewDate { get; set; }

        public string ViewNetworkInfo { get; set; }
        [Required]
        public ActionTypeEnum ActionType { get; set; }
        [StringLength(1024)]
        public string UrlAction { get; set; }
        [StringLength(1024)]
        public string JavascriptAction { get; set; }
        [Required]
        [StringLength(24)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public virtual StatusRequest StatusRequest { get; set; }
    }
}
