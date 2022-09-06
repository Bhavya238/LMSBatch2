using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LMSBatch2.Models
{
    public partial class Leave
    {
        public int LeaveId { get; set; }
        [Required(ErrorMessage="LeaveType is mandatory")]
        public string LeaveType { get; set; }
        [DefaultValue("Pending")]
        public string LeaveStatus { get; set; }
        [StringLength(50,MinimumLength =10,ErrorMessage ="Reason field mandatory")]
        public string LeaveReason { get; set; }
        [Required(ErrorMessage="Employee id is mandatory")]
        public int? EmpId { get; set; }
        [Required(ErrorMessage="ManagerId is mandatory")]
        public int? ManagerId { get; set; }
        [Required(ErrorMessage = "StartDate field is mandatory")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        [MyDate(ErrorMessage = "Start date should not be in the past")]
        public DateTime? LeaveStartDate { get; set; }
        [Required(ErrorMessage = "EndDate field is mandatory")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime? LeaveEndDate { get; set; }
        [Required(ErrorMessage ="Leave balance is manadatory")]
        public int? LeaveBalanace { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
