using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
namespace Repository
{
    public class EmployeeDBContext :DbContext
    {
        public EmployeeDBContext() : base("EmpDBContext")
        {
            
        }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employeedata { get; set; }
    }
}
