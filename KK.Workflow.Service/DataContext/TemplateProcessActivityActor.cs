using System;
using System.ComponentModel.DataAnnotations;
using Workflow.Shared;

namespace KK.Workflow.Service.DataContext
{
    public class TemplateProcessActivityActor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]

        public Guid ProcessActivityId { get; set; }
        [Required]
        [StringLength(24)]
        public string ActorCode { get; set; }
        [Required]
        [StringLength(64)]
        public string ActorName { get; set; }
        [StringLength(64)]
        public string ActorPosition { get; set; }
        [Required]
        public ActionTypeEnum ActionType { get; set; }
        [StringLength(128)]
        [Required]
        public string ActorEmail { get; set; }
        [StringLength(24)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public TemplateProcessActivity TemplateProcessActivity { get; set; }
    }
}
