using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LMSBatch2.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManager = new HashSet<Employee>();
            Leaves = new HashSet<Leave>();
        }


        public int EmpId { get; set; }
        [StringLength(10,MinimumLength=5,ErrorMessage="Employee name msut be of 5-10 characters")]
        public string EmpName { get; set; }
        [StringLength(10,MinimumLength =5,ErrorMessage ="Employee User name is mandatory")]
        public string EmpUname { get; set; }
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Employee Password is mandatory")]
        public string EmpPass { get; set; }
        //[StringLength(10, MinimumLength = 5, ErrorMessage = "Employee Email is mandatory")]
        public string EmpEmail { get; set; }
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Address is mandatory")]
        public string EmpAddress { get; set; }
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Phone no. is mandatory")]
        public string EmpPhone { get; set; }
        [Required (ErrorMessage = "ManagerId is mandatory")]
        public int? ManagerId { get; set; }
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Designation is mandatory")]
        public string Designation { get; set; }
        [Range(1,3,ErrorMessage ="Range should be between 1-3")]
        public int? Level { get; set; }

        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
    }
}
