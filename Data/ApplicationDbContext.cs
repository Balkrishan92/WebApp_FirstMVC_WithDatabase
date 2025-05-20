using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp_FirstMVC_WithDatabase.Models;

namespace WebApp_FirstMVC_WithDatabase.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("conStr")
        {

        }
       public DbSet<Employee> Employees { get; set; }
    }
}