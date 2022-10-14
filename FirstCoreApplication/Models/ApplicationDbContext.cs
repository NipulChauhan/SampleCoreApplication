using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace FirstCoreApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
                
        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
    }
}
