using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KK.Workflow.Service.DataContext
{
    public class ProcessRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]
        [StringLength(6)]
        public string CompanyCode { get; set; }
        [Required]
        [StringLength(12)]
        public string ModuleCode { get; set; }
        [Required]
        [StringLength(32)]
        public string ModuleName { get; set; }
        [StringLength(256)]
        public string ModuleDescription { get; set; }
        [Required]
        public DateTime StartActive { get; set; }
        [Required]
        public DateTime EndActive { get; set; }
        [Required]
        public Guid WorkflowId { get; set; }
        [DataType(DataType.Text)]
        public string Notes { get; set; }
        [StringLength(24)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public WorkflowRegistry WorkflowRegistry { get; set; }
        public IEnumerable<ProcessActivity> ProcessActivities { get; set; }
    }
}
