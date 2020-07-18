using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Workflow.Service.DataContext
{
    public class EmailTask
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]
        [StringLength(24)]
        public string TaskFrom { get; set; }
        [Required]
        public Guid SourceId { get; set; }
        [StringLength(128)]
        public string EmailFrom { get; set; }
        [StringLength(1280)]
        public string EmailTo { get; set; }
        [StringLength(1280)]
        public string EmailCc { get; set; }
        [StringLength(128)]
        public string EmailSubject { get; set; }
        [DataType(DataType.Text)]
        public string EmailBody { get; set; }

        public int? ResendCount { get; set; }
        [StringLength(1024)]
        public string ErrorMessage { get; set; }

        public DateTime? StartSend { get; set; }

        public DateTime? EndSend { get; set; }

        public bool? IsSuccess { get; set; }

        [Required]
        [StringLength(24)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
