using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_FirstMVC_WithDatabase.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
    }
}