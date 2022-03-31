using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical_12_2.Models
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        public string designation { get; set; }

    }
}