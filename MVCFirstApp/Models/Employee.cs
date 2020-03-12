using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFirstApp.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
       
        public int Age { get; set; }

        public string Password { get; set; }


    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        {
            Database.SetInitializer<EmpDBContext>(null);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}