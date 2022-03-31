using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Designation
    {
        [Key]

        public int ID { get; set; }
        public string DesignationName { get; set; }
    }
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FName { get; set; }

        public string MName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DOB { get; set; }
        [Required]
        [StringLength(10)]
        public string MobileNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public Decimal Salary { get; set; }
        [Required]
        [ForeignKey("ID")]
        public int Designation_ID { get; set; }
        
        public Employee DesignationID { get; set; }

    }
}
