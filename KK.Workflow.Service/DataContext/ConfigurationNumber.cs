using System;
using System.ComponentModel.DataAnnotations;

namespace KK.Workflow.Service.DataContext
{
    public class ConfigurationNumber
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [StringLength(64)]
        [Required]
        public string Name { get; set; }
        [StringLength(24)]
        public string TypeSuffixChar { get; set; }
        [StringLength(6)]
        public string SuffixChar { get; set; }
        [Required]
        public int LastIndex { get; set; }
        [Required]
        public int LengthNumber { get; set; }
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
