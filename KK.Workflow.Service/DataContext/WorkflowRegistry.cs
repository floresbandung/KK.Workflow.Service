using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KK.Workflow.Service.DataContext
{
    public class WorkflowRegistry
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [StringLength(64)]
        public string WorkflowName { get; set; }
        [StringLength(12)]
        public string WorkflowCode { get; set; }
        [StringLength(12)]
        [Required]
        public string Version { get; set; }
        [StringLength(24)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public IEnumerable<TemplateProcessRequest> TemplateProcessRequests { get; set; }
        public IEnumerable<ProcessRequest> ProcessRequests { get; set; }
    }
}
