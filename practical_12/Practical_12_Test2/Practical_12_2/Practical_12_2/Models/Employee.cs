using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_12_2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Fname { get; set; }
        public string Mname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [Required]
        public int Mno { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Salary { get; set; }
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }
    }
}