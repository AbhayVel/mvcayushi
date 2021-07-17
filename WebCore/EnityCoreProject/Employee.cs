using EnityCoreProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }

        public Address Address { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
