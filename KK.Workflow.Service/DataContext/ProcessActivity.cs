﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Workflow.Shared;

namespace KK.Workflow.Service.DataContext
{
    public class ProcessActivity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte RowStatus { get; set; }
        [Required]
        public Guid ProcessRequestId { get; set; }
        [Required]
        public int ActivityIndex { get; set; }
        [StringLength(128)]
        public string SubjectName { get; set; }
        [StringLength(128)]
        public string ViewSubject { get; set; }
        [StringLength(128)]
        public string PostSubject { get; set; }
        [StringLength(32)]
        public ActivityStatusEnum NewStatus { get; set; }
        [Required]
        public int MinimumApprovalCount { get; set; }
        [StringLength(64)]
        public string DisplayName { get; set; }

        public decimal? StartValue { get; set; }

        public decimal? EndValue { get; set; }

        public SlaTypeEnum SlaType { get; set; }

        public int? SlaTime { get; set; }
        public ActionTypeEnum? UrlActionType { get; set; }
        [StringLength(1024)]
        public string UrlAction { get; set; }
        [StringLength(256)]
        public string ApprovalJavascriptAction { get; set; }
        [StringLength(256)]
        public string ViewJavascriptAction { get; set; }
        [StringLength(256)]
        public string Other01JavascriptAction { get; set; }
        [StringLength(256)]
        public string Other02JavascriptAction { get; set; }
        [StringLength(256)]
        public string Other03JavascriptAction { get; set; }
        [StringLength(256)]
        public string Other04JavascriptAction { get; set; }
        [StringLength(24)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(24)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        public ProcessRequest ProcessRequest { get; set; }
        public IEnumerable<ProcessActivityActor> ProcessActivityActors { get; set; }
        public IEnumerable<StatusRequest> StatusRequests { get; set; }
    }
}
